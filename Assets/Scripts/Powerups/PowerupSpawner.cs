using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // Const
    // Increase of time for spawn per wave
    // Reduces number of powerup spawns
    private const float TIME_WAVE_MODIFIER = 5.0f;
    private GameObject[] _boundaries;

    // Private
    private Transform _xBoundary;
    private float _radius;
    private ActionTimer _timer;

    // Public
    public GameObject[] Prefabs;
    public float AreaReductionMod = 1; // 1 is no reduction

    private void Awake()
    {
    }

    // Start is called before the first frame update

    public void SpawnPowerup()
    {
        int len = Prefabs.Length;
        Vector3 newPosition = Random.insideUnitSphere * (_radius / AreaReductionMod);
        newPosition.y = 0;
        transform.position = newPosition;
        GameObject instance = Instantiate(Prefabs[(int)Random.Range(0, len)], transform.position, Quaternion.identity);
    }

    // Only need x or z since spawner uses circle area
    public Transform GetXBoundary()
    {
        _boundaries = GameObject.FindGameObjectsWithTag("Boundary");

        for (int i = 0; i< _boundaries.Length; i++)
        {
            if (_boundaries[i].name == "Boundary X+")
            {
                return _boundaries[i].transform;
            }
        }

        // No Boundary X+ found
        return null;
    }

    public void WavePowerupSpawn(int wave)
    {
        // +1 ensures no infinite spawn
        float time = (wave + 1) * TIME_WAVE_MODIFIER;
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
        _timer = new(5.0f);
        _timer.Pause();
        _xBoundary = GetXBoundary();
        _radius = _xBoundary.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        _timer.Update(Time.deltaTime);
        if (_timer.IsZero)
        {
            SpawnPowerup();
            _timer.Reset();
        }
    }
}
