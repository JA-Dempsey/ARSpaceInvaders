using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

/// 
/// Scripts that defines a powerup spawner and dictates how
/// powerups will spawn in the game
///
public class PowerupSpawner : MonoBehaviour
{
    // Const
    // Increase of time for spawn per wave
    // Reduces number of powerup spawns
    public float baseTimePerSpawn = 45f;    //!< Base timer for powerup spawns
    public float timeWaveModifier = 5.0f;   //!< Time modifier per wave

    // Private
    private float _radius;
    private ActionTimer _timer;
    private ActionTimer _awaitBoundaries;

    // Public
    public GameObject SpawnCenter;          //!< The GameObject at the center of the spawns
    public GameObject Boundaries;           //!< The boundary gameObject
    public GameObject[] Prefabs;            //!< Array of prefabs to spawn
    public float AreaReductionMod = 1;      //!< 1 Amount of area reduced from boundary. 1 is no reduction.

    private void Awake()
    {
    }

    /// <summary>
    /// Spawns a powerup based on the Spawncenter randomly.
    /// </summary>
    public void SpawnPowerup()
    {
        int len = Prefabs.Length;
        Vector3 newPosition = SpawnCenter.transform.position + (Random.insideUnitSphere * (_radius / AreaReductionMod));
        newPosition.y = 0;
        transform.position = newPosition;
        GameObject instance = Instantiate(Prefabs[(int)Random.Range(0, len)], transform.position, Quaternion.identity);
    }

    /// <summary>
    /// Sets the timer for the next powerup spawn and begins
    /// spawning powerups continuously.
    /// </summary>
    /// <param name="wave">The current spawn wave</param>
    public void WavePowerupSpawn(int wave)
    {
        // +1 ensures no infinite spawn
        float time = ((float) wave + 1) * timeWaveModifier + baseTimePerSpawn;
        SetTimer(time);
        ResumeTimer();
    }

    /// <summary>
    /// Set the timer for the powerup spawns and reset it.
    /// </summary>
    /// <param name="timer">The new time for the timer.</param>
    public void SetTimer(float time)
    {
        _timer.Timer = time;
        _timer.Reset();
    }

    /// <summary>
    /// Pause the Spawn Timer.
    /// </summary>
    public void PauseTimer()
    {
        _timer.Pause();
    }

    /// <summary>
    /// Resume the Spawn Timer.
    /// </summary>
    public void ResumeTimer()
    {
        _timer.Start();
    }

    void Start()
    {
        _timer = new(baseTimePerSpawn);
        _timer.Pause();
        _radius = Boundaries.GetComponent<Boundaries>().distanceFromOrigin; 
    }

    // Update is called once per frame
    void Update()
    {
            // update timer and if zero, spawn a powerup
            _timer.Update(Time.deltaTime);
            if (_timer.IsZero)
            {
                SpawnPowerup();

                // reset timer
                _timer.Reset();
            }
    }
}
