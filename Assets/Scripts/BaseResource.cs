using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// 
/// A class that tracks a resource for a player/unit,
/// and ways to update the resource.
/// 
public class BaseResource
{
    // Private
    private int _current;
    private int _max;
    private int _min;
    private int _critical;

    // Flags
    private bool _isZero;
    private bool _isCritical;

    /// <summary>
    /// Constructor for a BaseResource.
    /// </summary>
    /// <param name="min">Currently always 0</param>
    /// <param name="max">Max resource value</param>
    /// <param name="critical">Threshold under which resource is considered critical</param>
    public BaseResource(int min, int max, int critical)
    {
        _max = max;
        _current = max;
        _min = min;
        _critical = critical;

        CheckFlags();

    }

    /// <summary>
    /// The current value of the resource.
    /// Always positive.
    /// </summary>
    public int Current
    {
        get { return _current; }
        set
        {
            if (value < 0)
                _current = 0;  // Ensure non-negative
            else
                _current = value;
        }
    }

    /// <summary>
    /// The max possible values of the resource.
    /// Always positive.
    /// </summary>
    public int Max
    {
        get { return _max; }
        set
        {
            if (value < 0)
                _max = 0;  // Can't have negative resource
            else
                _max = value;
        }
    }

    /// <summary>
    /// The critical threshold value.
    /// Always positive.
    /// </summary>
    public int Critical
    {
        get { return _critical; }
        set
        {
            if (value < 0)
                _critical = 0; // Ensure non-negative
            else
                _critical = value;
        }
    }

    public bool IsZero { get; set; } //!< Flag. True if Current = 0
    public bool IsCritical { get; set; } //!< Flag. True if Current < Critical


    /// <summary>
    /// Checks that flags are correct based on current
    /// resource values.
    /// </summary>
    public void CheckFlags()
    {
        if (_current > 0)
            IsZero = false;
        else
            IsZero = true;

        if (_current <= _critical)
            IsCritical = true;
        else
            IsCritical = false;
    }

    /// <summary>
    /// Decrease the resource. Can't decrease below 0.
    /// </summary>
    /// <param name="decrease"></param>
    public void Decrease(int decrease)
    {
        _current -= decrease;
        if (_current < 0) // Ensure non-negative
            _current = 0;


        CheckFlags();
    }

    /// <summary>
    /// Increase the resource. Can't decrease above max.
    /// </summary>
    /// <param name="increase"></param>
    public void Increase(int increase)
    {
        _current += increase;
        if (_current > _max)
            _current = _max;

        CheckFlags();
    }


}
