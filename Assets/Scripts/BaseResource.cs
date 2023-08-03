using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    // Constructor
    public BaseResource(int min, int max, int critical)
    {
        _max = max;
        _current = max;
        _min = min;
        _critical = critical;

        CheckFlags();

    }

    // Getters/Setters
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

    public bool IsZero { get; set; }
    public bool IsCritical { get; set; }


    // Methods/Functions
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

    public void Decrease(int decrease)
    {
        _current -= decrease;
        if (_current < 0) // Ensure non-negative
            _current = 0;

        CheckFlags();
    }

    public void Increase(int increase)
    {
        _current += increase;
        if (_current > _max)
            _current = _max;

        CheckFlags();
    }


}
