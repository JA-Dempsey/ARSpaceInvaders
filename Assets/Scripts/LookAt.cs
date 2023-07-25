using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
This class is provided to force a game object to look (aim) at the provided target
*/
public class LookAt : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        if(target != null){
            transform.LookAt(target.transform);
        }
    }
}
