using System;

[Serializable] public class ScoreEntry: IComparable<ScoreEntry>{
    
    // represnts a score entry with name and score
    
    public string name;
    public int score;

    public ScoreEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

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