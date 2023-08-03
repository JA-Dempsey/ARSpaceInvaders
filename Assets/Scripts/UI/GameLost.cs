using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLost : MonoBehaviour
{

    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("lastScore", 0);
        scoreText.text = score.ToString();
    }

    private void OnDestroy() {
        PlayerPrefs.DeleteKey("lastScore");
    }
}
