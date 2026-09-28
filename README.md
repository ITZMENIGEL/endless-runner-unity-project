# Endless Runner Game

This project is a simple endless runner inspired by subway-style lane runners.

It includes:
- 3-lane movement
- jump mechanic
- obstacle spawning
- coin collection
- score system
- game over + restart
- camera follow

## Requirements
- Unity 2022.3 LTS
- 3D template

## Install TextMeshPro
1. Open the project in Unity
2. Go to `Window > Package Manager`
3. Set the package source to `Unity Registry`
4. Search for `TextMeshPro`
5. Click `Install`
6. Then go to `Window > TextMeshPro > Import TMP Essential Resources`

## Scene Setup
1. Create a new scene
2. Add a `Ground` cube: position `(0, -1, 0)`, scale `(10, 1, 20)`
3. Add a `Player` cube: position `(0, 0.5, 0)`
4. Add `Rigidbody` to the Player
   - uncheck `Use Gravity`
   - freeze rotation X/Y/Z
5. Add `BoxCollider` to Player
6. Add `Main Camera` and set position `(0, 3, -5)`, rotation `(20, 0, 0)`
7. Add an empty object named `ObstacleSpawner`
8. Add an empty object named `GameManager`
9. Add a `Canvas`
   - Add a `TextMeshPro - Text` object named `ScoreText`
   - Add another `TextMeshPro - Text` object named `GameOverText`
   - Set `GameOverText` inactive at first
10. Create an obstacle prefab:
   - cube with BoxCollider + Rigidbody
   - set Rigidbody `Use Gravity` off and `Is Kinematic` on
   - tag object `Obstacle`
   - drag into `Assets/Prefabs`
11. Create a coin prefab:
   - cylinder or cube with collider
   - tag `Coin`
   - add `CoinPickup` script
   - drag into `Assets/Prefabs`

## Script Attachments
- Player object: add `PlayerController`
- ObstacleSpawner: add `ObstacleSpawner`
  - assign obstacle prefab
  - assign coin prefab
- GameManager: add `GameManager`
  - assign `ScoreText`
  - assign `GameOverText`
  - assign `Player` if needed
- Main Camera: add `CameraFollow`
  - assign Player transform

## Controls
- `A / D` or `Left / Right`: switch lanes
- `W / Up / Space`: jump
- `R`: restart after game over

## Notes
- Do not use the old `Text` UI class.
- Use `TextMeshProUGUI` only for score and game over text.
- If you still see missing namespace errors, install TextMeshPro and delete the `Library` folder once, then reopen the project.

## Included scripts
- `PlayerController.cs`
- `GameManager.cs`
- `ObstacleSpawner.cs`
- `CoinPickup.cs`
- `CameraFollow.cs`
- `ObstacleMove.cs`

## Future upgrades
This project can be extended with:
- start menu
- pause menu
- sound effects
- power-ups
- animated environment
- better graphics
