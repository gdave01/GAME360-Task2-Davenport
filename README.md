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