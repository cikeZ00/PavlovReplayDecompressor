using PavlovReplayReader;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using Unreal.Core.Models.Enums;
using System.Text.Json;

// Set up dependency injection and logging services
var serviceCollection = new ServiceCollection()
    .AddLogging(loggingBuilder => loggingBuilder
        .AddConsole()
        .SetMinimumLevel(LogLevel.Error));
var provider = serviceCollection.BuildServiceProvider();
var logger = provider.GetService<ILogger<Program>>();

// Define the folder containing replay files
//var replayFilesFolder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), @"FortniteGame\Saved\Demos");
var replayFilesFolder = @"C:\Users\cikeZ00\Downloads\";
var replayFiles = Directory.EnumerateFiles(replayFilesFolder, "*.replay");

var sw = new Stopwatch();
long total = 0;

#if DEBUG
var reader = new ReplayReader(logger, ParseMode.Normal);
#else
var reader = new ReplayReader(null, ParseMode.Minimal);
#endif

foreach (var replayFile in replayFiles)
{
    sw.Restart();
    try
    {
        var replay = reader.ReadReplay(replayFile);
        var gameData = replay.GameData;
        Console.WriteLine($"GameSessionId: {gameData.GameSessionId}");

        // Serialize the replay object to JSON
        var json = JsonSerializer.Serialize(replay, new JsonSerializerOptions { WriteIndented = true });

        // Define the output JSON file path
        var jsonFilePath = Path.Combine(replayFilesFolder, Path.GetFileNameWithoutExtension(replayFile) + ".json");

        // Write the JSON string to a file
        File.WriteAllText(jsonFilePath, json);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
    sw.Stop();
    Console.WriteLine($"---- {replayFile} : done in {sw.ElapsedMilliseconds} milliseconds ----");
    total += sw.ElapsedMilliseconds;
}

Console.WriteLine($"total: {total / 1000} seconds ----");
