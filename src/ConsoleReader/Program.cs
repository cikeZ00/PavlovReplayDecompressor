using System;
using System.Diagnostics;
using System.IO;
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
var reader = new ReplayReader(null, ParseMode.Minimal);
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
        
        // Export 2: Timeline data (positions over time)
        if (timeline != null && timeline.PawnTimelines.Count > 0)
        {
            var timelineFilePath = Path.Combine(replayFilesFolder, baseName + "_timeline.json");
            File.WriteAllText(timelineFilePath, JsonSerializer.Serialize(timeline, jsonOptions));
            Console.WriteLine($"Timeline saved to: {timelineFilePath}");
            
            // Export 3: CSV of positions (easier to work with for analysis)
            var csvFilePath = Path.Combine(replayFilesFolder, baseName + "_positions.csv");
            ExportPositionsCsv(csvFilePath, timeline);
            Console.WriteLine($"Positions CSV saved to: {csvFilePath}");
        }
        
        // Export 4: Full replay data (for debugging)
        var fullFilePath = Path.Combine(replayFilesFolder, baseName + "_full.json");
        File.WriteAllText(fullFilePath, JsonSerializer.Serialize(replay, jsonOptions));
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
/// Export position data as CSV for easy analysis in spreadsheets or other tools.
/// </summary>
static void ExportPositionsCsv(string filePath, ReplayTimeline timeline)
{
    using var writer = new StreamWriter(filePath);
    
    // Header - include hand positions for full VR tracking data
    writer.WriteLine("Time,PawnChannel,TeamId,PlayerName,HeadX,HeadY,HeadZ,LeftHandX,LeftHandY,LeftHandZ,RightHandX,RightHandY,RightHandZ,Heading,Pitch,Yaw,Roll");
    
    // Data rows
    foreach (var pawnTimeline in timeline.PawnTimelines)
    {
        foreach (var snapshot in pawnTimeline.Snapshots)
        {
            var line = string.Join(",",
                snapshot.Time.ToString("F2"),
                pawnTimeline.ChannelIndex,
                pawnTimeline.TeamId?.ToString() ?? "",
                EscapeCsv(pawnTimeline.PlayerName ?? ""),
                snapshot.Location?.X.ToString("F2") ?? "",
                snapshot.Location?.Y.ToString("F2") ?? "",
                snapshot.Location?.Z.ToString("F2") ?? "",
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
