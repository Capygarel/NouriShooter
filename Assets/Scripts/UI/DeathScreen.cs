using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class DeathScreen : MonoBehaviour
{

    private string sceneToStart = "Prototype 2";

    public GameObject deathMenuWrapper;

    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI endText;
    public TMPro.TextMeshProUGUI buttonText;
    public bool deathScreenActive = false;

    [SerializeField] private AudioClip endWaveSound;
    [SerializeField] private float volumeScaleEndWaveSound;

    public UnityEvent isActive;

    public UnityEvent onNewWaveSelected;

    public UnityEvent onSceneRestarted;

    public bool isPlayerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        deathMenuWrapper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDead()
    {
        isPlayerDead = true;
        deathScreenActive = true;
        DisplayEndScreen();
    }

    public void DisplayEndScreen()
    {
        Time.timeScale = 0;
        isActive.Invoke();
        SoundManager.Instance.PlaySound(endWaveSound, volumeScaleEndWaveSound);
        deathMenuWrapper.SetActive(true);
        scoreText.text = UIManager.instance.score.ToString();
        if (isPlayerDead)
        {
            
            endText.text = "Game Over !";
            buttonText.text = "Play Again";
        }
        else
        {
            endText.text = "Wave Complete !";
            buttonText.text = "Continue";
        }
        
    }

    public void ChoiceButton()
    {
        if (isPlayerDead)
        {
            ReStartScene();
        }
        else
        {
            Time.timeScale = 1;
            deathMenuWrapper.SetActive(false);
            onNewWaveSelected.Invoke();
        }
    }

    public void ReStartScene()
    {
        onSceneRestarted.Invoke();
        isPlayerDead = false;
        SpawnManager.wavenumber = 0;
        SceneManager.LoadScene(sceneToStart);
        Time.timeScale = 1;
    }

}


