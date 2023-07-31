using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{

    public float delay = 5f;
    public GameObject projectilePrefab;
    private GameObject projectileChild;
    private bool delayDone = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if(projectileChild == null){
            Vector3 spawnPosition = transform.TransformDirection(new Vector3(0,0,1f));
            projectileChild = Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }

    // gives delay time before firing projectiles
    IEnumerator TimeDelay(){
        yield return new WaitForSeconds(delay);
        delayDone = true;
    }
}
