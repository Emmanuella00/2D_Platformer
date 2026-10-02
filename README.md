# Unity 2D Platformer

## Overview
This project extends a starter 2D platformer built in Unity 6.5 (URP). The goal was to fix incomplete gameplay mechanics, resolve bugs, and add new features while keeping edits to the original scripts minimal. The final version includes a working Start menu, responsive HUD, a lives-and-respawn system managed by a custom `GameManager`, and an End scene with Replay and Quit options.

## Features
- **HUD & UI**
  - Life and coin text anchored top-left beside icons
  - Countdown timer (TextMeshPro) anchored top-right
  - Canvas Scaler set to *Scale With Screen Size* (1920×1080, match = 0.5)
- **Start Scene**
  - Background, Play, Settings, Quit buttons
  - Settings panel with volume slider, mute toggle, and controls reference
- **End Scene**
  - GAME OVER title, Replay and Quit buttons
- **Gameplay Fixes**
  - Camera follows player (`public Transform target;` kept as original)
  - Player movement: grounded check, horizontal axis input, spacebar jump
  - Respawn system: places player at closest point behind the fall
  - Water detection using `OnTriggerStay2D` for reliable respawn
- **Additional Features**
  - Countdown timer (180s, mm:ss format)
  - Respawn near pond instead of start
  - Controls reference in Settings

## Controls
- **A / D** or **← / →** — Move  
- **Space** — Jump  
- **J** — Shoot  


---

