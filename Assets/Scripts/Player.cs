using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.SceneManagement;

/// <summary>
/// Script that tracks Player information, and related entities.
/// This includes resources, such as energy, health, and shields, as well
/// as related UI updates.
/// </summary>
public class Player : MonoBehaviour
{

    // Bool Flags
    private bool _isAlive = true;

    // Public
    public int MaxHealth = 100;     //!< The max of the Health resource
    public int MinHealth = 0;       //!< The min of the Health resource
    public int MaxShield = 100;     //!< The max of the Shield resource
    public int MinShield = 0;       //!< The min of the Shield resource
    public int MaxEnergy = 3;       //!< The max of the Energy resource
    public int MinEnergy = 0;       //!< The min of the Energy resource
    public int CriticalHealth = 50; //!< Health resource critical threshold
    public int CriticalShield = 0;  //!< Shield resource critical threshold
    public int CriticalEnergy = 1;  //!< Energy resource critical threshold

    public GameObject Bunker;       //!< Reference to the Bunker

    // Flashing Panels
    public FlashPanels FlashPanels; //!< References to flash panels for hit indications

    // Text
    public TMP_Text HealthText;     //!< UI text for current health
    public TMP_Text EnergyText;     //!< UI text for current energy
    public TMP_Text ShieldText;     //!< UI text for current shield

    public int EnemyDamage = 10;    //!< Damage done when Player hit by enemy

    public BaseResource Health;     //!< BaseResource Class. Health Resource.
    public BaseResource Shield;     //!< BaseResource Class. Shield Resource.
    public BaseResource Energy;     //!< BaseResource Class. Energy Resource.

    public bool IsAlive { get; set; }   //!< Flag for if the player is alive.

    // Methods
    /// <summary>
    /// Checks if the player is alive.
    /// </summary>
    /// <returns>Returns IsAlive if player still alive</returns>
    public bool CheckHealth()
    {
        IsAlive = !Health.IsZero;
        return IsAlive;
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

    /// <summary>
    /// Calculates if damage to shield and health. Damage
    /// always hurts shield first, then health once shield is
    /// expended.
    /// </summary>
    /// <param name="damage">The damage the player takes</param>
    public void TakeDamage(int damage)
    {
        // damage shield first
        int tempShield = Shield.Current - damage;
        Shield.Decrease(damage);

        // if shield is in negative, give excess damage to health
        if (tempShield < 0)
        {
            Health.Decrease(Mathf.Abs(tempShield));
            FlashPanels.ShowRed();
        }
        else { FlashPanels.ShowBlue(); }

    }

    // Unity Methods
    private void Awake()
    {
        // Initialize
        Health = new(MinHealth, MaxHealth, CriticalHealth);
        Shield = new(MinShield, MaxShield, CriticalShield);
        Energy = new(MinEnergy, MaxEnergy, CriticalEnergy);

        Energy.Current = 1; // start with 1 energy

        CheckHealth();
    }

    // Collisions
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Handheld.Vibrate();
            TakeDamage(EnemyDamage);
            CheckHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    /// <summary>
    /// Spawns Bunker/Shield for player when they press the Energy icon
    /// </summary>
    public void SpawnBunker(){
        if(Energy.Current > 0){
            // spawns a bunker and reduces energy
            GameObject bunker = Instantiate(Bunker, transform.position + transform.forward * 1.5f, transform.rotation);
            bunker.transform.Rotate(90f, 0, 0);

            Energy.Decrease(1);
        }
    }


}
