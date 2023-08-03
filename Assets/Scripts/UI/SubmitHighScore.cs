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
    public GameObject fadeImageObject;
    private HighScoreManager highScoreManager;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        // load the score from Player Prefs
        score = PlayerPrefs.GetInt("lastScore", 0);
        scoreText.text = score.ToString();
       
        // if score is lower than lowest score and scoreboard is at capacity, then direct to game lost screen
        highScoreManager = GetComponent<HighScoreManager>();
        if(score < highScoreManager.LowestScore() && highScoreManager.AtCapacity()){
            SceneManager.LoadScene("GameLost");
        }


        StartCoroutine(FadeImage());
        
    }

    // Submit score
    public void SubmitScore()
    {
        // add the score
        highScoreManager.AddScore(
            new ScoreEntry(nameSubmission.text, score)
        );

        // change scene
        SceneManager.LoadScene("HighScores");
    }

    private void OnDestroy(){
        // destroy the Player Prefs score
        PlayerPrefs.DeleteKey("lastScore");
    }

    IEnumerator FadeImage(){
        Image fadeImage = fadeImageObject.GetComponent<Image>();
        // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                fadeImage.color = new Color(255, 255, 255, i);
                yield return null;
            }
            Destroy(fadeImageObject);
            
            
    }
}
