using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private HighScores highScores;
    void Awake()
    {
        // load high scores and store into highScores
        var json = PlayerPrefs.GetString("scores", "{}");
        highScores = JsonUtility.FromJson<HighScores>(json);
    }

    public IEnumerable<ScoreEntry> GetHighScores(){
        // returns list of scores descending
        return highScores.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(ScoreEntry score){
        // add a score to the high scores
        highScores.scores.Add(score);
    }

    public void SaveScore(){
        // saves scores back into PlayerPrefs
        var json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("scores", json);
    }

    private void OnDestroy(){
        // on destroy, save scores
        SaveScore();
    }
}