using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool _isPointed;
    private Vector3 _targetPos;

    public GameObject Target;
    public float Speed = 0.5f;

    public Vector3 TargetPos { get; set; }
    public bool IsPointed { get; set; }

    // Methods
    public void Look()
    {
        transform.LookAt(Target.transform);
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, Speed);
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
        TargetPos = Target.transform.position;
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
            Look(); // Remove/comment out to just move forward
            IsPointed = true;
        }

        Move();
        DestroyOutOfBounds();

    }
}
