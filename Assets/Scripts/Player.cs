using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;

public class Player : MonoBehaviour
{
    // Private

    // Bool Flags
    private bool _isAlive = true;

    // Public
    public int MaxHealth = 100;
    public int MinHealth = 0;
    public int MaxShield = 100;
    public int MinShield = 0;
    public int CriticalHealth = 50;
    public int CriticalShield = 0;

    public BaseResource Health;
    public BaseResource Shield;

    public bool IsAlive { get; set; }

    // Methods
    public void CheckHealth()
    {
        if (Health.IsZero)
            IsAlive = false;
    }

    // Unity Methods
    private void Awake()
    {
        Health = new(MinHealth, MaxHealth, CriticalHealth);
        Shield = new(MinShield, MaxShield, CriticalShield);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
