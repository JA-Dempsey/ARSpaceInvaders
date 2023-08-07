using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// Script that plays one of the prefabs allocated to
/// the script, at the object this script is attached to.
///
public class ShootAudio: MonoBehaviour
{

    public AudioSource Audio;
    public AudioClip[] LaserClips;

    /// <summary>
    /// Play one of the chosen laser sounds at random for more
    /// variety.
    /// </summary>
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
