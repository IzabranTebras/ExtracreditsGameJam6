﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClicked: MonoBehaviour
{
    public enum buttonId
    {
        PLAY = 0,
        INSTRUCTIONS,
        HIGHSCORE
    }

    public buttonId id;
    // Start is called before the first frame update
    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ClickEvent);
    }
    private void ClickEvent()
    {
        switch (id)
        {
            case buttonId.PLAY:
                {
                    SceneManager.LoadSceneAsync(1);
                    break;
                }
            case buttonId.INSTRUCTIONS:
                {
                    // SceneManager.LoadSceneAsync(1);       //@TODO crear escena de instrucciones
                    break;
                }
            case buttonId.HIGHSCORE:
                {
                    // SceneManager.LoadSceneAsync(1);       //@TODO crear escena de puntuaciones
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}