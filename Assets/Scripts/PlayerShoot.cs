using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Script that fires the given projectile prefab
/// from the player.
/// 
public class PlayerShoot : MonoBehaviour
{
    // Public
    public GameObject PlayerProjectile;  //!< Prefab to fire from the player/character

    /// <summary>
    /// Spawns a projectile at the player with the player's current rotation.
    /// </summary>
    public void SpawnProjectile()
    {
        Instantiate(PlayerProjectile, transform.position, transform.rotation);
    }
}
