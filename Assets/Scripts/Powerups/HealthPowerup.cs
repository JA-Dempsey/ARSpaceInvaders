using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevelPhysics;

public class HealthPowerup : MonoBehaviour
{
    // Private
    private PowerupEffect _powerupEffect;

    // Public
    public GameObject PlayerObject;
    public Player Player;

    // Flags
    private bool _isImmediate = false;
    private bool _isFinished = false;
    private bool _buffed = false;

    // Setters/Getters

    public bool IsImmediate { get; set; }
    public bool IsFinished { get; set; }
    public bool Buffed { get; set; }

    // Methods
    public void CheckImmediate()
    {
        if (_powerupEffect.Decay == 0)
        {
            IsImmediate = true;
        }
    }
    public void Heal()
    {
        Player.HealHealth(_powerupEffect.Scale);
    }

    public void Decay(float time)
    {
        _powerupEffect.Decay -= time;
        if (_powerupEffect.Decay == 0)
            IsFinished = true;
    }

    // Unity
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        // Local Startup
        _powerupEffect = new("Health", 20, 0);
        if (_powerupEffect.Decay == 0)
            IsImmediate = true;

        // Interaction with other Unity Objects
        PlayerObject = GameObject.Find("Player");
        Player = PlayerObject.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        Debug.Log("Name of Collider: " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            //Heal();
            Destroy(gameObject);
            Debug.Log("Powerup Destroyed");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
