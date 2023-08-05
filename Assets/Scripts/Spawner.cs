using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

/**
This script spawns game objects within a defined play region
It also sets up the game object scripts with the correct targets
*/
public class Spawner : MonoBehaviour
{

    public int numObjects = 1;
    public GameObject spawnTarget;
    public float maxDistanceFromTarget = 8f;
    public float minDistanceFromTarget = 2f;
    public float minY = 1f;


    public GameObject[] prefabs;
    public GameObject aimTarget;
    public bool trigger = false;

    void Start(){
        if(spawnTarget == null){
            spawnTarget = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // allow trigger tag to spawn more objects
        if(trigger){
            Spawn();
            trigger = false;
        }
    }

    void Spawn(){
        // enforce number of objects to be at least 1
        if(numObjects < 1){
            numObjects = 1;
        }

        // loop over and spawn a random object from the prefab list
        for(int i = 0; i< numObjects; i++){
            // give random position to the object
            Vector3 position = UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(minDistanceFromTarget, maxDistanceFromTarget) + spawnTarget.transform.position;

            position.y = Mathf.Max(position.y, Mathf.Abs(minY));

            // instantiate
            GameObject randomPrefab = prefabs[UnityEngine.Random.Range(0, prefabs.Length)];
            GameObject newObject = Instantiate(randomPrefab, position, Quaternion.identity, transform);

            // if aim target is provided, aim at the target
            if(aimTarget != null){
                try{
                    LookAt lookat_script = newObject.GetComponent<LookAt>();
                    if(lookat_script != null){
                        lookat_script.target = aimTarget;
                    }
                }catch(Exception e){}

                try{
                    ClosingSpeed closingSpeedSCript = newObject.GetComponent<ClosingSpeed>();
                    if(closingSpeedSCript != null){
                        closingSpeedSCript.target = aimTarget;
                    }
                }catch(Exception e){}
                
            }

        }

    }

}