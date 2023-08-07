using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevelPhysics;

///
/// Defines a Health Powerup and the effect it has when
/// a player projectile or player collides with the powerup.
///
public class HealthPowerup : MonoBehaviour
{
    // Private
    private PowerupEffect _powerupEffect;
    private Player _playerScript;

    // Public
    public int PowerupScale = 20;       //!< How much of a resource the powerup gives

    // Flags
    private bool _isImmediate = false;
    private bool _isFinished = false;
    private bool _buffed = false;

    // Setters/Getters

    public bool IsImmediate { get; set; }   //!< Flag. If powerup is given immediately
    public bool IsFinished { get; set; }    //!< Flag. If buff should be finished
    public bool Buffed { get; set; }        //!< Flag. If buff currently active

    // Methods
    /// <summary>
    /// Checks to make sure immediate flag is
    /// set when decay hits 0.
    /// </summary>
    public void CheckImmediate()
    {
        if (_powerupEffect.Decay == 0)
        {
            IsImmediate = true;
        }
    }

    /// <summary>
    /// Method that enacts the change to player when
    /// powerup is collected.
    /// </summary>
    public void Effect()
    {
        _playerScript.Health.Increase(_powerupEffect.Scale);
    }

    /// <summary>
    /// Reduces the decay timer for the powerup.
    /// </summary>
    /// <param name="time">Amount of time to reduce the decay timer by</param>
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
        _powerupEffect = new("Health", PowerupScale, 0);
        if (_powerupEffect.Decay == 0)
            IsImmediate = true;

        // Interaction with other Unity Objects
        // This is slow, but can be updated if we decide to go with
        // an instance controlled by the central game controller
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerProjectile")
        {
            Effect();
            Destroy(gameObject);
            Debug.Log("Powerup Destroyed");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
