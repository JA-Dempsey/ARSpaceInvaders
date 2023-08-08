using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// Defines a Shield Powerup and the effect it has when
/// a player projectile or player collides with the powerup.
///
public class ShieldPowerup : MonoBehaviour
{
    // Private
    private PowerupEffect _powerupEffect;
    private Player _playerScript;

    // Public
    public int PowerupScale = 20;           //!< The amount of a resource the powerup gives


    // Flags
    private bool _isImmediate = false;

    // Setters/Getters

    public bool IsImmediate { get; set; }   //!< Flag. If powerup given immediately

    // Methods
    /// <summary>
    /// Effect when powerup is collected or shot at by the player.
    /// </summary>
    public void Effect()
    {
        _playerScript.Shield.Increase(_powerupEffect.Scale);
    }

    // Unity
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        _powerupEffect = new("Shield", PowerupScale, 0);
        if (_powerupEffect.Decay == 0)
            IsImmediate = true;

        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerProjectile")
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

