using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

/// 
/// An Enum based Game Manager to track scene changes in Unity,
/// and to maintain anything that needs to cross scenes
/// 
public class GameManager : MonoBehaviour
{
    // Private
    private Player _player;

    // Public
    public static GameManager Instance;
    public GameState State; //!< A GameState Enum
    public static event Action<GameState> OnGameStateUpdated; //!< Event for updated GameState

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

    /// <summary>
    /// Check and update the state of the game.
    /// </summary>
    /// <param name="updatedState">The enum value for updated state.</param>
    public void UpdateState(GameState updatedState)
    {
        State = updatedState;

        // Alerts scripts/objects that the state of the game has changed
        OnGameStateUpdated?.Invoke(updatedState);
    }

    /// <summary>
    /// Instructions for game start.
    /// </summary>
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
        }

        // Update State
        UpdateState(GameState.GamePlay);
    }

    /// <summary>
    /// Instructions for GamePaused.
    /// </summary>
    private void HandleGamePaused()
    {
        // 1. Set unity time to 0
        Time.timeScale = 0f;

        // 2. Load Main Menu Scene
        SceneManager.LoadScene("MainMenu");

    }

    /// <summary>
    /// Instructions for GamePlay
    /// </summary>
    private void HandleGamePlay()
    {
        // Check if player health is 0 %, update state to game lost
        if (!_player.IsAlive)
        {
            UpdateState(GameState.GameLost);
        }

        // Continue calling HandleGamePlay()
        else
        {
            UpdateState(GameState.GamePlay);
        }       
    }

    /// <summary>
    /// Instructions for GameLost
    /// </summary>
    private void HandleGameLost()
    {
        // Check to see if high score, then load the correct scene
        ScoreManager scoreManager = GetComponent<ScoreManager>();
        HighScoreManager highScoreManager = GetComponent<HighScoreManager>();
        
        if(!highScoreManager.AtCapacity() || scoreManager.score > highScoreManager.LowestScore()){
            SceneManager.LoadScene("SubmitHighScore");
        }else{
            SceneManager.LoadScene("GameLost");
        }
    }

    /// <summary>
    /// Instructions for GameQuit
    /// </summary>
    private void HandleGameQuit()
    {
        // 1. Quit Game
        Application.Quit();
    }


    private void Update(){
        switch (State)
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
            case GameState.GameLost:
                HandleGameLost();
                break;
            case GameState.GameQuit:
                HandleGameQuit();
                break;
        }
    }
}

/// <summary>
/// An enum for all the possible game states.
/// </summary>
public enum GameState{
    GameStart = 0,
    GamePaused = 1,
    GamePlay = 2,
    GameLost = 3,
    GameQuit = 4,
    MainMenu = 5
}
