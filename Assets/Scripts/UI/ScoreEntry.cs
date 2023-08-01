using System;

[Serializable] public class ScoreEntry{
    
    // represnts a score entry with name and score
    
    public string name;
    public int score;

    public ScoreEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}