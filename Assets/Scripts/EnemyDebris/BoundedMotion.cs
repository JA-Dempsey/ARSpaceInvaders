using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///
/// This class can be applied to objects that need randomized motion.
///
public class BoundedMotion : MonoBehaviour
{

    // public fields
    public float velocity = 1.0f;  //!< Velocity of bounded motion

    // private fields
    private Rigidbody rb;
    [SerializeField] private Vector3 currentVelocity;


    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomDirection = Random.onUnitSphere;
        rb.velocity = randomDirection * velocity;
        currentVelocity = rb.velocity;

    }

    // Update is called once per frame
    void Update()
    {
        // update velocity if it is changed via the variable
        if(velocity != currentVelocity.magnitude){
            rb.velocity = rb.velocity.normalized * velocity;
        }

        // store the last velocity for use elsewhere
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
