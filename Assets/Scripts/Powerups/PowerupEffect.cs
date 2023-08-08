using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupEffect
{
    private string _name;
    private float _decay; // -1 inf, 0 immediate
    private int _scale;

    private bool _isExpired = false;

    /// <summary>
    /// Constructor for the PowerupEffect class.
    /// </summary>
    /// <param name="name">Name of effect.</param>
    /// <param name="scale">How much of the effect powerup has</param>
    /// <param name="decay">How long before the effect ends</param>
    public PowerupEffect(string name, int scale, float decay)
    {
        Name = name;
        Decay = decay;
        Scale = scale;
    }

    public string Name { get; set; }
    public float Decay { get; set; } //!< How long the powerup will/should last
    public int Scale { get; set; }  //!< Affect powerup has on player/character

    public bool IsExpired { get; set; }  //!< Flag, if powerup should be expired

    /// <summary>
    /// Updates the timer for the decay by the given time.
    /// </summary>
    /// <param name="elapsedTime">Reduce timer by this amount</param>
    public void UpdateDecay(float elapsedTime)
    {
        Decay -= elapsedTime;
        if (Decay <= 0)
        {
            Decay = 0; // Ensure non-negative
            IsExpired = true;
        }

    }
}