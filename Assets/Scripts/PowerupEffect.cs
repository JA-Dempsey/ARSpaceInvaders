using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupEffect
{
    private string _name;
    private float _decay;     // -1 inf, 0 immediate
    private int _scale;

    private bool _isExpired = false;

    public PowerupEffect(string name, int scale, float decay)
    {
        _name = name;
        _decay = decay;
        _scale = scale;
    }

    public string Name { get; set; }
    public float Decay { get; set; }
    public int Scale { get; set; }

    public bool IsExpired { get; set; }

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
