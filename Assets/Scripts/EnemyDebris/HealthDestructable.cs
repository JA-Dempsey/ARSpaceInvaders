using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
/// Script that allows the tracking for an object to be destroyed, and 
/// allows an explosion to occure when an object is destroyed
///
public class HealthDestructable : MonoBehaviour
{

    public float health = 1f;               //!< The health of each object
    public GameObject explosion;            //!< Ref to explosion object
    public float explosion_scale = 1f;      //!< The scale for the explosion
    public bool destroyTrigger = false;     //!< allows for instant destruction of the object
    public bool enableFade = true;          //!< Enables the fading for the explosion
    
    Renderer rend;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool hasRenderer;

    public AudioSource audioData;           //!< The audio for the explosion

    void Start(){
        try{
            rend = GetComponent<Renderer>();
            hasRenderer = true;
        }catch(MissingComponentException e){
            hasRenderer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyTrigger){
            DestroyObject();
        }        
    }

    /// <summary>
    /// Handle collisions for projectiles hitting the object attached to this
    /// script.
    /// </summary>
    /// <param name="other">The other object that collided.</param>
    private void OnCollisionEnter(Collision other) {
        
        // if colliding with projectile, then reduce health
        if(other.gameObject.tag == "Projectile" || other.gameObject.tag == "PlayerProjectile"){

            // if type enemy, only listen for player Projectile
            if(gameObject.tag == "Enemy" && other.gameObject.tag != "PlayerProjectile"){return;}
            
            
            health -= 1.0f;
            // if health falls below 0, destroy the object
            if(health <= 0.0){
                DestroyObject();
            }else if(audioData != null){
                    audioData.Play();
                }
        }
    }

    /// <summary>
    /// Destroyes the object and creates/starts the explosion animation.
    /// </summary>
    private void DestroyObject() {
        if(explosion != null){
            GameObject destruction_animation = Instantiate(explosion, this.gameObject.transform.position, Quaternion.identity);
            destruction_animation.transform.localScale *= explosion_scale; 
        }
        Destroy(gameObject);
    }

}
