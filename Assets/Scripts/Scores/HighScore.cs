using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreList
{
    public List<HighScore> list;

    public HighScoreList()
    {
        list = new List<HighScore>();
    }
}



[System.Serializable]
public class HighScore
{
    public string name;
    public string score;
    public string time;

    public HighScore(string name, string score, string time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }
}
