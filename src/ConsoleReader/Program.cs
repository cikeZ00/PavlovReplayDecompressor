using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PavlovReplayReader;
using PavlovReplayReader.Models;
using Unreal.Core.Models.Enums;

var serviceCollection = new ServiceCollection()
    .AddLogging(loggingBuilder => loggingBuilder
        .AddConsole()
        .SetMinimumLevel(LogLevel.Error));
var provider = serviceCollection.BuildServiceProvider();
var logger = provider.GetService<ILogger<Program>>();

var replayFilesFolder = @"D:\PavlovFiles\ToParse";
var replayFiles = Directory.EnumerateFiles(replayFilesFolder, "*.replay");

var sw = new Stopwatch();
long total = 0;

// JSON serialization options
var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
};

#if DEBUG
var reader = new ReplayReader(logger, ParseMode.Debug);
#else
var reader = new ReplayReader(null, ParseMode.Debug);
#endif

// Enable timeline recording for time-series data
reader.RecordTimeline = true;
reader.SnapshotInterval = 0.1f; // Snapshot every 100ms

foreach (var replayFile in replayFiles)
{
    sw.Restart();
    try
    {
        var replay = reader.ReadReplay(replayFile);
        var timeline = reader.GetTimeline();
        
        var baseName = Path.GetFileNameWithoutExtension(replayFile);
        
        // Display replay header information
        Console.WriteLine($"\n=== Replay: {Path.GetFileName(replayFile)} ===");
        Console.WriteLine($"Network Version: {replay.Header?.NetworkVersion}");
        Console.WriteLine($"Changelist: {replay.Header?.Changelist}");
        Console.WriteLine($"Branch: {replay.Header?.Branch}");
        Console.WriteLine($"Duration: {replay.Stats?.ReplayDuration:F1}s");
        
        // Display game data information
        if (replay.GameData != null)
        {
            Console.WriteLine("\n--- Game Data ---");
            Console.WriteLine($"Game Mode: {replay.GameData.GameModeType}");
            Console.WriteLine($"Round Time: {replay.GameData.RoundTime}");
            Console.WriteLine($"Team 0 Score: {replay.GameData.Team0Score}");
            Console.WriteLine($"Team 1 Score: {replay.GameData.Team1Score}");
            Console.WriteLine($"Max Players: {replay.GameData.MaxPlayers}");
            Console.WriteLine($"Competitive Mode: {replay.GameData.CompetitiveMode}");
        }
        
        // Display player information
        if (replay.Players != null && replay.Players.Count > 0)
        {
            Console.WriteLine($"\n--- Players ({replay.Players.Count}) ---");
            foreach (var player in replay.Players)
            {
                Console.WriteLine($"  [{player.TeamId}] {player.PlayerName} (ID: {player.PlayerId})");
                Console.WriteLine($"      K/D/A: {player.Kills}/{player.Deaths}/{player.Assists}");
                Console.WriteLine($"      Cash: {player.Cash} | Score: {player.Score}");
            }
        }
        
        // Display timeline stats
        if (timeline != null)
        {
            Console.WriteLine($"\n--- Timeline Data ---");
            Console.WriteLine($"Pawn Timelines: {timeline.PawnTimelines.Count}");
            Console.WriteLine($"Game Events: {timeline.Events.Count}");
            
            var totalSnapshots = 0;
            foreach (var pt in timeline.PawnTimelines)
            {
                totalSnapshots += pt.Snapshots.Count;
            }
            Console.WriteLine($"Total Position Snapshots: {totalSnapshots}");
            
            // Display event breakdown by type
            if (timeline.Events.Count > 0)
            {
                Console.WriteLine("\n--- Event Breakdown ---");
                var eventsByType = timeline.Events.GroupBy(e => e.EventType).OrderByDescending(g => g.Count());
                foreach (var group in eventsByType)
                {
                    Console.WriteLine($"  {group.Key}: {group.Count()}");
                }
                
                // Show recent kills if any
                var kills = timeline.Events.Where(e => e.EventType == "Kill").Take(5);
                if (kills.Any())
                {
                    Console.WriteLine("\n--- Recent Kills ---");
                    foreach (var kill in kills)
                    {
                        if (kill is KillEvent ke)
                        {
                            Console.WriteLine($"  [{ke.Time:F1}s] {ke.KillerName ?? "?"} killed {ke.VictimName ?? "?"}{(ke.IsHeadshot ? " (headshot)" : "")}");
                        }
                        else
                        {
                            Console.WriteLine($"  [{kill.Time:F1}s] {kill.Description}");
                        }
                    }
                }
            }
        }
        
        // Show export type counts for debugging
        if (replay.Stats?.ExportTypeCounts != null)
        {
            Console.WriteLine("\n--- Export Types Received ---");
            var rpcTypes = replay.Stats.ExportTypeCounts
                .Where(kvp => kvp.Key.Contains("Multicast") || kvp.Key.Contains("RPC"))
                .OrderByDescending(kvp => kvp.Value);
            if (rpcTypes.Any())
            {
                Console.WriteLine("RPC Types:");
                foreach (var kvp in rpcTypes.Take(20))
                {
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("No RPC types received!");
                Console.WriteLine("Top 10 export types:");
                foreach (var kvp in replay.Stats.ExportTypeCounts.OrderByDescending(k => k.Value).Take(10))
                {
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
        }
        
        // Export 1: Final state summary (compact JSON)
        var summaryFilePath = Path.Combine(replayFilesFolder, baseName + "_summary.json");
        var summary = new
        {
            Header = new
            {
                replay.Header?.NetworkVersion,
                replay.Header?.Changelist,
                replay.Header?.Branch,
                replay.Header?.Platform,
                Duration = replay.Stats?.ReplayDuration
            },
            GameData = replay.GameData,
            Players = replay.Players,
            Stats = replay.Stats
        };
        File.WriteAllText(summaryFilePath, JsonSerializer.Serialize(summary, jsonOptions));
        Console.WriteLine($"\nSummary saved to: {summaryFilePath}");
        
        // Export 2: Timeline data (positions over time) — written as NDJSON to avoid large memory usage
        if (timeline != null && timeline.PawnTimelines.Count > 0)
        {
            var timelineFilePath = Path.Combine(replayFilesFolder, baseName + "_timeline.ndjson");
            ExportTimelineNdjson(timelineFilePath, timeline, jsonOptions);
            Console.WriteLine($"Timeline saved to: {timelineFilePath}");
            
            // Export 3: CSV of positions (easier to work with for analysis)
            var csvFilePath = Path.Combine(replayFilesFolder, baseName + "_positions.csv");
            ExportPositionsCsv(csvFilePath, timeline);
            Console.WriteLine($"Positions CSV saved to: {csvFilePath}");
        }
        
        // Export 4: Full replay data (for debugging) — streamed NDJSON (use .gz extension to compress)
        var fullFilePath = Path.Combine(replayFilesFolder, baseName + "_full.ndjson");
        ExportReplayNdjson(fullFilePath, replay, timeline, jsonOptions);
        Console.WriteLine($"Full replay saved to: {fullFilePath}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nERROR processing {Path.GetFileName(replayFile)}:");
        Console.WriteLine(ex);
    }
    sw.Stop();
    Console.WriteLine($"\n---- Completed in {sw.ElapsedMilliseconds}ms ----");
    total += sw.ElapsedMilliseconds;
}

Console.WriteLine($"\ntotal: {total / 1000.0:F1} seconds");

/// <summary>
/// Export timeline as NDJSON (one JSON object per line). If filePath ends with .gz, it will be compressed.
/// </summary>
static void ExportTimelineNdjson(string filePath, ReplayTimeline timeline, JsonSerializerOptions options)
{
    using var fs = File.Create(filePath);
    Stream outStream = fs;
    if (filePath.EndsWith(".gz", StringComparison.OrdinalIgnoreCase) || filePath.EndsWith(".gzip", StringComparison.OrdinalIgnoreCase))
    {
        outStream = new GZipStream(fs, CompressionLevel.Optimal);
    }
    using var sw = new StreamWriter(outStream);
    // Header
    sw.WriteLine(JsonSerializer.Serialize(new { type = "timeline_header", pawnCount = timeline.PawnTimelines.Count, events = timeline.Events.Count }, options));
    foreach (var pt in timeline.PawnTimelines)
    {
        foreach (var snapshot in pt.Snapshots)
        {
            sw.WriteLine(JsonSerializer.Serialize(new { type = "snapshot", channel = pt.ChannelIndex, team = pt.TeamId, player = pt.PlayerName, data = snapshot }, options));
        }
    }
    foreach (var ev in timeline.Events)
    {
        sw.WriteLine(JsonSerializer.Serialize(new { type = "event", data = ev }, options));
    }
    sw.Flush();
}

/// <summary>
/// Export entire replay as NDJSON (multiple lines: header, gameData, stats, players, timeline snapshots, events).
/// Use a .gz extension to create a compressed file.
/// </summary>
static void ExportReplayNdjson(string filePath, PavlovReplay replay, ReplayTimeline timeline, JsonSerializerOptions options)
{
    using var fs = File.Create(filePath);
    Stream outStream = fs;
    if (filePath.EndsWith(".gz", StringComparison.OrdinalIgnoreCase) || filePath.EndsWith(".gzip", StringComparison.OrdinalIgnoreCase))
    {
        outStream = new GZipStream(fs, CompressionLevel.Optimal);
    }
    using var sw = new StreamWriter(outStream);
    sw.WriteLine(JsonSerializer.Serialize(new { type = "header", data = replay.Header }, options));
    sw.WriteLine(JsonSerializer.Serialize(new { type = "gameData", data = replay.GameData }, options));
    sw.WriteLine(JsonSerializer.Serialize(new { type = "stats", data = replay.Stats }, options));
    if (replay.Players != null)
    {
        foreach (var p in replay.Players)
            sw.WriteLine(JsonSerializer.Serialize(new { type = "player", data = p }, options));
    }
    if (timeline != null)
    {
        sw.WriteLine(JsonSerializer.Serialize(new { type = "timeline_info", pawnTimelines = timeline.PawnTimelines.Count, events = timeline.Events.Count }, options));
        foreach (var pt in timeline.PawnTimelines)
        {
            foreach (var snapshot in pt.Snapshots)
            {
                sw.WriteLine(JsonSerializer.Serialize(new { type = "snapshot", channel = pt.ChannelIndex, team = pt.TeamId, player = pt.PlayerName, data = snapshot }, options));
            }
        }
        foreach (var ev in timeline.Events)
        {
            sw.WriteLine(JsonSerializer.Serialize(new { type = "event", data = ev }, options));
        }
    }
    sw.Flush();
}

/// <summary>
/// Export position data as CSV for easy analysis in spreadsheets or other tools.
/// </summary>
static void ExportPositionsCsv(string filePath, ReplayTimeline timeline)
{
    using var writer = new StreamWriter(filePath);
    
    // Header - include hand positions for full VR tracking data
    writer.WriteLine("Time,PawnChannel,TeamId,PlayerName,WorldX,WorldY,WorldZ,VelocityX,VelocityY,VelocityZ,HeadX,HeadY,HeadZ,LeftHandX,LeftHandY,LeftHandZ,RightHandX,RightHandY,RightHandZ,Heading,Pitch,Yaw,Roll");
    
    // Data rows
    foreach (var pawnTimeline in timeline.PawnTimelines)
    {
        foreach (var snapshot in pawnTimeline.Snapshots)
        {
            //Console.WriteLine($"Position: Time={snapshot.Time:F2}s PawnCh={pawnTimeline.ChannelIndex} Player={pawnTimeline.PlayerName} Loc=({snapshot.Location?.X:F1},{snapshot.Location?.Y:F1},{snapshot.Location?.Z:F1})");
            var line = string.Join(",",
                snapshot.Time.ToString("F2"),
                pawnTimeline.ChannelIndex,
                pawnTimeline.TeamId?.ToString() ?? "",
                EscapeCsv(pawnTimeline.PlayerName ?? ""),
                snapshot.Location?.X.ToString("F2") ?? "",
                snapshot.Location?.Y.ToString("F2") ?? "",
                snapshot.Location?.Z.ToString("F2") ?? "",
                snapshot.Velocity?.X.ToString("F2") ?? "",
                snapshot.Velocity?.Y.ToString("F2") ?? "",
                snapshot.Velocity?.Z.ToString("F2") ?? "",
                snapshot.HeadLocation?.X.ToString("F2") ?? "",
                snapshot.HeadLocation?.Y.ToString("F2") ?? "",
                snapshot.HeadLocation?.Z.ToString("F2") ?? "",
                snapshot.LeftHandLocation?.X.ToString("F2") ?? "",
                snapshot.LeftHandLocation?.Y.ToString("F2") ?? "",
                snapshot.LeftHandLocation?.Z.ToString("F2") ?? "",
                snapshot.RightHandLocation?.X.ToString("F2") ?? "",
                snapshot.RightHandLocation?.Y.ToString("F2") ?? "",
                snapshot.RightHandLocation?.Z.ToString("F2") ?? "",
                snapshot.Heading?.ToString("F2") ?? "",
                snapshot.Rotation?.Pitch.ToString("F2") ?? "",
                snapshot.Rotation?.Yaw.ToString("F2") ?? "",
                snapshot.Rotation?.Roll.ToString("F2") ?? ""
            );
            writer.WriteLine(line);
        }
    }
}

static string EscapeCsv(string value)
{
    if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
    {
        return $"\"{value.Replace("\"", "\"\"")}\"";
    }
    return value;
} 
