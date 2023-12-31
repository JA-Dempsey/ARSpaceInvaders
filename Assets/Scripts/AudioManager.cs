using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///
/// A manager for audio that allows sounds/music to
/// exist throughout multiple scenes in Unity.
///
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip backgroundMusic; //!< Music to manage
    private AudioSource audioSource;

    private void Awake()
    {
        // The singleton pattern to allow audio to persist across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;
        if (sceneName == "MainMenu" || sceneName == "HighScores" || sceneName == "HowToPlay" || sceneName == "Shooting" || sceneName == "Obstacles" || sceneName == "Enemies" || sceneName == "Powerups")
        {
            PlayBackgroundMusic();
        }
        else
        {
            StopBackgroundMusic();
        }
    }

    private void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && audioSource != null && !audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }
    }

    private void StopBackgroundMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
    private void OnDestroy()
    {
        // Unregister the sceneLoaded event to prevent potential errors after AudioManager is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
