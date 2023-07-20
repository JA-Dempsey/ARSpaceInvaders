using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
This class can be applied to objects that need randomized motion
*/

public class BoundedMotion : MonoBehaviour
{

    // public fields
    public float initial_velocity = 1.0f;

    // private fields
    private Rigidbody rb;
    [SerializeField] private Vector3 currentVelocity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 randomDirection = Random.onUnitSphere;
        rb.velocity = randomDirection * initial_velocity;
    }

    // Update is called once per frame
    void Update()
    {
        currentVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision other) {

        // if colliding with a boundary
        if(other.gameObject.tag == this.gameObject.tag || other.gameObject.tag == "Boundary" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Debris" || other.gameObject.tag == "Powerup"){

            // reflect off the boundary at the same velocity as entered
            Vector3 collision_normal = other.contacts[0].normal;
            Vector3 new_direction = Vector3.Reflect(currentVelocity.normalized, collision_normal);

            rb.velocity = new_direction * currentVelocity.magnitude;
        }

    }
}
