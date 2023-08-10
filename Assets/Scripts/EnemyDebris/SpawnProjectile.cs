using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// Spawns a projectile for the enemies.
///
public class SpawnProjectile : MonoBehaviour
{

    public float delay = 5f;                //!< Delay for firing projectile
    public GameObject projectilePrefab;     //!< Prefab of the projectile
    private GameObject projectileChild;
    private bool delayDone = false;         // Flag. If delay is finished.
    
    // allows projectiles to be spawned with different speed
    public bool overWriteSpeed = false;         //!< If speed should be overwritten
    public float projectileSpeed = 3f;          //!< The projectile speed

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
            Invoke("Shoot", Random.Range(1f,3f));
            delayDone = false;
        }
    }

    /// <summary>
    /// Shoots the projectile at the given speed at the player.
    /// </summary>
    void Shoot(){

        // spawn projectile
        Vector3 spawnPosition = transform.TransformDirection(new Vector3(0,0,1f));
        projectileChild = Instantiate(projectilePrefab, transform.position, transform.rotation);
        
        if(overWriteSpeed){
            projectileChild.GetComponent<Projectile>().Speed = projectileSpeed;
        }
        
        // set flag to allow another projectile to fire
        delayDone = true;
    }

    // gives delay time before firing projectiles
    IEnumerator TimeDelayStart(){
        yield return new WaitForSeconds(delay);
        delayDone = true;
    }


}
