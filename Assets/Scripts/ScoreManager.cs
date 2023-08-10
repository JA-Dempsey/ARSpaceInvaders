using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

///
/// Manager for the score in the game. Adds score based on
/// number of enemies killed.
///
public class ScoreManager : MonoBehaviour
{

    public int score = 0; //!< Initial score
    public TMP_Text scoreText; //!< Text for the score

    private GameObject[] enemies;  // Array of enemies
    private int pointsPerEnemy = 10;  // Points given per enemy
    private int lastEnemyCount = 0;  // Used for calculations, this number is given as enemies after last enemy death

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        // check for loss of enemies
            evaluateEnemies();

        // update the score text 
        try{
            scoreText.text = score.ToString();
        }catch(NullReferenceException e){}
    }

    /// <summary>
    /// Allows score to be incremented/decremented by some value.
    /// </summary>
    /// <param name="value">Value to increment/decrement (- to decrement)</param>
    /// <returns>Returns the current score</returns>
    public int addScore(int value){
        score += value;

        return score;
    }

    // gives points for destroyed enemies
    private void evaluateEnemies(){
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        int currentCount = enemies.Length;
        int difference = lastEnemyCount - currentCount;

        // make sure difference is positive
        // if negative that means we added enemies
        if(difference > 0){
            // give 100 points for each enemy killed
            addScore(difference * pointsPerEnemy);
        }

        lastEnemyCount = currentCount;
    }

    private void OnDestroy() {
        // on Destroy, set the lastScore in order to use it externally
        PlayerPrefs.SetInt("lastScore", score);
    }
}
