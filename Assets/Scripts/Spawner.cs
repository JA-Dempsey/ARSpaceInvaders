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
    public GameObject maxX;
    public GameObject maxY;
    public GameObject maxZ;
    public GameObject minX;
    public GameObject minY;
    public GameObject minZ;

    public GameObject[] prefabs;
    public GameObject aimTarget;

    public bool trigger = false;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        
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

        // collect min/max coordinates to use
        float[] x_coordinates = {getPosition(minX).x, getPosition(maxX).x};
        float[] y_coordinates = {getPosition(minY).y, getPosition(maxY).y};
        float[] z_coordinates = {getPosition(minZ).z, getPosition(maxZ).z};

        // loop over and spawn a random object from the prefab list
        for(int i = 0; i< numObjects; i++){
            // calculate a random position using min/max components
            float pos_x = Random.Range(x_coordinates[0], x_coordinates[1]);
            float pos_y = Random.Range(y_coordinates[0], y_coordinates[1]);
            float pos_z = Random.Range(z_coordinates[0], z_coordinates[1]);

            // give random position to the object
            Vector3 position = new Vector3(pos_x, pos_y, pos_z);

            // instantiate
            GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            GameObject newObject = Instantiate(randomPrefab, position, Quaternion.identity, transform);

            // if aim target is provided, aim at the target
            if(aimTarget != null){
                LookAt lookat_script = newObject.GetComponent<LookAt>();
                if(lookat_script != null){
                    lookat_script.target = aimTarget;
                }
            }

        }

    }

    // helper function to get the position of a game object
    Vector3 getPosition(GameObject obj){
        return obj.gameObject.transform.position;
    }

}