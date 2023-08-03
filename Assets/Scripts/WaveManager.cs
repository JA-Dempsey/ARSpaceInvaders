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
    public TMP_Text waveTextDisplay;

    
    private int wave = 0;
    private bool enemySpawnInitiated = false;
    private const int DELAY_SECONDS_BETWEEN_WAVES = 10;
    


    // Start is called before the first frame update
    void Start()
    {
        
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
            Invoke("hideText", DELAY_SECONDS_BETWEEN_WAVES-1);
        }catch(NullReferenceException e){}

        // add delay to spawning next wave to give player time to prepare
        enemySpawner.Invoke("Spawn", DELAY_SECONDS_BETWEEN_WAVES);
        SpawnDebris();
    }

    void SpawnDebris(){
        const int MAX_DEBRIS = 8;

        // spawn debris
        GameObject[] debris = GameObject.FindGameObjectsWithTag("Debris");

        // limit number of debris in game to 8
        debrisSpawner.numObjects = Mathf.Max(MAX_DEBRIS - debris.Length, 0);
        debrisSpawner.Invoke("Spawn", DELAY_SECONDS_BETWEEN_WAVES+1);
    }

    void hideText(){
        waveTextDisplay.text = "";
    }
    
}
