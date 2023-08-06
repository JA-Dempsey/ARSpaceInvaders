using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WaveManager : MonoBehaviour
{

    public Spawner enemySpawner;
    public Spawner debrisSpawner;
    public PowerupSpawner powerupSpawner;
    public TMP_Text waveTextDisplay;

    
    public int wave = 0;
    private bool enemySpawnInitiated = false;
    public int delayBetweenWaves = 10;
    


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
        }

    }

    void newWave(){
        
        // display the UI element
        wave +=1;
        try{
            waveTextDisplay.text = string.Format("WAVE {0}\nGet Ready!", wave.ToString());
            Invoke("hideText", delayBetweenWaves-1);
        }catch(NullReferenceException e){}

        // spawn the objects
        SpawnEnemies(delayBetweenWaves);
        SpawnDebris(delayBetweenWaves+1);
        powerupSpawner.WavePowerupSpawn(wave);
    }

    void SpawnEnemies(int delay){
        // add delay to spawning next wave to give player time to prepare
        enemySpawner.numObjects += 1;
        enemySpawner.Invoke("Spawn", delay);
        Invoke("UpdateDifficulty", delay+1);
    }

    void SpawnDebris(int delay){
        const int MAX_DEBRIS = 4;

        // spawn debris
        GameObject[] debris = GameObject.FindGameObjectsWithTag("Debris");

        // limit number of debris in game to 8
        debrisSpawner.numObjects = Mathf.Max(MAX_DEBRIS - debris.Length, 0);
        debrisSpawner.Invoke("Spawn", delay);
    }

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
        
        waveTextDisplay.text = "";
    }
    
}
