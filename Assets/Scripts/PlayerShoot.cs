using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Private
    private PlayerAudio _audio;

    // Public
    public GameObject PlayerProjectile;

    public void SpawnProjectile()
    {
        Instantiate(PlayerProjectile, transform.position, transform.rotation);
        _audio.PlayRandomLaser();
    }

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<PlayerAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                SpawnProjectile();
            }
        }
    }
}
