using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{

    public float delay = 5f;
    public GameObject projectilePrefab;
    private GameObject projectileChild;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(projectileChild == null){
            Vector3 spawnPosition = transform.TransformDirection(new Vector3(0,0,1f));
            projectileChild = Instantiate(projectilePrefab, spawnPosition, transform.rotation);
        }
    }
}
