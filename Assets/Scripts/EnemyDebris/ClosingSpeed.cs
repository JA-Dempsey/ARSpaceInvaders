using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// Script that allows an object to move closer to another.
///
public class ClosingSpeed : MonoBehaviour
{
    public GameObject target;               //!< Terget to close in on
    public float velocity = 0.5f;           //!< Velocity to apply
    public float sidewaysVelocity = 2f;     //!< Sideways velocit to apply

    private Rigidbody rb;
    private float sidewaysMotionV;
    [SerializeField] private float crossVelocity;
    [SerializeField] private float distance;

    void Start(){
        rb = GetComponent<Rigidbody>();
        sidewaysMotionV = Random.Range(-sidewaysVelocity, sidewaysVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){return;}
        
        Vector3 direction = target.transform.position - transform.position;
        Vector3 motion = Vector3.Normalize(direction) * velocity;
        Vector3 cross = Vector3.Normalize(Vector3.Cross(Vector3.up, motion)) * sidewaysMotionV;

        rb.velocity = motion + cross;

        distance = direction.magnitude;
        crossVelocity = cross.magnitude;
    }
}
