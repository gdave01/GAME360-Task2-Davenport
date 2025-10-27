# GAME360-Task2-Davenport
# Task 2: Singleton Implementation

## Student Info
- Name: Gabe Davenport
- ID: 01164744

## Pattern: Singleton
### Implementation
    The singleton pattern was implemented in this project through the use of a gameManager script that was able to reach into other scripts and control the game flow. By using public functions defined in the other scripts combined with instances classified by the gameManager class, the gameManager was able to control player movement/shooting, enemy AI behavior, and UI elements (i.e. buttons, score, lives). Additionally, the singleton pattern can briefly be seen in the playerController script with the inclusion of Unity’s built-in audio components. Using the singleton pattern in this project helped reduce the complexity of scripts and increased code readability.

### Game Integration
    The singleton pattern is used throughout this project by creating a gameObject called gameManager and then assigning a script to it. The script attached to gameManager then serves as a central hub for the game’s logic processing since all other scripts communicate with gameManager in some capacity. Through the combination of public functions in other scripts and private gameManger class variables, gameManager is able to handle core logic ranging from player movement to refreshing the UI. Overall, the singleton pattern is used within this project to help alleviate file bloat for unnecessary scripts and to further increase code readability or discovery.

## Game Description
- Title: Space Adventure

- Controls: W- fly up
            A- fly left
            S- fly down
            D- fly right
            Left Click- fire missile

- Objective: Survive a horde of alien ships for as long as possible. Score points by defeating aliens and collecting asteriods.
             Similar to older arcade games like "Missile Command", there is no true win condition, just have fun and try to beat your own high score.

             Alien Ship = 50 points
             Asteroid = 20 points

             Player lives = 5

## Repository Stats
- Total Commits: 7
- Development Time: 18.5 hours

-----------------------------------------------------------------
# Task 3: Complete Patterns Integration

# Project Evolution
# Task 2 Foundation
- Singleton Pattern: GameManager, AudioManager
- Basic game with centralized management

## Task 3 Additions
## Observer Pattern
- EventManager for decoupled communication
- Events implemented: OnScoreChanged,
                      OnPlayerHealthChanged,
                      OnEnemyDefeated,
                      OnGameOver,
                      OnPowerUpCollected.
- Observers: UIManager

## State Machine Pattern
- Player States: Attacking, Moving, Idle
- Game States: Enhanced from Task 2
- State transitions: Player is in the Attacking state when firing missiles and a visual flash is indicated upon state      transition. Player is in a Moving state when input is detected along each axis, the visual indication is flames emerging from the ships engine and the audio indication is a hovering sound. Player is in an Idle state when no conditions are met (ex: not firing and zero axis input), this state has no visual or audio indicator.

### Key Integration Points
1. Score System: Singleton → Observer → UI
2. Player Actions: Input → State → Event → Audio
3. Game Flow: GameState → Events → Scene Changes

## Repository Statistics
- Total Commits: 17
- Task 3 Commits: 10
- Lines of Code: ~655
- Development Time: 20 Hrs 30 Mins

## How to Play
- Controls: W- fly up
            A- fly left
            S- fly down
            D- fly right
            Left Click- fire missile

- Objective: Survive a horde of alien ships for as long as possible. Score points by defeating aliens and collecting asteriods. Replenish HP by collecting scattered pill bottles left by prior expeditions.

             Similar to older arcade games like "Missile Command", there is no true win condition, just have fun and try to beat your own high score.

             Alien Ship = 50 points
             Asteroid = 10 points

             Player lives = 5

- New Features: Health pickups, 
                Enemy audio, 
                Improved enemy spawn locations,
                Game over menu,
                Replayable level.

-----------------------------------------------------------------