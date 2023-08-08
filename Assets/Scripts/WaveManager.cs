using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

///
/// Script attached to WaveManager prefab that handles the waves for the game,
/// including when to spawn enemies, powerups, and debris.
///
public class WaveManager : MonoBehaviour
{
    // Private
    private bool enemySpawnInitiated = false;

    // Public
    public Spawner enemySpawner;            //!< Ref to enemy spawner
    public Spawner debrisSpawner;           //!< Ref to debris spawner
    public PowerupSpawner powerupSpawner;   //!< Ref to powerup spawner
    public TMP_Text waveTextDisplay;        //!< Ref to text box for displaying wave text
    public TMP_Text enemiesRemainingText;   //!< Ref to text for enemies remaining text on screen
    public Image waveTextbackground;        //!< Image for the background of the wave text

    public int wave = 0;                    //!< The current wave
    public int delayBetweenWaves = 10;      //!< The delay between waves
    

    // Start is called before the first frame update
    void Start()
    {
     wave = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        evaluateEnemies();
    }

    /// <summary>
    /// Evaluates enemies left and spawns a new wave when appropriate.
    /// </summary>
    void evaluateEnemies(){

        // count how many enemies are left        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int currentCount = enemies.Length;

        if(!enemySpawnInitiated && currentCount == 0){

            // set flag to track we are spawning
            enemySpawnInitiated = true;

            // call for new wave
            newWave();
        }
        

        if(currentCount > 0){            
            // reset flag once enemies are spawned
            enemySpawnInitiated = false;
            enemiesRemainingText.text = String.Format("Enemies Remaining: {0}", currentCount);
        }else{
            enemiesRemainingText.text = "";
        }

    }

    /// <summary>
    /// The actions necessary for a new wave. Includes
    /// the actual spawns of enemies, debries, and powerups.
    /// </summary>
    void newWave(){
        
        // display the UI element
        wave +=1;
        try{
            waveTextbackground.gameObject.SetActive(true);
            waveTextDisplay.text = string.Format("WAVE {0}\nGet Ready!", wave.ToString());
            Invoke("hideText", delayBetweenWaves-1);
        }catch(NullReferenceException e){}

        // spawn the objects
        SpawnEnemies(delayBetweenWaves);
        SpawnDebris(delayBetweenWaves+1);
        powerupSpawner.WavePowerupSpawn(wave);
    }

    /// <summary>
    /// Spawns enemies after a delay.
    /// </summary>
    /// <param name="delay">The delay before spawning enemies.</param>
    void SpawnEnemies(int delay){
        // add delay to spawning next wave to give player time to prepare
        enemySpawner.numObjects += 1;
        enemySpawner.Invoke("Spawn", delay);
        Invoke("UpdateDifficulty", delay+1);
    }

    /// <summary>
    /// Spawns debris after a delay.
    /// </summary>
    /// <param name="delay">The delay before spawning debris.</param>
    void SpawnDebris(int delay){
        const int MAX_DEBRIS = 7;

        // spawn debris
        GameObject[] debris = GameObject.FindGameObjectsWithTag("Debris");

        // limit number of debris in game
        debrisSpawner.numObjects = Mathf.Max(MAX_DEBRIS - debris.Length, 0);
        debrisSpawner.Invoke("Spawn", delay);
    }

    /// <summary>
    /// Updates the difficulty before the next wave.
    /// </summary>
    void UpdateDifficulty(){

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // update enemy difficulty based on wave
        for(int i = 0; i<enemies.Length; i++){
            GameObject enemy = enemies[i];

            // modify projectile speed based on difficulty
            SpawnProjectile projectileScript = enemy.GetComponent<SpawnProjectile>();
            projectileScript.overWriteSpeed = true;
            projectileScript.projectileSpeed = projectileScript.projectileSpeed + wave * 0.1f;

            // modify enemy speed based on difficulty
            ClosingSpeed closingScript = enemy.GetComponent<ClosingSpeed>();
            closingScript.sidewaysVelocity = closingScript.sidewaysVelocity + (wave*0.2f);
            closingScript.velocity = closingScript.velocity + (wave*closingScript.velocity*0.1f);
        }
    }

    void hideText(){

        waveTextbackground.gameObject.SetActive(false);
        waveTextDisplay.text = "";
    }
    
}
