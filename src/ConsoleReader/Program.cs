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
        .SetMinimumLevel(LogLevel.Debug));
var provider = serviceCollection.BuildServiceProvider();
var logger = provider.GetService<ILogger<Program>>();

var replayFilesFolder = @"C:\Users\cikeZ00\Downloads\";
var replayFiles = Directory.EnumerateFiles(replayFilesFolder, "*.replay");

var sw = new Stopwatch();
long total = 0;

#if DEBUG
var reader = new ReplayReader(logger, ParseMode.Full);
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

        var json = JsonSerializer.Serialize(replay, new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });

        var jsonFilePath = Path.Combine(replayFilesFolder, Path.GetFileNameWithoutExtension(replayFile) + ".json");
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
