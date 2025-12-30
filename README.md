# PavlovReplayDecompressor

PavlovReplayDecompressor is a collection of tools and libraries for reading, decoding and analyzing Pavlov VR replay files. It includes a high-quality C# replay reader, compression/decompression utilities, tests and a small WPF viewer.

---

## Highlights

- **Replay parsing**: Robust C# `PavlovReplayReader` for reading and inspecting replay contents.
- **Decompression**: `OozSharp` implementation of Pavlov/Oodle-like compression and helpers used across the project.
- **Tools & utilities**: Console readers, benchmarks and a WPF viewer for visual debugging.
- **Tests**: Unit tests covering decoding, replay parsing and format specifics.

---

## Quick Start

Prerequisites: .NET SDK 8.0 or 9.0

Clone and build:

```powershell
git clone https://github.com/your-org/PavlovReplayDecompressor.git
cd PavlovReplayDecompressor/src
dotnet build
```

Run unit tests:

```powershell
dotnet test ./PavlovReplayReader.Test/PavlovReplayReader.Test.csproj
```

Use the reader from code:

```csharp
using PavlovReplayReader;

var reader = new ReplayReader();
var replay = reader.ReadReplay("match.replay");
// Inspect events, players, and network packets from `replay`.
```

Or use the console tooling:

```powershell
cd src/ConsoleReader
dotnet run -- <path-to-replay>
```

---

## Project Layout

- `src/` — All C# projects (reader, tools, viewer, compression libs and tests)
- `PavlovDump/` — Dumps and SDK helpers used for reverse engineering and format references
- `docs/` — Documentation and reference files
- `README.md` — This file

---

## Documentation & Notes

Documentation and developer notes live in the `docs/` folder. See `docs/index.md` and the other pages for format details and protocol notes.

> Tip: `PavlovDump/` contains helpful dumps and Cpp SDK snippets when investigating packets or Unreal types.

---

## Contributing

Contributions welcome. Please open issues for bugs or feature requests, and create PRs for fixes or improvements. When contributing:

- Follow the existing style in `src/`
- Add or update unit tests when changing parsing/decoding behavior
- Keep changes small and reviewable

---

## Special thanks

Special thanks to [Kuinox](https://github.com/Kuinox/ChartsNite) for the collaboration to figure out the compression and structure of the replay file.

Special thanks to [ApertureC](https://github.com/ApertureC/) for the collaboration to figure out the UE4 network packets.

Special thanks to [AlpaGit](https://github.com/AlpaGit) for seeing the bits I did not see.

Special thanks to [SL-x-TnT](https://github.com/SL-x-TnT) for his amazing work on the NetFieldParser (among other things).

Special thanks to [SL-x-TnT](https://github.com/SL-x-TnT) because he deserves to be mentioned twice.

---

## License

Licensed under the **MIT License** — see `LICENSE` for details.

