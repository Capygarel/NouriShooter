using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuWrapper;

    private bool isPaused;

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
        isPaused = false;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        pauseMenuWrapper.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
