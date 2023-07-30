using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Possible effects
    public PowerupEffect Effect;
    private bool _printed = false;

    // Methods
    public void ApplyEffects()
    {
        
    }

    public void SelectEffect(PowerupEffect effect)
    {
        Effect = effect;
    }

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get Player component
        // Need to integrate Player and Powerups
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Selected Powerup: " + Effect.Name);
    }
}
