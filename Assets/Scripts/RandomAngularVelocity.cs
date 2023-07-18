using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAngularVelocity : MonoBehaviour
{

    public float upperBound = 1f;
    public float lowerBound = 0.1f;
    private Rigidbody rb;
    [SerializeField] private Vector3 rotationVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(
            Random.Range(lowerBound, upperBound),
            Random.Range(lowerBound, upperBound),
            Random.Range(lowerBound, upperBound)
        );
    }

    // Update is called once per frame
    void Update()
    {
        // limit the max rotational speed
        rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, upperBound);
    }

}
