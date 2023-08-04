using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomModel : MonoBehaviour
{

    public GameObject[] Prefabs;

    // Spawn a random prefab at start
    void Start()
    {
        int randomInt = Random.Range(0, Prefabs.Length);
        Instantiate(Prefabs[randomInt], transform);
    }

}
