using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
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
        // Function to modify shields
    }

    // Unity
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        _powerupEffect = new("Shield", 20, 0);
        if (_powerupEffect.Decay == 0)
            IsImmediate = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

