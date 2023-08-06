using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAudio: MonoBehaviour
{

    public AudioSource Audio;
    public AudioClip[] LaserClips;

    // Play one of the chosen laser sounds at random
    // Gives variety when spammed
    public void PlayRandomLaser()
    {
        Audio.PlayOneShot(LaserClips[(int) Random.Range(0, LaserClips.Length)]);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!Audio)
            Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
