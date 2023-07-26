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
    public float MovementSpeed = 0.1f;
    private float _time = 30;

    // Allow changing the Amount of movement via Unity Editor
    public float YMovement = 0.5f;

    // Setters/Getters
    public Vector3 Position { get; set; }

    public Quaternion Rotation { get; set; }

    public int Angle { get; set; }

    // Methods
    public void UpdateTime(float delta)
    {
        _time -= delta;

    }

    // Start is called before the first frame update
    void Start()
    {
        _rotation = new Quaternion();
        _position = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        Position = new Vector3(transform.position.x, Mathf.Sin((_time * MovementSpeed)) * YMovement, transform.position.z);
        transform.position = Position;

        UpdateTime(Time.deltaTime);

        transform.Rotate(new Vector3(0, RotationSpeed, 0) * Time.deltaTime);
    }
}
