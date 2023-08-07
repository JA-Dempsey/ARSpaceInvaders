using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// Provides a random model from the given prefabs
///
public class RandomModel : MonoBehaviour
{

    public GameObject[] Prefabs;        //!< Array of prefabs to choose from

    // Spawn a random prefab at start
    void Start()
    {
        int randomInt = Random.Range(0, Prefabs.Length);
        Instantiate(Prefabs[randomInt], transform.position, transform.rotation, this.transform);
    }

}
