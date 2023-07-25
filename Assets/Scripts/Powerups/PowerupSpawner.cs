using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    // Public
    public PowerupEffect[] Effects;
    public GameObject[] Prefabs;

    private void Awake()
    {
    }

    // Start is called before the first frame update

    public void SpawnPowerup()
    {
        int len = Prefabs.Length;
        Vector3 newPosition = Random.insideUnitSphere * 5;
        newPosition.y = 0;
        transform.position = newPosition;
        GameObject instance = Instantiate(Prefabs[(int) Random.Range(0, len)], transform.position, Quaternion.identity);

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPowerup();  // Testing mass calls to program
    }
}
