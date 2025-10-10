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

    public ReplayReader(ILogger? logger = null, ParseMode parseMode = ParseMode.Minimal) 
        : base(logger ?? NullLogger.Instance, parseMode)
    {
    }

    public PavlovReplay ReadReplay(string fileName)
    {
        using var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        return ReadReplay(stream);
    }

    public PavlovReplay ReadReplay(Stream stream)
    {
        using var archive = new Unreal.Core.BinaryReader(stream);

        Builder = new PavlovReplayBuilder();
        ReadReplay(archive);

        return Builder.Build(Replay);
    }

    protected override void OnChannelOpened(uint channelIndex, NetworkGUID? actor)
    {
        // TODO: Track channel to actor mapping
    }

    protected override void OnChannelClosed(uint channelIndex, NetworkGUID? actor)
    {
        // TODO: Clean up channel tracking
    }

    protected override void OnNetDeltaRead(uint channelIndex, NetDeltaUpdate update)
    {
        // TODO: Handle net delta updates
    }

    protected override void OnExportRead(uint channelIndex, INetFieldExportGroup? exportGroup)
    {
        // TODO: Handle export groups
    }

    protected override void OnExternalDataRead(uint channelIndex, IExternalData? externalData)
    {
        // TODO: Handle external data
    }

    public override void ReadReplayHeader(FArchive archive)
    {
        base.ReadReplayHeader(archive);
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
