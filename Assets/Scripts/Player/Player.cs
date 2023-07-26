using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;

public class Player : MonoBehaviour
{
    // Private
    [SerializeField] private int _health = 100;
    [SerializeField] private int _shield = 100;
    private int _criticalHealth;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;

    // Bool Flags
    private bool _isAlive = true;
    private bool _isCritical = false;

    // Getters and Setters
    public int Health
    {
        get { return _health; }
        set
        {
            if (value < 0)  // Ensure non-negative value
                _health = 0;
            else
                _health = value;
        }
    }

    public int Shields
    {
        get { return _shield; }
        set
        {
            if (value < 0) // Ensure non-negative value
                _shield = 0;
            else
                _shield = value;
        }
    }

    public int CriticalHealth
    {
        get { return _criticalHealth; }
        set
        {
            if (value < 0) // Ensure non-negative
                _criticalHealth = 0;
            else
                _criticalHealth = value;
        }
    }

    public bool IsAlive { get; set; }
    public bool IsCritical { get; set; }

    public Vector3 Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public Quaternion Rotation
    {
        get { return _rotation; }
        set { _rotation = value; }
    }
    
    // Methods
    public void DamageHealth(int damage)
    {
        _health -= damage;
        if (_health < 0)  // Ensure no negative health
            _health = 0;
    }

    public void DamageShield(int damage)
    {
        _shield -= damage; // Ensure no negative shield
        if (_shield < 0)
            _shield = 0;
    }

    public void CheckHealth()
    {
        if (_health < 1)
            IsAlive = false;
        if (_health < CriticalHealth)
            IsCritical = false;
    }

    // Unity Methods
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
