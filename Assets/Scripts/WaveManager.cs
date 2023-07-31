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

    
    [SerializeField] private int wave = 0;
    private bool enemySpawnInitiated = false;
    private int delaySecondsBetweenWaves = 10;
    


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
            Invoke("hideText", delaySecondsBetweenWaves-1);
        }catch(NullReferenceException e){}

        // add delay to spawning next wave to give player time to prepare
        enemySpawner.Invoke("Spawn", delaySecondsBetweenWaves);
        debrisSpawner.Invoke("Spawn", delaySecondsBetweenWaves+1);

    }

    void hideText(){
        waveTextDisplay.text = "";
    }
    
}
