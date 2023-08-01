using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonClick : MonoBehaviour
{
    public AudioSource buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        // Find the AudioSource component on the button
        buttonClick = GetComponent<AudioSource>();

        // Make sure the audio source is not playing at the start
        buttonClick.Stop();
        Debug.Log("Audio Stopped");
    }

    public void PlayOnClick()
    {
        // 1. Play Button Click Audio
        buttonClick.Play();
        Debug.Log("Button Clicked. Audio Started");
    }
}
