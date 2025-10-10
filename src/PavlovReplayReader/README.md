# PavlovReplayReader - Clean Slate

This project has been reset to a clean slate for proper implementation of Pavlov VR replay parsing.

## Current Structure

### Core Files

- **PavlovReplayReader.cs** - Main replay reader class that extends `Unreal.Core.ReplayReader<PavlovReplay>`
  - Handles replay file loading and stream processing
  - Provides decrypt and decompress functionality
  - Contains stub methods for implementing packet parsing:
    - `OnChannelOpened` - Track actor channels
    - `OnChannelClosed` - Clean up channels
    - `OnNetDeltaRead` - Handle delta updates
    - `OnExportRead` - Process export groups (main game data)
    - `OnExternalDataRead` - Handle external data packets
    - `ReadEvent` - Parse replay events

- **PavlovReplayBuilder.cs** - Builder class for constructing the final replay object
  - Currently minimal, ready to implement data aggregation logic

- **Models/PavlovReplay.cs** - Main replay data model
  - Inherits from `Unreal.Core.Models.Replay`
  - Includes a basic `GameData` property (currently `object?`) for compatibility with existing code
  - Ready for additional Pavlov-specific properties

## What Was Removed

All old models and functionality have been removed to create a clean implementation foundation:
- `/Models/Events/` - Old event models (PlayerElimination, Stats, TeamStats, etc.)
- `/Models/NetFieldExports/` - Old export models (GameState, PlayerState, PlayerPawn, etc.)
- `/Models/Enums/` - Old enum definitions
- `/Exceptions/` - Old exception types
- `/Extensions/` - Old extension methods
- All other model files in `/Models/`

## Next Steps for Implementation

1. **Define NetFieldExport Models** - Create classes in `Models/NetFieldExports/` for each Pavlov game object
   - GameState - Overall game state
   - PlayerState - Player-specific state
   - PlayerPawn - Player character/avatar state
   - Weapons, Items, etc.

2. **Implement OnExportRead** - Add switch cases to process each export type

3. **Implement PavlovReplayBuilder** - Add data aggregation logic
   - Track channels and actors
   - Build player data
   - Build game events
   - Aggregate final replay object

4. **Define Event Models** - If needed, create event models in `Models/Events/`

5. **Add PavlovReplay Properties** - Add parsed data properties to the main model

## Audio Data

The `/Audio/` folder remains intact for voice chat processing if needed.

## Testing

Old test files in `PavlovReplayReader.Test` should be reviewed and updated or removed as the new implementation progresses.
