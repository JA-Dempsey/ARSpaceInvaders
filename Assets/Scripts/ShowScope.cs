using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScope : MonoBehaviour
{
    public RawImage rawImage;

    void Start()
    {
        // Make sure the scope image is hidden at the start of game
        rawImage.gameObject.SetActive(false);

        // Call function after some time
        Invoke("ShowGunScope", 10f);
    }

    // Function to show the scope image
    private void ShowGunScope()
    {
        // Set the scope image to active
        rawImage.gameObject.SetActive(true);
    }
}
