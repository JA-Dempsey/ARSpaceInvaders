using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameExit : MonoBehaviour
{

    private Vector2 touchStartPosition;
    private float swipeThreshold = 100f;
    public GameObject confirmationScreen;

    // Start is called before the first frame update
    void Start()
    {
        
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
            confirmationScreen.SetActive(true);
        }

        else
        {
            Debug.LogWarning("No image assigned to the script");
        }
    }

    public void ExitGame()
    {
        // 1. Exit Game
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        // 1. Hide confirmation screen
        HideConfirmationScreen();
    }

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

    }
}
