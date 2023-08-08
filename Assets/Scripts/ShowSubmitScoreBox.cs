using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// Script that handles showing the proper screen when a score
/// is submitted.
///
public class ShowSubmitScoreBox : MonoBehaviour
{
    public GameObject submitScoreScreen;  //<! The submit score screen to set as active

    /// <summary>
    /// Shows the given submit score screen
    /// </summary>
    public void ShowSubmitScoreScreen()
    {
        if (submitScoreScreen != null)
        {
            submitScoreScreen.SetActive(true);
        }

        else
        {
            Debug.LogWarning("No image assigned to the script");
        }
    }

    /// <summary>
    /// Hides the given submit score screen
    /// </summary>
    public void HideSubmitScoreScreen()
    {
        if (submitScoreScreen != null)
        {
            submitScoreScreen.SetActive(false);
        }

        else
        {
            Debug.LogWarning("No image assigned to the script");
        }

    }
}
