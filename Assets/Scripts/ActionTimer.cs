using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// The ActionTimer is used during a game/update loop to
/// track time to zero for an action. Gives options for pausing and
/// reseting the timer.
///
public class ActionTimer
{
    private float _timer;
    private float _current;
    private bool _allowCountdown = false;
    private bool _isZero = false;

    /// <summary>
    /// Constructor for the ActionTimer class.
    /// </summary>
    /// <param name="time">The amount of time to use for the timer</param>
    public ActionTimer(float time)
    {
        _timer = time;
        _current = _timer;
    }

    public float Current { get; set; } //!< Current timer time
    public float Timer { get; set; } //!< The current set timer
    public bool IsZero { get; set; } //!< Flag, true if time = 0
    public bool AllowCountdown { get; set; } //!< Flag, true if not paused

    /// <summary>
    /// Starts the countdown of the timer.
    /// </summary>
    public void Start()
    {
        AllowCountdown = true;
    }

    /// <summary>
    /// Pauses the countdown of the timer.
    /// </summary>
    public void Pause()
    {
        AllowCountdown = false;
    }

    /// <summary>
    /// Resets current time to time Timer and resets affected
    /// flags.
    /// </summary>
    public void Reset()
    {
        _current = _timer;
        IsZero = false;
    }

    /// <summary>
    /// Update the current time given the time
    /// since the last update.
    /// </summary>
    /// <param name="deltaTime">The time since last update.</param>
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
