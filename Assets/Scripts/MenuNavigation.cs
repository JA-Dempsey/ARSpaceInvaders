using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///
/// Class used for methods related to menu navigation.
///
public class MenuNavigation : MonoBehaviour
{
    /// <summary>
    /// Invokes function that loads the MainAR scene after
    /// a small delay.
    /// </summary>
    public void NewGameButton()
    {
        // Delay scene load
        Invoke("ExecuteNewGameButton", 0.5f);
    }

    /// <summary>
    /// Loads the MainAR scene for a new game.
    /// </summary>
    public void ExecuteNewGameButton()
    {
        SceneManager.LoadScene("MainAR");
        // Debug.Log("Main AR");
    }

    /// <summary>
    /// Invokes function that loads the HighScores scene after
    /// a small delay.
    /// </summary>
    public void HighScoresButton()
    {
        // Delay scene load
        Invoke("ExecuteHighScoresButton", 0.5f);
    }

    /// <summary>
    /// Loads the HighScores scene.
    /// </summary>
    public void ExecuteHighScoresButton()
    {
        SceneManager.LoadScene("HighScores");
        Debug.Log("How To Play");
    }

    /// <summary>
    /// Invokes function that loads the HowToPlay scene
    /// after a small delay.
    /// </summary>
    public void HowToPlayButton()
    {
        // Delay scene load
        Invoke("ExecuteHowToPlayButton", 0.5f);
    }

    /// <summary>
    /// Loads the HowToPlay scene.
    /// </summary>
    public void ExecuteHowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
        Debug.Log("How To Play");
    }

    /// <summary>
    /// Invokes function that loads the MainMenu scene
    /// after a small delay.
    /// </summary>
    public void MainMenuButton()
    {
        // Delay scene load
        Invoke("ExecuteMainMenuButton", 0.5f);
    }

    /// <summary>
    /// Loads the MainMenu scene.
    /// </summary>
    public void ExecuteMainMenuButton()
    { 
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Main Menu");
    }

    /// <summary>
    /// Invokes a function that loads the Shooting scene
    /// after a small delay.
    /// </summary>
    public void ShootingButton()
    {
        // Delay scene load
        Invoke("ExecuteShootingButton", 0.5f);
    }

    /// <summary>
    /// Loads the Shooting scene for a shooting tutorial.
    /// </summary>
    public void ExecuteShootingButton()
    {
        SceneManager.LoadScene("Shooting");
        Debug.Log("Shooting Tutorial");
    }

    /// <summary>
    /// Invokes a function that loads the Obstacles scene
    /// after a small delay.
    /// </summary>
    public void ObstaclesButton()
    {
        // Delay scene load
        Invoke("ExecuteObstaclesButton", 0.5f);
    }

    /// <summary>
    /// Loads the Obstacles scene for the tutorial.
    /// </summary>
    public void ExecuteObstaclesButton()
    {
        SceneManager.LoadScene("Obstacles");
        // Debug.Log("Obstacles Tutorial");
    }

    /// <summary>
    /// Invokes a function that loads the Enemies scene
    /// after a small delay.
    /// </summary>
    public void EnemiesButton()
    {
        // Delay scene load
        Invoke("ExecuteEnemiesButton", 0.5f);
    }

    /// <summary>
    /// Loads the Enemies scene for the tutorial.
    /// </summary>
    public void ExecuteEnemiesButton()
    {
        SceneManager.LoadScene("Enemies");
        // Debug.Log("Enemies Tutorial");
    }

    /// <summary>
    /// Invokes a function that loads the Powerups scene
    /// after a small delay.
    /// </summary>
    public void PowerupsButton()
    {
        // Delay scene load
        Invoke("ExecutePowerupsButton", 0.5f);
    }

    /// <summary>
    /// Loads the Powerup scene for the tutorial on powerups.
    /// </summary>
    public void ExecutePowerupsButton()
    {
        SceneManager.LoadScene("Powerups");
        // Debug.Log("Powerups Tutorial");
    }
}
