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
        StartCoroutine(TimeDelayStart());
    }

    // Update is called once per frame
    void Update()
    {
        if(projectileChild == null && delayDone){
            // adds short delay to firing projectile
            Invoke("Shoot", Random.Range(1f,6f));
            delayDone = false;
        }
    }

    void Shoot(){

        // spawn projectile
        Vector3 spawnPosition = transform.TransformDirection(new Vector3(0,0,1f));
        projectileChild = Instantiate(projectilePrefab, transform.position, transform.rotation);
        
        // set flag to allow another projectile to fire
        delayDone = true;
    }

    // gives delay time before firing projectiles
    IEnumerator TimeDelayStart(){
        yield return new WaitForSeconds(delay);
        delayDone = true;
    }


}
