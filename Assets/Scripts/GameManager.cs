using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Enum Based Game Manager

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateUpdated;

    // Make instance accessible anywhere in the game
    private void Awake()
    {
        Instance = this;
    }

    // Start of game
    private void Start()
    {
        UpdateState(GameState.GameStart);
    }

    // Check and update the state of the game
    public void UpdateState(GameState updatedState)
    {
        State = updatedState;

        switch (updatedState)
        {
            case GameState.GameStart:
                HandleGameStart();
                break;
            case GameState.SpawnEnemies:
                HandleSpawnEnemies();
                break;
            case GameState.GamePaused:
                HandleGamePaused();
                break;
            case GameState.GamePlay:
                HandleGamePlay();
                break;
            case GameState.LevelWon:
                HandleLevelWon();
                break;
            case GameState.GameWon:
                HandleGameWon();
                break;
            case GameState.GameLost:
                HandleGameLost();
                break;
            case GameState.GameQuit:
                HandleGameQuit();
                break;
        }

        // Alerts scripts/objects that the state of the game has changed
        OnGameStateUpdated?.Invoke(updatedState);
    }

    // Instructions for GameStart
    private void HandleGameStart()
    {
        // 1. Increment level (initial value = 0)
        // 2. Set player health to 100 %
        // 3. Set player lives to 3
        // 4. Set player shield strength to 100 %
        // 5. Set score to 0 if level is 1 else set to previous level score
        // 5. Load scene (with UI elements for health, lives, score, shield)
        // 6. Call next state
        UpdateState(GameState.SpawnEnemies);
    }

    // Instructions for SpawnEnemies
    private void HandleSpawnEnemies()
    {
        // 1. Spawn enemies in scene
        // 2. Set enemy health to 100 %
        // 3. Set enemy speed, movement parameters based on level difficulty
        // 4. Set up enemy tracker for offscreen locations
        // 5. Call next state
        UpdateState(GameState.GamePlay);
    }

    // Instructions for GamePaused
    private void HandleGamePaused()
    {
        // 1. Set unity time to 0
        Time.timeScale = 0f;
        // 2. Load Main Menu Scene
    }

    // Instructions for GamePlay
    private void HandleGamePlay()
    {
        // *  [This could be a loop. While health ok and enemies alive, enemies attack.]
        // 1. Check if player health is 0 %. If yes, go to step 2. If no, go to step 5.
        // 2. Check if lives > 0. If yes, go to step 3. If no, call UpdateState(GameState.GameLost);
        // 3. Decrement lives by 1
        // 4. Reset player health to 100 %
        // 4. Update lives value on screen
        // 5. Update health value on screen
        // 6. Update score value on screen

        // 7. Check if there are still enemies left. If yes, go to step 10. If no, go to step 8.
        // 8. Check if level is < 3. If yes go to step 9. If no, call UpdateState(GameState.GameWon);
        // 9. Call UpdateState(GameState.LevelWon); 
        // 10. Call HandleGamePlay()
        HandleGamePlay();
    }

    // Instructions for LevelWon
    private void HandleLevelWon()
    {
        // 1. Save player score to high scores page
        // 2. Show Level Won Menu with options to continue or pause
        // 3. Call next state on click UpdateState(GameState.GameStart) OR UpdateState(GameState.GamePause);
    }

    // Instructions for GameWon
    private void HandleGameWon() { }

    // Instructions for GameLost
    private void HandleGameLost()
    {
        // 1. Save player score to high scores page
        // 2. Decrement level by 1
        // 3. Show Game Lost Menu with options to retry or quit
        // 4. Call next state on click UpdateState(GameState.GameStart) OR UpdateState(GameState.GameQuit) 
    }

    // Instructions for GameQuit
    private void HandleGameQuit()
    {
        // 1. Quit Game
        Application.Quit();
    }

}

// Different possible game states
public enum GameState{
    GameStart = 0,
    SpawnEnemies = 1,
    GamePaused = 2,
    GamePlay = 3,
    LevelWon = 4,
    GameWon = 5,
    GameLost = 6,
    GameQuit = 7
}
