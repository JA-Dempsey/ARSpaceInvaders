using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    public HighScoresRowUI rowPrefab;
    public HighScoreManager highScoreManager;
    
    private int max_entries = 10;

    void Start()
    {

        var scores = highScoreManager.GetHighScores().ToArray();
        
        // limit number of scores to 10
        for (int i = 0; i < Mathf.Min(scores.Length, max_entries); i++)
        {
            var row = Instantiate(rowPrefab, transform).GetComponent<HighScoresRowUI>();
            
            // turn fields into text
            row.index.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}