using System;

///
/// An entry for a new score. Includes the name and the score.
///
[Serializable] public class ScoreEntry: IComparable<ScoreEntry>{
    
    // represnts a score entry with name and score
    
    public string name;
    public int score;

    public ScoreEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    /// <summary>
    /// Compares to the given other ScoreEntry.
    /// </summary>
    /// <param name="other">The score entry to compare to</param>
    /// <returns></returns>
    public int CompareTo(ScoreEntry other){
        try{
            if(this.score > other.score){
                return -1;
            }else if(this.score == other.score){
                return 0;
            }else{
                return 1;
            }
        }catch(Exception e){
            return -1;
        }
        
    }
}