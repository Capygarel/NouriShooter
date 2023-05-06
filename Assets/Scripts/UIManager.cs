using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    private int health;

    public float timeRemaining;
    private float lastSecond;

    public int score = 0;
    private int scorePerSecond = 5;

    public TMPro.TextMeshProUGUI healthText;
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI scoreIncreaseText;

    public UnityEvent onTimeUp;

    // Start is called before the first frame update
    void Start()
    {
        SetHealth(GameObject.Find("Player").GetComponent<PlayerController>().lives);
        DisplayScore();
        lastSecond = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateTimer();
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
        healthText.text = "Health\n" + health;
    }

    public void IncreaseScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreIncreaseText.text = "+" + scoreToAdd + "!";
        scoreIncreaseText.canvasRenderer.SetAlpha(1);
        scoreIncreaseText.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-10, 10));
        scoreIncreaseText.CrossFadeAlpha(0, 0.7f, true);
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreText.text = "Score\n" + score;
    }

    void UpdateTimer()
    {
        float timeToDisplay = timeRemaining + 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (seconds < lastSecond)
        {
            IncreaseScore(scorePerSecond);
            lastSecond = seconds;
            
        }
        
        timerText.text = "Time\n"  + string.Format("{0:0}:{1:00}", minutes, seconds);

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
            onTimeUp.Invoke();


    }
}
