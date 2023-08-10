using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///
/// A class that handles game pausing
///
public class GamePause : MonoBehaviour
{
    // Private
    private Vector2 touchStartPosition;
    private float swipeThreshold = 100f;
    private GameManager gameManager;
    public AudioSource musicSource;

    // Public
    public GameObject confirmationScreen; //!< A reference to a confirmation screen


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for touch input from user
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if touch started
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }

            // Check if touch ended
            if (touch.phase == TouchPhase.Ended)
            {
                Vector2 touchEndPosition = touch.position;

                // Calculate the swipe delta
                float swipeDelta = touchEndPosition.x - touchStartPosition.x;

                // Check if the swipe is valid
                if (Mathf.Abs(swipeDelta) > swipeThreshold && swipeDelta > 0)
                {
                    // Show Confirmation Screen
                    ShowConfirmationScreen();
                }
            }
        }
    }

    /// <summary>
    /// Shows the confirmation screen.
    /// </summary>
    public void ShowConfirmationScreen()
    {
        if (confirmationScreen != null)
        {
            confirmationScreen.SetActive(true);
        }

        else
        {
            Debug.LogWarning("No image assigned to the script");
        }

        // Pause the game and music
        musicSource.Pause();
        Time.timeScale = 0f;
        gameManager.UpdateState(GameState.GamePaused);
        Debug.Log("Game paused");
    }

    /// <summary>
    /// Returns to main menu.
    /// </summary>
    public void ReturnToMainMenu()
    {
        // Load Main Menu
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Returned to Main Menu");
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Returns to the game, hides the confirmation screen.
    /// </summary>
    public void ReturnToGame()
    {
        // Hide ConfirmationScreen
        HideConfirmationScreen();
    }

    /// <summary>
    /// Hides the confirmation screen if available.
    /// </summary>
    public void HideConfirmationScreen()
    {
        if (confirmationScreen != null)
        {
            confirmationScreen.SetActive(false);
        }

        else
        {
            Debug.LogWarning("No image assigned to the script");
        }

        // Pause the game and music
        musicSource.UnPause();
        Time.timeScale = 1f;
        gameManager.UpdateState(GameState.GamePlay);
        Debug.Log("Game unpaused");
    }
}


