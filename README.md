# Thunder Raid

Compact 2D shoot‑em‑up built with Unity. The project contains player ships, multiple enemy types (including a boss), bullets, pooling, level spawning, scoring, audio, and basic UI.

## Key features
- Multiple enemy behaviours (`Enemy.cs`, `enemy_1.cs`, `Boss_1.cs`)
- Player implementations (`player1.cs`, `player2.cs`, `GameControl.cs`)
- Bullet system with player and enemy bullets (`basePlayerBullet.cs`, `lazerBullet.cs`)
- Object pooling (`poolManager.cs`, `bulletManger.cs`)
- Level design data and spawner (`LevelSpawnData.cs`, `levelDisigner.cs`)
- Game, menu, save and score management (`gameManager.cs`, `playGameManager.cs`, `menuManager.cs`, `saveManger.cs`, `showScore.cs`)
- Audio management (`AudioManager.cs`)
- Simple popup and shield systems (`popup.cs`, `shieldControl.cs`)

## Requirements
- Unity (open with Unity Hub). Project was developed for Unity 2019/2020+ — if you encounter API issues, try a matching LTS version.
- Visual Studio 2022 for script editing and debugging.
- Git (repository at `https://github.com/heimingtou/game_thunderRaid`)

## Quick start
1. Clone the repo:
   - git clone https://github.com/heimingtou/game_thunderRaid
2. Open the project in Unity Hub.
3. Open the relevant C# solution in Visual Studio 2022:
   - In Visual Studio, use __File > Open > Project/Solution__ to open the `.sln` if needed.
4. In Unity Editor press Play to run the game in the editor.
5. To debug in Visual Studio attach to Unity or use __Debug > Attach Unity Debugger__ (or set breakpoints and use __Debug > Start Debugging__ when launched from the editor integration).

## How to run & test
- Press Play in the Unity Editor.
- Use the on‑screen controls or configured input to control the player ship.
- Spawn and wave behaviour are managed by the level designer and spawn data classes.

## Project structure (important files)
- `Assets/script/Enemy/Enemy.cs` — base enemy behaviour (movement, health bar, shooting, death)
- `Assets/script/Enemy/enemy_1.cs`, `Assets/script/Enemy/Boss_1.cs` — concrete enemy types
- `Assets/script/player/player1.cs`, `Assets/script/player/player2.cs` — player behaviours
- `Assets/script/bullet/basePlayerBullet.cs`, `Assets/script/bullet/lazerBullet.cs` — bullets and damage
- `Assets/script/Manager/poolManager.cs` — object pooling utility
- `Assets/script/Manager/bulletManger.cs` — bullet spawn/management
- `Assets/script/data/LevelSpawnData.cs`, `Assets/script/data/levelDisigner.cs` — level configuration and spawns
- `Assets/script/Manager/gameManager.cs`, `Assets/script/Manager/playGameManager.cs` — game flow and state
- `Assets/script/Manager/saveManger.cs` — score/save handling
- `Assets/script/music/AudioManager.cs` — sound and SFX

## How to modify common behaviours
- Change enemy HP, damage, or shoot patterns:
  - Edit `Enemy.cs` for shared behaviour (HP, `takeDamage`, `die`, `shoot`, `FlyToPosition`).
  - Override or extend in `enemy_1.cs` and `Boss_1.cs`.
- Add new bullets:
  - Create prefab under `Assets` and hook it into `bulletPrefab` fields on enemy prefabs or via `bulletManger`.
- Tune pooling:
  - Update `poolManager.cs` sizes and prefab registration.

## Tips & notes
- Enemy movement uses DOTween (`transform.DOMove`) — ensure DOTween package is installed in the project.
- Health bar on enemies uses `blood` GameObject scale manipulation inside `Enemy.cs`.
- Many game hooks rely on singletons (e.g., `gameManager.instance`, `AudioManager.instance`, `saveManger.instance`) — be careful when refactoring.
- When disabling GameObjects, `Enemy.OnDisable()` calls `transform.DOKill()` to stop tweens bound to that transform.

## Troubleshooting
- Missing package errors: install DOTween (or other missing packages) via Unity Package Manager or import the plugin.
- Script compile errors: open the Console in Unity, follow the first error to fix cascading failures.
- Debugging: attach the Visual Studio Unity debugger for breakpoints in editor play mode.

## Contributing
- Fork, create a feature branch, and send pull requests.
- Keep changes focused (e.g., one feature/bugfix per PR).
- Run the game in the editor and ensure no console errors before PR.


## Contact / Maintainer
- Repository: `https://github.com/heimingtou/game_thunderRaid`
