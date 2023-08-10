using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///
/// Class that flashes a RawImage also attached to the
/// GameObject with this script.
///
public class Flashing : MonoBehaviour
{
    public float flashingSpeed = 2.0f; //!< Speed of flashing
    public float minOpacity = 0.1f;    //!< The lowest alpha opacity for flash
    public float maxOpacity = 1.0f;    //!< The highest alpha opacity for flash

    private RawImage rawImage;
    private bool increasingOpacity = true;
    private float currentOpacity;

    private void Start()
    {
        rawImage = GetComponent<RawImage>();
        currentOpacity = maxOpacity;
    }

    private void Update()
    {
        // Calculate the new opacity based on time and flashingSpeed
        currentOpacity += (increasingOpacity ? 1 : -1) * Time.deltaTime * flashingSpeed;

        // Clamp opacity value to the defined range
        currentOpacity = Mathf.Clamp(currentOpacity, minOpacity, maxOpacity);

        // Apply the new opacity to the image
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, currentOpacity);

        // Toggle opacity is at the min or max value
        if (currentOpacity <= minOpacity || currentOpacity >= maxOpacity)
        {
            increasingOpacity = !increasingOpacity;
        }
    }
}
