using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeHealth : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Reference to the Text for health
    private int health = 50;

    public void Start()
    {
        ChangeTextContent(health);
    }

    // Function to change the text
    public void ChangeTextContent(int newHealth)
    {
        if (textComponent != null)
        {
            textComponent.text = newHealth.ToString(); ;
        }
        else
        {
            Debug.LogWarning("Text component is not assigned.");
        }
    }
}
