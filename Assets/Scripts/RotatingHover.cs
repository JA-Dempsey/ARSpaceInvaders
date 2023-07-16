using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingHover : MonoBehaviour
{
    private Quaternion _rotation;
    private Vector3 _position;
    private int _angle;

    // Allow changing speed of movement via Unity Editor
    public float RotationSpeed = 20.0f;
    public float MovementSpeed = 1.0f;

    // Allow changing the Amount of movement via Unity Editor
    public float YMovement = 0.5f;

    // Setters/Getters
    public Vector3 Position { get; set; }

    public Quaternion Rotation { get; set; }

    public int Angle { get; set; }

    // Methods

    // Start is called before the first frame update
    void Start()
    {
        _rotation = new Quaternion();
        _position = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        Position = new Vector3(0, Mathf.Sin(Time.time * MovementSpeed) * YMovement, 0);
        transform.position = Position;

        transform.Rotate(new Vector3(0, RotationSpeed, 0) * Time.deltaTime);
    }
}
