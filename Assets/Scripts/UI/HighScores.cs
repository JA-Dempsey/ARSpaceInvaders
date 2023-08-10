using System;
using System.Collections.Generic;


///
/// Provides a list of High Scores for saving scores
///
[Serializable]
public class HighScores
{
    public List<ScoreEntry> scores;  //!< A list used to store scores

    public HighScores()
    {
        scores= new List<ScoreEntry>();
    }
}