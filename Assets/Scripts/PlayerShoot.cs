using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Public
    public GameObject PlayerProjectile;

    public void SpawnProjectile()
    {
        Instantiate(PlayerProjectile, transform.position, transform.rotation);
    }
}
