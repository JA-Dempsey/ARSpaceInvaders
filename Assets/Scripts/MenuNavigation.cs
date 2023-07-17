using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    // New Game
    public void NewGameButton() {

        SceneManager.LoadScene("MainAR");
        Debug.Log("Main AR");
    }

    // High Scores
    public void HighScoresButton()
    {
        SceneManager.LoadScene("HighScores");
        Debug.Log("High Scores");
    }

    // How To Play
    public void HowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
        Debug.Log("How To Play");
    }

    // Main Menu
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Main Menu");
    }
}
