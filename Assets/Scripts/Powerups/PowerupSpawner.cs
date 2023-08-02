using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    private float _radius;
    private ActionTimer _timer;

    // Public
    public float SpawnTimer;
    public PowerupEffect[] Effects;
    public GameObject[] Prefabs;

    // Currently only one is needed for a radius
    // But others are included in case that changes in the future
    public GameObject MaxX;
    public GameObject MinX;
    public GameObject MaxZ;
    public GameObject MinZ;

    private void Awake()
    {
    }

    // Start is called before the first frame update

    public void SpawnPowerup()
    {
        int len = Prefabs.Length;
        Vector3 newPosition = Random.insideUnitSphere * _radius;
        newPosition.y = 0;
        transform.position = newPosition;
        GameObject instance = Instantiate(Prefabs[(int)Random.Range(0, len)], transform.position, Quaternion.identity);
    }


    void Start()
    {
        _timer = new(SpawnTimer);
        _timer.Start();
        _radius = MaxX.gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Is Timer Zero?: " + _timer.IsZero);
        _timer.Update(Time.deltaTime);
        if (_timer.IsZero)
        {
            Debug.Log("Timer is zero!");
            SpawnPowerup();
            _timer.Reset();
        }
    }
}
