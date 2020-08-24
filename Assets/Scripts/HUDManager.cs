using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public StatusScript playerStatus;
    public PlayerController playerController;
    
    public GameObject message;
    public Text textMessage;

    public Slider slider;
    public Text timeText;
    public Text scoreText;
    public Text ammoText;

    public Image ammoImage;

    public SaveLoad saveLoad;

    private int score;
    private float timeElapsed;
    private float lastTimeValue;
    private int sliderHealth;
    private int hubAmmo;
    private bool timerStop;
    private bool saved;

    public float TimeElapsed { get => timeElapsed;}
    public int Score { get => score;}

    void Start()
    {
        saved = false;

        slider.maxValue = playerStatus.maxHealth;
        UpdateTimeText();
        UpdateSlider();
        UpdateScoreText();

    }

    // Update is called once per frame
    void Update()
    {
        if(!timerStop)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed - lastTimeValue > 1) //only update time if there is a change in value
            {
                UpdateTimeText();
                lastTimeValue = timeElapsed;
            }
        }

        if(sliderHealth != playerStatus.currentHealth)
        {
            UpdateSlider();
            sliderHealth = playerStatus.currentHealth;
        }

        if (hubAmmo != playerController.currentAmmo)
        {
            UpdateAmmoText();
            hubAmmo = playerController.currentAmmo;
        }

    }


    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateSlider()
    {
        if (slider == null) return;
        slider.value = playerStatus.currentHealth;
    }

    private void UpdateScoreText()
    {
        if (scoreText == null) return;
        scoreText.text = score.ToString();
    }

    private void UpdateTimeText()
    {
        if (timeText == null) return;
        timeText.text = "Time: "+getTimeString();
    }

    private void UpdateAmmoText()
    {
        if (ammoText == null) return;
        ammoText.text = playerController.currentAmmo.ToString("00");
    }


    public void ChangeAmmoImage(Sprite sprite)
    {
        ammoImage.sprite = sprite;
    }

    public string getTimeString()
    {
        int seconds = (int)timeElapsed % 60;
        int minutes = (int)timeElapsed / 60;
        return + minutes + ":" + seconds.ToString("00");
    }

    public void GameOver()
    {
        timerStop = true;
        message.SetActive(true);
        
        textMessage.text = "Score:\t" + Score.ToString("0000") + "\nTime\t" + getTimeString();
        if (!saved)
        {
            saveLoad.AddHighscore(new HighScore("Player1", Score.ToString("0000"), getTimeString()));
            saved = true;
        }


        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        EnemySpawner.Reset();   //needed if player wants to restart the game
    }
}
