# BlacksmithMaster.LevelCapMod

BepInEx + Harmony mod that overrides max level per staff type.

## What it does
- Replaces `TavernData.StaffInfo.get_MaxLevel` with your configured cap per class.
- Uses one cap per staff type: Blacksmith, Miner, Cashier, Support, Lumberjack, Scholar.
- Uses `DefaultCap` as fallback.
- Invalid values are clamped to a minimum of `1`.
- If a character is already above a new lower cap, this mod does not reduce current level; it only affects future leveling checks.

## Vanilla progression context
- Workers gain `2` skill points per level-up.
- Vanilla worker classes have:
  - `2` skills: Support/Assistant
  - `3` skills: Cashier, Miner, Scholar
  - Blacksmith starts with `3` skills and can go to `4` after progression unlocks (for example clay/ceramics-related unlocks).
  - `4` skills: Lumberjack

In real saves, you may still see lower effective caps on some workers depending on game systems (for example, difficulty-related effects reported by players).

## Config file
`BepInEx\\config\\vinic.blacksmithmaster.levelcap.cfg`

## Default values used by this mod
This mod ships with defaults intentionally higher than the original game caps.

Current defaults:
- `BlacksmithCap = 20`
- `SupportCap = 10`
- `ScholarCap = 15`
- `CashierCap = 15`
- `MinerCap = 15`
- `LumberjackCap = 20`
- `DefaultCap = 20`

These defaults were chosen to maximize skill progression per class (more total level-ups, therefore more skill points available over time).

Keys:
- `Level Caps.DefaultCap`
- `Level Caps.BlacksmithCap`
- `Level Caps.MinerCap`
- `Level Caps.CashierCap`
- `Level Caps.SupportCap`
- `Level Caps.LumberjackCap`
- `Level Caps.ScholarCap`

## Compatibility
- Game version tested: around **Update #13: Staff management improvements** (published on **2026-02-23**) and close hotfixes.
- BepInEx version used: `5.4.23.5`.
- Harmony dependency: uses `0Harmony.dll` provided by BepInEx (no separate install required).

## Build
```powershell
dotnet build .\\ModProjects\\BlacksmithMaster.LevelCapMod\\BlacksmithMaster.LevelCapMod.csproj -c Release
```

## Install
Copy:
`ModProjects\\BlacksmithMaster.LevelCapMod\\bin\\Release\\net48\\BlacksmithMaster.LevelCapMod.dll`

To:
`BepInEx\\plugins\\BlacksmithMaster.LevelCapMod.dll`

## Author note
This mod was originally made for personal use and was later shared with the Blacksmith Master community.

At this time, I do not plan to actively maintain or frequently update it.
The repository is public so other people can update/fork it for future game versions, as long as they reference the original mod/author.

## License
MIT. See `LICENSE`.

