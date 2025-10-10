using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PavlovReplayReader;
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

#if DEBUG
var reader = new ReplayReader(logger, ParseMode.Debug);
#else
var reader = new ReplayReader(null, ParseMode.Minimal);
#endif

foreach (var replayFile in replayFiles)
{
    sw.Restart();
    try
    {
        var replay = reader.ReadReplay(replayFile);
        
        // Display replay header information
        Console.WriteLine($"\n=== Replay: {Path.GetFileName(replayFile)} ===");
        Console.WriteLine($"Network Version: {replay.Header?.NetworkVersion}");
        Console.WriteLine($"Changelist: {replay.Header?.Changelist}");
        Console.WriteLine($"Branch: {replay.Header?.Branch}");
        Console.WriteLine($"Platform: {replay.Header?.Platform}");
        
        // Display game data information
        if (replay.GameData != null)
        {
            Console.WriteLine("\n--- Game Data ---");
            Console.WriteLine($"Game Mode: {replay.GameData.GameModeType}");
            Console.WriteLine($"Match State: {replay.GameData.MatchState}");
            Console.WriteLine($"Round Time: {replay.GameData.RoundTime}");
            Console.WriteLine($"Team 0 Score: {replay.GameData.Team0Score}");
            Console.WriteLine($"Team 1 Score: {replay.GameData.Team1Score}");
            Console.WriteLine($"Max Players: {replay.GameData.MaxPlayers}");
            Console.WriteLine($"Competitive Mode: {replay.GameData.CompetitiveMode}");
            Console.WriteLine($"No Teams: {replay.GameData.bNoTeams}");
        }
        
        // Display player information
        if (replay.Players != null && replay.Players.Count > 0)
        {
            Console.WriteLine($"\n--- Players ({replay.Players.Count}) ---");
            foreach (var player in replay.Players)
            {
                Console.WriteLine($"  [{player.TeamId}] {player.PlayerName} (ID: {player.PlayerId})");
                Console.WriteLine($"      K/D/A: {player.Kills}/{player.Deaths}/{player.Assists}");
                Console.WriteLine($"      Cash: {player.Cash} | Score: {player.Score} | Dead: {player.bDead}");
            }
        }
        else
        {
            Console.WriteLine("\n--- No Players Found ---");
        }
        
        // Serialize to JSON for detailed inspection
        var json = JsonSerializer.Serialize(replay, new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });

        var jsonFilePath = Path.Combine(replayFilesFolder, Path.GetFileNameWithoutExtension(replayFile) + ".json");
        File.WriteAllText(jsonFilePath, json);
        
        Console.WriteLine($"\nJSON saved to: {jsonFilePath}");
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

Console.WriteLine($"total: {total / 1000} seconds ----");
