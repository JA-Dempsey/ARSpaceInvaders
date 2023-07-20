using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    private PowerupEffect _powerupEffect;

    private void Awake()
    {
        _powerupEffect = new("Health", 20, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PowerupEffect: " + _powerupEffect.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
