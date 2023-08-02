using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSubmitScoreBox : MonoBehaviour
{
    public GameObject submitScoreScreen;

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
