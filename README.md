# Mobile Free Skating Game Starter

This repo contains a Unity starter template for a mobile free-skating game set in a massive mega park with ramps, gaps, drops, rails, and a cosmetic clothing system.

## Features
- Mobile-friendly skate movement
- Large park layout for skating and exploring
- Ramps and launch pads
- Drop/gap locations
- Rail grinding hooks
- Outfit/cosmetic color customization
- Save/load customization data
- Camera follow for mobile play

## Recommended Unity setup
- Unity 2022 LTS
- URP render pipeline
- Input System package
- TextMeshPro
- Cinemachine (optional but recommended)

## Repo structure
- `Assets/Game/Scripts/Player/PlayerSkater.cs`
- `Assets/Game/Scripts/Park/ParkBuilder.cs`
- `Assets/Game/Scripts/Park/RampTrigger.cs`
- `Assets/Game/Scripts/Park/GapTrigger.cs`
- `Assets/Game/Scripts/Park/GrindRail.cs`
- `Assets/Game/Scripts/Cosmetics/OutfitData.cs`
- `Assets/Game/Scripts/Cosmetics/OutfitManager.cs`
- `Assets/Game/Scripts/Cosmetics/CosmeticItem.cs`
- `Assets/Game/Scripts/UI/CosmeticMenu.cs`
- `Assets/Game/Scripts/Camera/FollowCamera.cs`

## Quick start
1. Create a new Unity 3D URP project.
2. Copy the files into your project under `Assets/Game/...`.
3. Create a simple player object with a `Rigidbody` and `PlayerSkater` script.
4. Create a ground object and attach `ParkBuilder` to an empty GameObject.
5. Add a follow camera with `FollowCamera` pointing at the player.
6. Add mesh renderers for shirt, pants, and shoes and assign them in `OutfitManager`.
7. Build a simple skate scene with ramps, rails, and a large flat base.

## Notes
This is a template, not a finished full production game. It gives you a valid starting point for a mobile skating game with a large park, movement, and cosmetics.

## Next upgrades
- trick system
- combo scoring
- grind state and balance system
- shop UI and unlocks
- character model variants
- more realistic physics tuning
