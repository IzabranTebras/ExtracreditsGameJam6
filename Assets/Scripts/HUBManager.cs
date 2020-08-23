using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUBManager : MonoBehaviour
{
    public StatusScript playerStatus;
    public PlayerController playerController;

    public Slider slider;
    public Text timeText;
    public Text scoreText;
    public Text ammoText;

    public Image ammoImage;

    private int score;
    private float timeElapsed;
    private float lastTimeValue;
    private int sliderHealth;
    private int hubAmmo;

    void Start()
    {

        slider.maxValue = playerStatus.maxHealth;
        UpdateTimeText();
        UpdateSlider();
        UpdateScoreText();

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed - lastTimeValue > 1) //only update time if there is a change in value
        {
            UpdateTimeText();
            lastTimeValue = timeElapsed;
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
        int seconds = (int)timeElapsed % 60;
        int minutes = (int)timeElapsed / 60;

        timeText.text = "Time  " + minutes + ":" + seconds.ToString("00");
    }

    private void UpdateAmmoText()
    {
        if (ammoText == null) return;
        ammoText.text = playerController.currentAmmo.ToString("00");
    }
}
