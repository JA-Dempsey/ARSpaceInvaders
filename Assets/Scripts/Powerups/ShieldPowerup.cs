using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    // Private
    private PowerupEffect _powerupEffect;
    // Public
    public GameObject PlayerObject;
    public Player PlayerScript;


    // Flags
    private bool _isImmediate = false;
    private Component _playerScript;

    // Setters/Getters

    public bool IsImmediate { get; set; }

    // Methods
    public void Effect()
    {
        PlayerScript.RechargeShield(_powerupEffect.Scale);
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

        PlayerScript = PlayerObject.GetComponent<Player>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Effect();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

