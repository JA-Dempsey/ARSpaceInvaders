using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{

    private Vector2 touchStartPosition;
    private float swipeThreshold = 100f;
    public GameObject confirmationScreen;
    private GameManager gameManager;


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

                    // 1. Show Confirmation Screen
                    ShowConfirmationScreen();
                }
            }
        }
    }

    public void ShowConfirmationScreen()
    {
        if (confirmationScreen != null)
        {
            //confirmationScreen.enabled = true;
            confirmationScreen.SetActive(true);
        }

        else
        {
            Debug.LogWarning("No image assigned to the script");
        }

        // 1. Set unity time to 0 to pause the game
        Time.timeScale = 0f;

        // Change the game state in the GameManager to GamePaused
        gameManager.UpdateState(GameState.GamePaused);
    }

    public void ReturnToMainMenu()
    {
       
        // 1. Delay scene load
        Invoke("ExecuteReturnToMainMenu", 0.5f);
    }

    public void ExecuteReturnToMainMenu()
    {
        // 1. Load Main Menu
        SceneManager.LoadScene("MainMenu");
        // Debug.Log("Returned to Main Menu");
    }

    public void ReturnToGame()
    {
        // Change the game state in the GameManager to GamePlay
        gameManager.UpdateState(GameState.GamePlay);

        // 1. Unpause Game
        Time.timeScale = 1f;

        // 2. Hide ConfirmationScreen
        HideConfirmationScreen();
    }

    public void HideConfirmationScreen()
    {
        if (confirmationScreen != null)
        {
            //confirmationScreen.enabled = false;
            confirmationScreen.SetActive(false);
        }

        else
        {
            Debug.LogWarning("No image assigned to the script");
        }
    }
}


