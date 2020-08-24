using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    public GameObject entryPrefab;

    public SaveLoad saveLoad;

    List<GameObject> entries=new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        LoadScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScores()
    {
        foreach (HighScore highscore in saveLoad.highscores.list)
        {
            GameObject gO = Instantiate(entryPrefab, transform);
            entries.Add(gO);
            gO.GetComponent<EntryManager>().setHighcore(highscore);

        }
    }

    public void deleteAllEntries()
    {
        saveLoad.deleteAllEntries();
        foreach(GameObject entry in entries)
        {
            Destroy(entry);
        }
    }
}

