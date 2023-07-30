using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDestructable : MonoBehaviour
{

    public float health = 1f;
    public GameObject explosion;
    public float explosion_scale = 1f;
    public bool destroyTrigger = false; // allows for instant destruction of the object

    // Update is called once per frame
    void Update()
    {
        if(destroyTrigger){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
    
        // if colliding with projectile, then reduce health
        if(other.gameObject.tag == "Projectile" || other.gameObject.tag == "PlayerProjectile"){

            // if type enemy, only listen for player Projectile
            if(gameObject.tag == "Enemy" && other.gameObject.tag != "PlayerProjectile"){return;}
            
            
            health -= 1.0f;
            // if health falls below 0, destroy the object
            if(health <= 0.0){

                // play explosion animation
                if(explosion != null){
                    GameObject destruction_animation = Instantiate(explosion, this.gameObject.transform.position, Quaternion.identity);
                    destruction_animation.transform.localScale *= explosion_scale; 
                }
                Destroy(this.gameObject);
            }
        }
    }


}
