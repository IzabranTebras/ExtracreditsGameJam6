using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public HighScoreList highscores = new HighScoreList();
    int maxsaves = 7;
    void Awake()
    {
        LoadFile();
    }

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, highscores);
        file.Close();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        highscores = (HighScoreList)bf.Deserialize(file);
        file.Close();

    }

    internal void deleteAllEntries()
    {
        highscores = new HighScoreList();
        SaveFile();
    }

    public void AddHighscore(HighScore score)
    {
        highscores.list.Add(score);
        highscores.list.Sort(new Comparator());
        SaveFile();
    }


    class Comparator : IComparer<HighScore>
    {
        public int Compare(HighScore x, HighScore y)
        {
            return x.score.CompareTo(y.score);
        }
    }

}