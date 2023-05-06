using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{

    private string sceneToStart = "Prototype 2";
    public GameObject deathMenuWrapper;
    public TMPro.TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        deathMenuWrapper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayDeathScreen()
    {
        Time.timeScale = 0;
        deathMenuWrapper.SetActive(true);
        scoreText.text = GetComponent<UIManager>().score.ToString();
    }

    public void ReStartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(sceneToStart);
    }

}


