using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionTimer
{

    private float _time;
    private float _current;
    private bool _allowCountdown = false;
    private bool _isZero = false;

    /// <summary>
    /// Constructor for the ActionTimer class.
    /// </summary>
    /// <param name="time"></param>
    public ActionTimer(float time)
    {
        _time = time;
        _current = _time;
    }


    public float Time { get; set; }
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
        _current = _time;
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
