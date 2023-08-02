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
    public int MaxEnergy = 3;
    public int MinEnergy = 0;
    public int CriticalHealth = 50;
    public int CriticalShield = 0;
    public int CriticalEnergy = 1;

    public BaseResource Health;
    public BaseResource Shield;
    public BaseResource Energy;

    public bool IsAlive { get; set; }

    // Methods
    public bool CheckHealth()
    {
        if (Health.IsZero)
            IsAlive = false;

        return IsAlive;
    }

    // Increase/Decrease Function Maps
    // Reduces complexity of calls from other objects
    // and provides methods to do other things if necessary
    public void DamageHealth(int damage)
    {
        Health.Decrease(damage);

        if (Health.IsZero)
            IsAlive = false;
    }

    public void HealHealth(int heal)
    {
        Health.Increase(heal);
    }

    public void DamageShield(int damage)
    {
        Shield.Decrease(damage);
    }

    public void RechargeShield(int recharge)
    {
        Shield.Increase(recharge);
    }

    public void DamageEnergy(int energy)
    {
        Energy.Decrease(energy);
    }

    public void RechargeEnergy(int energy)
    {
        Energy.Increase(energy);
    }


    // Unity Methods
    private void Awake()
    {
        // Initialize
        Health = new(MinHealth, MaxHealth, CriticalHealth);
        Shield = new(MinShield, MaxShield, CriticalShield);
        Energy = new(MinEnergy, MaxEnergy, CriticalEnergy);
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