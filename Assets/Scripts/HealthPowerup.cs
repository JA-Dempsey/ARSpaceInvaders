using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevelPhysics;

public class HealthPowerup : MonoBehaviour
{
    // Private
    private PowerupEffect _powerupEffect;

    // Public
    public GameObject Player;

    // Flags
    private bool _isImmediate = false;

    // Setters/Getters

    public bool IsImmediate { get; set; }

    // Methods
    public void Immediate()
    {
        // Use Player Functions to heal
    }

    // Unity
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        _powerupEffect = new("Health", 20, 0);
        if (_powerupEffect.Decay == 0)
            IsImmediate = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
