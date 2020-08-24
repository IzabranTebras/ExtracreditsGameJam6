using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ClickEvent);
    }

    // Update is called once per frame
    private void ClickEvent()
    {
        FindObjectOfType<LeaderBoardManager>().deleteAllEntries();
    }
}

