using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusScript : MonoBehaviour
{

    public int maxHealth = 10;
    public float timeElapsed;
    public int score;

    //@TODO linkar los elementos de UI cuando esten hechos
    public Slider slider;
    public Text timeText;
    public Text scoreText;

    private int currentHealth;
    private float lastTimeValue;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (slider != null)
        {
            slider.maxValue = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed - lastTimeValue > 1) //only update time if there is a change in value
        {
            UpdateTimeText();
            lastTimeValue = timeElapsed;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <0)
        {
            currentHealth = 0;
        }
        UpdateSlider();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateSlider();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateSlider()
    {
        if (slider == null) return;
        slider.value = currentHealth;
    }

    private void UpdateScoreText()
    {
        if (scoreText == null) return;
        scoreText.text = score.ToString();
    }

    private void UpdateTimeText()
    {
        if (timeText == null) return;
        int seconds = (int)timeElapsed%60;
        int minutes = (int)timeElapsed/60;

        timeText.text = minutes + ":" + seconds.ToString(" 00");
    }
}
