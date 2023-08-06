using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    // New Game
    public void NewGameButton()
    {
        // Delay scene load
        Invoke("ExecuteNewGameButton", 0.5f);
    }

    // New Game
    public void ExecuteNewGameButton()
    {
        SceneManager.LoadScene("MainAR");
        // Debug.Log("Main AR");
    }

    // High Scores
    public void HighScoresButton()
    {
        // Delay scene load
        Invoke("ExecuteHighScoresButton", 0.5f);
    }

    public void ExecuteHighScoresButton()
    {
        SceneManager.LoadScene("HighScores");
        Debug.Log("How To Play");
    }

    // How To Play
    public void HowToPlayButton()
    {
        // Delay scene load
        Invoke("ExecuteHowToPlayButton", 0.5f);
    }

    public void ExecuteHowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
        Debug.Log("How To Play");
    }

    // Main Menu
    public void MainMenuButton()
    {
        // Delay scene load
        Invoke("ExecuteMainMenuButton", 0.5f);
    }
    public void ExecuteMainMenuButton()
    { 
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Main Menu");
    }

    // Shooting Tutorial
    public void ShootingButton()
    {
        // Delay scene load
        Invoke("ExecuteShootingButton", 0.5f);
    }
    public void ExecuteShootingButton()
    {
        SceneManager.LoadScene("Shooting");
        Debug.Log("Shooting Tutorial");
    }

    // Obstacles Tutorial
    public void ObstaclesButton()
    {
        // Delay scene load
        Invoke("ExecuteObstaclesButton", 0.5f);
    }
    public void ExecuteObstaclesButton()
    {
        SceneManager.LoadScene("Obstacles");
        // Debug.Log("Obstacles Tutorial");
    }

    // Enemies Tutorial
    public void EnemiesButton()
    {
        // Delay scene load
        Invoke("ExecuteEnemiesButton", 0.5f);
    }
    public void ExecuteEnemiesButton()
    {
        SceneManager.LoadScene("Enemies");
        // Debug.Log("Enemies Tutorial");
    }

    // Powerups Tutorial
    public void PowerupsButton()
    {
        // Delay scene load
        Invoke("ExecutePowerupsButton", 0.5f);
    }
    public void ExecutePowerupsButton()
    {
        SceneManager.LoadScene("Powerups");
        // Debug.Log("Powerups Tutorial");
    }
}
