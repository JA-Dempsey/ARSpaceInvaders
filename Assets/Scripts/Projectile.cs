using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.XR.Management;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool _isPointed;
    private bool _fired = false;

    public GameObject Target;
    public float Speed;

    // Getters/Setters
    public bool IsPointed { get; set; }
    public bool Fired { get; set; }

    public void SetTarget(GameObject target)
    {
        Target = target;
    }

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    // Methods
    public void Shoot()
    {

        // Multiplied by 10 to get into more acceptable speed range
        GetComponent<Rigidbody>().AddForce(transform.forward * 10 * Speed);
    }

    public void DestroyOutOfBounds()
    {
        // Assume play area floor is 0
        if (transform.position.y < 0)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    private void Awake()
    {
    }

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPointed)
        {
            // Rotation should likely be
            // handled at creation at the spawner/enemy
            transform.LookAt(Target.transform); // Remove/comment out to just move forward
            IsPointed = true;
        }

        Shoot();
        DestroyOutOfBounds();

    }
}
