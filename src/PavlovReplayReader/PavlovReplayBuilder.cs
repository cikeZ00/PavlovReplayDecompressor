using System;
using System.Collections.Generic;
using System.Linq;
using PavlovReplayReader.Models;
using Unreal.Core.Contracts;

namespace PavlovReplayReader;

/// <summary>
/// Responsible for constructing the <see cref="PavlovReplay"/> out of the received exports.
/// </summary>
public class PavlovReplayBuilder
{
    private readonly Dictionary<uint, INetFieldExportGroup> _channelToExportMap = new();
    private GameData? _gameData;
    private readonly Dictionary<uint, PlayerData> _players = new();

    /// <summary>
    /// Called when an export is read from the replay.
    /// </summary>
    public void OnExportRead(uint channelIndex, INetFieldExportGroup? exportGroup)
    {
        if (exportGroup == null)
            return;

        // Store the export by channel for tracking
        _channelToExportMap[channelIndex] = exportGroup;

        var typeName = exportGroup.GetType().Name;
        
        // Use type name to detect GameState/PlayerState
        if (typeName.Contains("GameState", System.StringComparison.OrdinalIgnoreCase))
        {
            _gameData ??= new GameData();
            UpdateGameData(exportGroup);
        }
        else if (typeName.Contains("PlayerState", System.StringComparison.OrdinalIgnoreCase))
        {
            if (!_players.ContainsKey(channelIndex))
            {
                _players[channelIndex] = new PlayerData();
            }
            UpdatePlayerData(_players[channelIndex], exportGroup);
        }
    }

    private void UpdateGameData(INetFieldExportGroup exportGroup)
    {
        if (_gameData == null) return;

        // Use reflection to copy properties from export to GameData
        var exportType = exportGroup.GetType();
        var gameDataType = typeof(GameData);

        foreach (var prop in exportType.GetProperties())
        {
            var targetProp = gameDataType.GetProperty(prop.Name);
            if (targetProp != null && targetProp.CanWrite)
            {
                try
                {
                    var value = prop.GetValue(exportGroup);
                    if (value != null)
                    {
                        targetProp.SetValue(_gameData, value);
                    }
                }
                catch
                {
                    // Ignore conversion errors
                }
            }
        }
    }

    private void UpdatePlayerData(PlayerData playerData, INetFieldExportGroup exportGroup)
    {
        // Use reflection to copy properties from export to PlayerData
        var exportType = exportGroup.GetType();
        var playerDataType = typeof(PlayerData);

        foreach (var prop in exportType.GetProperties())
        {
            // Special handling for PlayerNamePrivate -> PlayerName mapping
            var targetPropertyName = prop.Name == "PlayerNamePrivate" ? "PlayerName" : prop.Name;
            var targetProp = playerDataType.GetProperty(targetPropertyName);
            
            if (targetProp != null && targetProp.CanWrite)
            {
                try
                {
                    var value = prop.GetValue(exportGroup);
                    if (value != null)
                    {
                        targetProp.SetValue(playerData, value);
                    }
                }
                catch
                {
                    // Ignore conversion errors
                }
            }
        }
    }

    /// <summary>
    /// Once a replay is fully parsed, add the data build over time to the replay.
    /// </summary>
    /// <param name="replay"></param>
    /// <returns>PavlovReplay</returns>
    public PavlovReplay Build(PavlovReplay replay)
    {
        replay.GameData = _gameData;
        replay.Players = _players.Values.ToList();
        return replay;
    }
}
