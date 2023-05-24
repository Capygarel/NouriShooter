using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuWrapper;

    public bool isPaused;

    public UnityEvent isActive;
    public UnityEvent gameResumed;

    [SerializeField] private AudioClip pauseSound;
    [SerializeField] private float volumeScalePause;

    void Start()
    {
        pauseMenuWrapper.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
    }   

    public void ResumeGame()
    {
        pauseMenuWrapper.SetActive(false);
        SoundManager.Instance.PlaySound(pauseSound, volumeScalePause);
        isPaused = false;
        gameResumed.Invoke();
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        pauseMenuWrapper.SetActive(true);
        SoundManager.Instance.PlaySound(pauseSound, volumeScalePause);
        isActive.Invoke();
        isPaused = true;
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
