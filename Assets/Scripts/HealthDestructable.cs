using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDestructable : MonoBehaviour
{

    public float health = 1f;

    // Update is called once per frame
    void Update()
    {
        // if health falls below 0, destroy the object
        if(health <= 0.0){
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
    
        // if colliding with projectile, then reduce health
        if(other.gameObject.tag == "Projectile"){
            // TODO deduct projectile strength from object

        }
    }
}
