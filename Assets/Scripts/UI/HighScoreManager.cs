using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Manages high scores and deals with adding score entry
/// and making sure they appear on the right rows.
/// </summary>
public class HighScoreManager : MonoBehaviour
{
    private HighScores highScores;
    private const int TOTAL_TRACKED_SCORES = 7;

    void Awake(){
        // load high scores and store into highScores
        var json = PlayerPrefs.GetString("scores", "{}");
        highScores = JsonUtility.FromJson<HighScores>(json);
    }

    // returns list of scores
    /// <summary>
    /// Enumerable that returns a list of scores.
    /// </summary>
    /// <returns>A list of scores.</returns>
    public IEnumerable<ScoreEntry> GetHighScores(){
        return highScores.scores;
    }

    /// <summary>
    /// Adds a score entry and sorts the list and prunes the excess.
    /// </summary>
    /// <param name="score">Score entry to add to the list</param>
    public void AddScore(ScoreEntry score){
        // add a score to the high scores and sorts it to prepare for pruning
        highScores.scores.Add(score);
        highScores.scores.Sort();

        while(highScores.scores.Count > TOTAL_TRACKED_SCORES){
            // remove the last item if it exceeds the max    
            highScores.scores.RemoveAt(highScores.scores.Count-1);
        }
    }

    /// <summary>
    /// Returns the lowest score on the list.
    /// </summary>
    /// <returns>The lowest score found in the scores list</returns>
    public int LowestScore(){
        if(highScores.scores.Count == 0){
            return 0;
        }
        
        return highScores.scores[highScores.scores.Count-1].score;

        
    }

    /// <summary>
    /// Saves scores back into PlayerPrefs
    /// </summary>
    public void SaveScore(){
        var json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("scores", json);
    }

    private void OnDestroy(){        
        SaveScore();
    }

    // returns true if 
    /// <summary>
    /// Returns true if high scores are at capacity
    /// TOTAL_TRACKED_SCORES
    /// </summary>
    /// <returns></returns>
    public bool AtCapacity(){
        return highScores.scores.Count >= TOTAL_TRACKED_SCORES;
    }

}
