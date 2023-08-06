using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTimer
{

    private float _timer;
    private float _current;
    private bool _allowCountdown = false;
    private bool _isZero = false;

    public ActionTimer(float timer)
    {
        _timer = timer;
        _current = _timer;
    }

    public float Timer { get; set; }
    public bool IsZero { get; set; }
    public bool AllowCountdown { get; set; }

    public void Start()
    {
        AllowCountdown = true;
    }

    public void Pause()
    {
        AllowCountdown = false;
    }

    public void Reset()
    {
        _current = _timer;
        IsZero = false;
    }

    public void Update(float deltaTime)
    {
        if (AllowCountdown)
        {

            // Debug.Log("Current Timer Time: " + _current);
            _current -= deltaTime;
            if (_current < 0)
                _current = 0;  // Ensure non-negative

            if (_current == 0)
                IsZero = true;
        }
    }   
}
