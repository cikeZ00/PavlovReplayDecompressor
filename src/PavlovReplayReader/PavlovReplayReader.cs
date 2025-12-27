using PavlovReplayReader.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.IO;
using System.Security.Cryptography;
using Unreal.Core;
using Unreal.Core.Contracts;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;
using Unreal.Encryption;

namespace PavlovReplayReader;

public class ReplayReader : Unreal.Core.ReplayReader<PavlovReplay>
{
    private PavlovReplayBuilder? Builder;
    private string? _currentFileName;
    
    /// <summary>
    /// Whether to record timeline data (position snapshots over time).
    /// Set to true before calling ReadReplay to capture timeline data.
    /// </summary>
    public bool RecordTimeline { get; set; } = false;
    
    /// <summary>
    /// Minimum time interval between timeline snapshots in seconds.
    /// Default is 0.1 seconds (10 snapshots per second).
    /// </summary>
    public float SnapshotInterval { get; set; } = 0.1f;

    public ReplayReader(ILogger? logger = null, ParseMode parseMode = ParseMode.Minimal) 
        : base(logger ?? NullLogger.Instance, parseMode)
    {
    }

    public PavlovReplay ReadReplay(string fileName)
    {
        _currentFileName = Path.GetFileName(fileName);
        using var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        return ReadReplay(stream);
    }

    public override PavlovReplay ReadReplay(FArchive archive)
    {
        Builder = new PavlovReplayBuilder
        {
            RecordTimeline = RecordTimeline,
            SnapshotInterval = SnapshotInterval
        };
        
        Replay = new PavlovReplay();
        ReadReplayInfo(archive);
        ReadReplayChunks(archive);

        Cleanup();
        
        return Builder.Build(Replay);
    }
    
    /// <summary>
    /// Gets the timeline data after reading a replay.
    /// Must have set RecordTimeline = true before reading.
    /// </summary>
    public ReplayTimeline? GetTimeline()
    {
        return Builder?.BuildTimeline(_currentFileName);
    }

    public PavlovReplay ReadReplay(Stream stream)
    {
        using var archive = new Unreal.Core.BinaryReader(stream);
        return ReadReplay(archive);
    }

    protected override void OnChannelOpened(uint channelIndex, NetworkGUID? actor)
    {
        // Track network GUID to channel index mapping for resolving PropertyObject references
        if (actor?.Value != null && Builder != null)
        {
            Builder.OnChannelOpened(channelIndex, actor.Value);
        }
    }

    protected override void OnChannelClosed(uint channelIndex, NetworkGUID? actor)
    {
        // Clean up channel tracking - note: we keep the mapping as it may still be referenced
        if (actor?.Value != null && Builder != null)
        {
            Builder.OnChannelClosed(channelIndex, actor.Value);
        }
    }

    protected override void OnNetDeltaRead(uint channelIndex, NetDeltaUpdate update)
    {
        // TODO: Handle net delta updates
    }

    protected override void OnExportRead(uint channelIndex, INetFieldExportGroup? exportGroup)
    {
        if (exportGroup != null && Builder != null)
        {
            Builder.OnExportRead(channelIndex, exportGroup);
        }
    }

    protected override void OnExternalDataRead(uint channelIndex, IExternalData? externalData)
    {
        // TODO: Handle external data
    }

    public override void ReadReplayHeader(FArchive archive)
    {
        base.ReadReplayHeader(archive);
    }

    public override void ReadReplayData(FArchive archive, int fallbackChunkSize)
    {
        base.ReadReplayData(archive, fallbackChunkSize);
    }

    public override void ReadDemoFrameIntoPlaybackPackets(FArchive archive)
    {
        base.ReadDemoFrameIntoPlaybackPackets(archive);
    }

    public override void ReadExportData(FArchive archive)
    {
        base.ReadExportData(archive);
    }

    public override void ReadNetFieldExports(FArchive archive)
    {
        base.ReadNetFieldExports(archive);
    }

    public override void ReadEvent(FArchive archive)
    {
        var info = new EventInfo
        {
            Id = archive.ReadFString(),
            Group = archive.ReadFString(),
            Metadata = archive.ReadFString(),
            StartTime = archive.ReadUInt32(),
            EndTime = archive.ReadUInt32(),
            SizeInBytes = archive.ReadInt32()
        };

        _logger?.LogDebug("Encountered event {group} ({metadata}) at {startTime} of size {sizeInBytes}", 
            info.Group, info.Metadata, info.StartTime, info.SizeInBytes);

        using var decryptedArchive = DecryptBuffer(archive, info.SizeInBytes);

        // TODO: Parse events
    }

    protected override FArchive DecryptBuffer(FArchive archive, int size)
    {
        if (!Replay.Info.IsEncrypted)
        {
            return new Unreal.Core.BinaryReader(archive.ReadBytes(size))
            {
                EngineNetworkVersion = Replay.Header.EngineNetworkVersion,
                NetworkVersion = Replay.Header.NetworkVersion,
                ReplayHeaderFlags = Replay.Header.Flags,
                ReplayVersion = Replay.Info.FileVersion
            };
        }

        var key = Replay.Info.EncryptionKey;
        var encryptedBytes = archive.ReadBytes(size);

        using var aes = Aes.Create();
        aes.KeySize = key.Length * 8;
        aes.Key = key.ToArray();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;

        using var cryptoTransform = aes.CreateDecryptor();
        var decryptedArray = cryptoTransform.TransformFinalBlock(encryptedBytes.ToArray(), 0, encryptedBytes.Length);

        return new Unreal.Core.BinaryReader(decryptedArray.AsMemory())
        {
            EngineNetworkVersion = archive.EngineNetworkVersion,
            NetworkVersion = archive.NetworkVersion,
            ReplayHeaderFlags = archive.ReplayHeaderFlags,
            ReplayVersion = archive.ReplayVersion
        };
    }

    protected override FArchive Decompress(FArchive archive)
    {
        if (!Replay.Info.IsCompressed)
        {
            return archive;
        }

        var decompressedSize = archive.ReadInt32();
        var compressedSize = archive.ReadInt32();
        var compressedBuffer = archive.ReadBytes(compressedSize);

        _logger?.LogDebug("Decompressed archive from {compressedSize} to {decompressedSize}.", compressedSize, decompressedSize);
        var output = Oodle.DecompressReplayData(compressedBuffer, decompressedSize);

        return new Unreal.Core.BinaryReader(output)
        {
            EngineNetworkVersion = archive.EngineNetworkVersion,
            NetworkVersion = archive.NetworkVersion,
            ReplayHeaderFlags = archive.ReplayHeaderFlags,
            ReplayVersion = archive.ReplayVersion
        };
    }
}
