using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    // Public
    public PowerupEffect[] Effects;
    public GameObject[] Prefabs;

    // Powerup Effects
    public void RestoreHealth()
    {
        
    }

    public void RestoreShield()
    {

    }

    private void Awake()
    {
    }

    // Start is called before the first frame update

    public void SpawnPowerup()
    {

        Vector3 newPosition = Random.insideUnitSphere * 5;
        newPosition.y = 0;
        transform.position = newPosition;
        GameObject instance = Instantiate(Prefabs[(int) Random.Range(0, 2)], transform.position, Quaternion.identity);

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPowerup();
    }
}
