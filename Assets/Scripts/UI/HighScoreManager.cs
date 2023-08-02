using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
        private HighScores highScores;
    private const int TOTAL_TRACKED_SCORES = 10;

    void Awake(){
        // load high scores and store into highScores
        var json = PlayerPrefs.GetString("scores", "{}");
        highScores = JsonUtility.FromJson<HighScores>(json);
    }

    // returns list of scores
    public IEnumerable<ScoreEntry> GetHighScores(){
        return highScores.scores;
    }

    /**
    Adds a score entry and sorts the list and prunes the excess
    */
    public void AddScore(ScoreEntry score){
        // add a score to the high scores and sorts it to prepare for pruning
        highScores.scores.Add(score);
        highScores.scores.Sort();

        while(highScores.scores.Count > TOTAL_TRACKED_SCORES){
            // remove the last item if it exceeds the max    
            highScores.scores.RemoveAt(highScores.scores.Count-1);
        }
    }

    // returns the lowest score in the list
    public int LowestScore(){
        return highScores.scores[highScores.scores.Count-1].score;
    }

    // saves scores back into PlayerPrefs
    public void SaveScore(){
        var json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("scores", json);
    }

    private void OnDestroy(){        
        SaveScore();
    }

    // returns true if 
    public bool AtCapacity(){
        return highScores.scores.Count >= TOTAL_TRACKED_SCORES;
    }

    
}