using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


///
/// This script spawns game objects within a defined play region.
/// It also sets up the game object scripts with the correct targets.
///
public class Spawner : MonoBehaviour
{

    public int numObjects = 1;      //!< Number of objects to spawn
    public GameObject spawnTarget;  //!< Target of the spawn, a GameObject
    public Boundaries boundaries;   //!< The boundary prefab/script in the scene
    public bool spawnAtBoundary;    //!< Flag for whether to spawn at boundary
    [Range(1f, 4f)] public float boundaryOffset = 2f;  //!< Offset for boundary spawn
    public float minY = 1f;         //!< Minimum y value for spawn


    public GameObject[] prefabs;    //!< Array of prefabs to spawn
    public GameObject aimTarget;    //!< For enemies, the target they will shoot at
    public bool trigger = false;    //!< If true allows Spawn()

    private float radius;
    private float offset;

    void Start(){
        if(spawnTarget == null){
            spawnTarget = this.gameObject;
        }

        radius = boundaries.distanceFromOrigin;
        if(spawnAtBoundary){
            offset = -boundaryOffset;
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

    /// <summary>
    /// Loops through and selects a random object from the script's
    /// prefab list added in Unity's Editor, and spawns one of them.
    /// </summary>
    void Spawn(){
        // enforce number of objects to be at least 1
        if(numObjects < 1){
            numObjects = 1;
        }

        // loop over and spawn a random object from the prefab list
        for(int i = 0; i< numObjects; i++){
            // give random position to the object
            Vector3 position;
            if(spawnAtBoundary){
                position = UnityEngine.Random.onUnitSphere * (radius + offset)  + spawnTarget.transform.position;
            }else{
                position = UnityEngine.Random.insideUnitSphere * (radius + offset)  + spawnTarget.transform.position;
            }
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