using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryManager : MonoBehaviour
{

    public Text name, score, time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHighcore(HighScore score)
    {
        name.text = score.name;
        this.score.text = score.score;
        time.text = score.time;
    }
}
