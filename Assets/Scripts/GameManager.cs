using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

// Enum Based Game Manager

public class GameManager : MonoBehaviour
{
    // Private
    private Player _player;

    // Public
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateUpdated;

    public int playerHealth;
    public int playerShield;
    public int playerPowerup;
    public int enemiesCount;


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
            case GameState.GamePaused:
                HandleGamePaused();
                break;
            case GameState.GamePlay:
                HandleGamePlay();
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
        // Check if game was paused
        if (Time.timeScale == 0f)
        {
            // Set unity time to 1
            Time.timeScale = 1f;
        }

        else 
        {
            // Set starting game parameters...pull values from other scripts instead of hardcoding

            // Get Player Script from Player Object
            // Defaults set within Editor for vitals/resources
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            // This is likely dealt within objects/wave manager
            // playerPowerup = 0;
            // enemiesCount = 5;
        }

        // Update State
        UpdateState(GameState.GamePlay);
    }

    // Instructions for GamePaused
    private void HandleGamePaused()
    {
        // 1. Set unity time to 0
        Time.timeScale = 0f;

        // 2. Load Main Menu Scene
        SceneManager.LoadScene("MainMenu");

    }

    // Instructions for GamePlay
    private void HandleGamePlay()
    {
        // Check if player health is 0 %, update state to game lost
        if (!_player.IsAlive)
        {
            UpdateState(GameState.GameLost);
        }

        // Check if there are still enemies left, update state to game won
        else if (enemiesCount == 0)
        {
            UpdateState(GameState.GameWon);
        }

        // Continue calling HandleGamePlay()
        else
        {
            UpdateState(GameState.GamePlay);
        }       
    }

    // Instructions for GameWon
    private void HandleGameWon()
    {
        // 1. Load Game Won Scene with options to save high score or return to main menu
        SceneManager.LoadScene("SubmitHighScore");
    }

    // Instructions for GameLost
    private void HandleGameLost()
    {
        // 1. Load Game Lost Scene with options to retry or return to main menu
        SceneManager.LoadScene("GameLost");
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
    GamePaused = 1,
    GamePlay = 2,
    GameWon = 3,
    GameLost = 4,
    GameQuit = 5
}
