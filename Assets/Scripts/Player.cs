using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.SceneManagement;

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

    // Text
    public TMP_Text HealthText;
    public TMP_Text EnergyText;
    public TMP_Text ShieldText;

    // Camera Panels
    public FlashPanels FlashPanels;

    public int EnemyDamage = 10; // Damage done when Player hit by enemy

    public BaseResource Health;
    public BaseResource Shield;
    public BaseResource Energy;

    public bool IsAlive { get; set; }

    // Methods
    public bool CheckHealth()
    {
        return IsAlive = !Health.IsZero;
    }

    public void UpdateText()
    {
        try
        {
            HealthText.text = Health.Current.ToString();
            ShieldText.text = Shield.Current.ToString();
            EnergyText.text = Energy.Current.ToString();
        }
        catch (NullReferenceException e){ }
    }

    // Increase/Decrease Function Maps
    // Reduces complexity of calls from other objects
    // and provides methods to do other things if necessary
    public void TakeDamage(int damage)
    {
        // damage shield first
        int tempShield = Shield.Current - damage;
        Shield.Decrease(damage);
        
        // if shield is in negative, give excess damage to health
        if(tempShield < 0){
            Health.Decrease(Mathf.Abs(tempShield));
            FlashPanels.ShowRed();
        }
        else
        {
            FlashPanels.ShowBlue();
        }

    }

    public void HealHealth(int heal)
    {
        Health.Increase(heal);
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

    private void Start()
    {
        
    }

    // Collisions
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            TakeDamage(EnemyDamage);

            // exit scene if you die
            if(!CheckHealth()){
                SceneManager.LoadScene("SubmitHighScore");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        UpdateText();
        
    }


}
