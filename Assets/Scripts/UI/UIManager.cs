using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    #region variables
    private int health;

    public int maxNumberWaves;

    private float globalTime;
    public float timeRemaining;
    private float lastSecond;

    public static UIManager instance;

    public int score = 0;
    private int scorePerSecond = 5;

    public TMPro.TextMeshProUGUI healthText;
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI scoreIncreaseText;

    public Image crosshair;

    public UnityEvent onTimeUp;
    public UnityEvent onFinalWaveFinished;

    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetHealth(GameObject.FindWithTag("Player").GetComponent<PlayerController>().GetCurrentHP());
        DisplayScore();
        lastSecond = timeRemaining;
        globalTime = timeRemaining;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateTimer();
    }

    public void NewWave()
    {
        globalTime += 5;
        timeRemaining = globalTime;
        lastSecond = timeRemaining;
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
        {
            if(SpawnManager.wavenumber >= maxNumberWaves)
            {
                onFinalWaveFinished.Invoke();
            }
            else
            {
                onTimeUp.Invoke();
            }
        }
           


    }
}
