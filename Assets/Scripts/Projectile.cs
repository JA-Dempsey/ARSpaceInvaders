using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

///
/// Handles a projectile when spawned, including straight movement
/// and collision with other objects in the game.
///
public class Projectile : MonoBehaviour
{
    // Private
    private ShootAudio _audio;

    // Public
    public float Speed = 10.0f; //!< The speed for the proectile

    /// <summary>
    /// Sets the speed of the projectile.
    /// </summary>
    /// <param name="speed">New speed for the projectile.</param>
    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    /// <summary>
    /// Adds velocity to the projectile via the Rigidbody
    /// of the object this script is attached to.
    /// </summary>
    public void Shoot()
    {
        // set velocity of the laser
        GetComponent<Rigidbody>().velocity = (transform.forward * Speed);
    }


    private void OnCollisionEnter(Collision other)
    {
        // enemy collision with enemy projectile (ignore)
        if(other.gameObject.tag == "Enemy" && gameObject.tag == "Projectile"){return;} // Projectiles ignore enemies
        else if (other.gameObject.tag == "Player" && gameObject.tag == "PlayerProjectile"){return;} // PlayerProjectiles ignore Player

        else{ // collision with anything else
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Must be attached to same object as the ShootAudio Script
        _audio = GetComponent<ShootAudio>();
        _audio.PlayRandomLaser(); // Play at start of projectile life
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
}
