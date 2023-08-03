using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    public HighScoresRowUI rowPrefab;
    public HighScoreManager highScoreManager;
    
    void Start(){
        
        // get the high scores
        var scores = highScoreManager.GetHighScores().ToArray();
        
        // Go over each entry and create a UI row for it
        for (int i = 0; i < scores.Length; i++){
            var row = Instantiate(rowPrefab, transform).GetComponent<HighScoresRowUI>();
            
            // turn fields into text
            row.index.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}