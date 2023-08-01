using System;
using System.Collections.Generic;

[Serializable]
public class HighScores
{
    public List<ScoreEntry> scores;

    public HighScores()
    {
        scores= new List<ScoreEntry>();
    }
}