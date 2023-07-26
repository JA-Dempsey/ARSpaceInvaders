using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    // Public
    public PowerupEffect[] Effects;
    
    public GameObject PrefabPowerup;



    // Powerup Effects
    public void RestoreHealth()
    {
        
    }

    public void RestoreShield()
    {

    }

    private void Awake()
    {
        Effects = new PowerupEffect[10];

        Effects[0] = new("Health", 20, 0);
    }
    // Start is called before the first frame update

    public void SpawnPowerup()
    {

        Vector3 newPosition = Random.insideUnitSphere * 5;
        newPosition.y = 0;
        transform.position = newPosition;
        GameObject instance = Instantiate(PrefabPowerup, transform.position, Quaternion.identity);
        var test = instance.GetComponent<Powerup>();
        test.SelectEffect(Effects[0]);

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
