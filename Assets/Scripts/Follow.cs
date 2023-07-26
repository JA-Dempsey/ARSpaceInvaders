using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private bool _isDebug = true;

    public Transform FollowObject;
    public Vector3 Offset = new Vector3(0, 0, 0);

    public bool isDebug { get; set; }

    public void Move()
    {
        transform.position = FollowObject.position + Offset;
        transform.rotation = FollowObject.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        // Print location to Console for simple debug
        Debug.Log("Position: " + transform.position);
        Debug.Log("Rotation: " + transform.rotation);

    }
}
