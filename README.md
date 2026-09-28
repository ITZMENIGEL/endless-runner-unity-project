# Endless Runner Unity Game

This repository contains a fresh endless runner game setup for Unity 2022.3 LTS.

## Requirements
- Unity 2022.3 LTS
- 3D template
- TextMeshPro installed in the project

## Setup
1. Open Unity Hub
2. Click Open and select this folder
3. Open the project with Unity 2022.3 LTS
4. In Unity: Window > Package Manager > TextMeshPro
5. Import TMP Essential Resources if not already installed
6. Create a new scene
7. Add the objects below
8. Add the scripts from `Assets/Scripts`
9. Press Play

## Controls
- A / D or Left / Right: change lanes
- W / Up / Space: jump
- R: restart after game over

## Scene setup
Create these objects in the new scene:
- Ground: Cube, scale (10, 1, 20), position (0, -1, 0)
- Player: Cube, position (0, 0.5, 0), add Rigidbody + BoxCollider
- Main Camera: position (0, 3, -5), rotation (20, 0, 0)
- ObstacleSpawner: empty object, add ObstacleSpawner script
- GameManager: empty object, add GameManager script
- Canvas: add ScoreText and GameOverText (TextMeshPro)

## Important notes
- Use TextMeshPro, not the old `Text` UI class
- Do not use `using UnityEngine.UI;` in this project
- If you see `CS0246` errors, remove any old `Text` references and use `TextMeshProUGUI`

## Included scripts
- PlayerController.cs
- ObstacleMove.cs
- ObstacleSpawner.cs
- GameManager.cs
- CameraFollow.cs

## Gameplay
- Infinite obstacle generation
- 3-lane movement
- Jumping and collision
- Score counter
- Game over and restart

## Scene references to assign in Inspector
- Player: add PlayerController
- GameManager: add GameManager
  - ScoreText -> drag score text object
  - GameOverText -> drag game over object
- ObstacleSpawner: add ObstacleSpawner
  - Obstacle Prefab -> drag prefab from `Assets/Prefabs`

## Prefab to create
Create an Obstacle prefab:
- Cube object with BoxCollider and Rigidbody
- Rigidbody: Uncheck Use Gravity, check Is Kinematic
- Tag: Obstacle
- Drag it into `Assets/Prefabs`

## Next steps
If you want, I can continue by adding:
- coin pickups
- sound effects
- start menu
- pause menu
- more advanced Subway Surfers style visuals