using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SubmitHighScore : MonoBehaviour
{
    
    public TMP_Text scoreText;
    public TMP_Text nameSubmission;
    private HighScoreManager highScoreManager;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        // load the score from Player Prefs
        score = PlayerPrefs.GetInt("lastScore", 0);
        scoreText.text = score.ToString();
       
        // get the high score manager
        try{
            highScoreManager = GetComponent<HighScoreManager>();               
        }catch(Exception e){};
    }

    // Submit score
    public void SubmitScore()
    {

        // trim the hidden char and return if name is empty
        if(String.IsNullOrEmpty(nameSubmission.text.Trim((char)8203))){
            return;
        }

        // add the score
        highScoreManager.AddScore(
            new ScoreEntry(nameSubmission.text, score)
        );

        // change scene
        SceneManager.LoadScene("HighScores");
    }

    // delete the retained score on destroy
    private void OnDestroy(){
        PlayerPrefs.DeleteKey("lastScore");
    }
}
