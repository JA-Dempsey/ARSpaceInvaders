using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float Speed = 10.0f;

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    // Methods
    public void Shoot()
    {

        // set velocity of the laser
        GetComponent<Rigidbody>().velocity = (transform.forward * Speed);
        
        // GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
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

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
}
