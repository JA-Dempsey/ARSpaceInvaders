using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public int score = 0;
    public TMP_Text scoreText;
    private GameObject[] enemies;
    private int pointsPerEnemy = 10;
    private int lastEnemyCount = 0;

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
        scoreText.text = score.ToString();
    }

    // allows score to be incremented/decremented by some value
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
}
