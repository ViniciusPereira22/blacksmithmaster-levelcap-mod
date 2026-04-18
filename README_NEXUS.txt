# Blacksmith Master - Level Cap Mod

BepInEx + Harmony mod that overrides staff max level values per class in **Blacksmith Master**.

## Features

- Per-class level caps:
  - Blacksmith
  - Support
  - Scholar
  - Cashier
  - Miner
  - Lumberjack
- Fallback `DefaultCap` for safety.
- Config values are clamped to a minimum of `1`.
- If a staff member is already above a newly lowered cap, current level is not reduced; the cap applies to future leveling checks.

## Default Values (This Release)

- `BlacksmithCap = 20`
- `SupportCap = 10`
- `ScholarCap = 15`
- `CashierCap = 15`
- `MinerCap = 15`
- `LumberjackCap = 20`
- `DefaultCap = 20`

## Requirements

- Blacksmith Master (Steam)
- BepInEx `5.4.23.5` (Unity Mono x64)

## Installation

1. Extract the archive into your game root folder.
2. Confirm this file exists:
   - `BepInEx/plugins/BlacksmithMaster.LevelCapMod.dll`
3. Launch the game once to generate config:
   - `BepInEx/config/vinic.blacksmithmaster.levelcap.cfg`

## Configuration

Config file:
- `BepInEx/config/vinic.blacksmithmaster.levelcap.cfg`

Keys:
- `Level Caps.DefaultCap`
- `Level Caps.BlacksmithCap`
- `Level Caps.MinerCap`
- `Level Caps.CashierCap`
- `Level Caps.SupportCap`
- `Level Caps.LumberjackCap`
- `Level Caps.ScholarCap`

## Compatibility

- Tested around **Update #13 (2026-02-23)** and nearby hotfixes.
- Uses Harmony (`0Harmony.dll`) from BepInEx (no separate Harmony install required).

## Notes

- This mod was originally made for personal use and later shared with the community.
- No guarantee of frequent updates.
- Source is public for community maintenance/forks.
- License: MIT

## GitHub / Source Code

- https://github.com/ViniciusPereira22/blacksmithmaster-levelcap-mod

## Permissions for Updates/Forks

You are allowed to fork, update, and adapt this mod for future game versions, as long as you reference me as the original mod/author.
