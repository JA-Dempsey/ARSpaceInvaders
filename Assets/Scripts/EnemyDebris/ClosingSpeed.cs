using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingSpeed : MonoBehaviour
{
    public GameObject target;
    public float velocity = 0.5f;

    private Rigidbody rb;
    private float sidewaysMotionV;
    private const float sidewaysMultiplier = -2f;
    [SerializeField] private float closingVelocity;
    [SerializeField] private float crossVelocity;
    [SerializeField] private float distance;

    void Start(){
        rb = GetComponent<Rigidbody>();
        sidewaysMotionV = Random.Range(-sidewaysMultiplier,sidewaysMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        Vector3 motion = Vector3.Normalize(direction) * velocity;
        Vector3 cross = Vector3.Normalize(Vector3.Cross(Vector3.up, motion)) * sidewaysMotionV;

        rb.velocity = motion + cross;

        distance = direction.magnitude;
        closingVelocity = motion.magnitude;
        crossVelocity = cross.magnitude;
    }
}
