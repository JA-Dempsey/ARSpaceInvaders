using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPowerup : MonoBehaviour
{
    // Private
    private PowerupEffect _powerupEffect;
    // Public
    private Player _playerScript;


    // Flags
    private bool _isImmediate = false;

    // Setters/Getters

    public bool IsImmediate { get; set; }

    // Methods
    public void Effect()
    {
        _playerScript.RechargeEnergy(_powerupEffect.Scale);
    }

    // Unity
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        _powerupEffect = new("Energy", 20, 0);
        if (_powerupEffect.Decay == 0)
            IsImmediate = true;

        _playerScript = GameObject.Find("Player").GetComponent<Player>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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

