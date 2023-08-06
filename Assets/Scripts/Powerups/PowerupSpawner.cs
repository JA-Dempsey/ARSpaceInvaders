using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // Const
    // Increase of time for spawn per wave
    // Reduces number of powerup spawns
    public float baseTimePerSpawn = 45f;
    public float timeWaveModifier = 5.0f;

    // Private
    private float _radius;
    private ActionTimer _timer;
    private ActionTimer _awaitBoundaries;

    // Public
    public GameObject SpawnCenter;
    public GameObject Boundaries;
    public GameObject[] Prefabs;
    public float AreaReductionMod = 1; // 1 is no reduction

    private void Awake()
    {
    }

    // Start is called before the first frame update

    public void SpawnPowerup()
    {
        int len = Prefabs.Length;
        Vector3 newPosition = SpawnCenter.transform.position + (Random.insideUnitSphere * (_radius / AreaReductionMod));
        newPosition.y = 0;
        transform.position = newPosition;
        GameObject instance = Instantiate(Prefabs[(int)Random.Range(0, len)], transform.position, Quaternion.identity);
    }

    public void WavePowerupSpawn(int wave)
    {
        // +1 ensures no infinite spawn
        float time = ((float) wave + 1) * timeWaveModifier + baseTimePerSpawn;
        SetTimer(time);
        ResumeTimer();
    }

    public void SetTimer(float timer)
    {
        _timer.Timer = timer;
        _timer.Reset();
    }

    public void PauseTimer()
    {
        _timer.Pause();
    }

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
