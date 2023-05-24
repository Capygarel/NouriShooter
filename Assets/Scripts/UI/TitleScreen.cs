using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private string sceneToStart = "Prototype 2";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Load the Main Scene when Play is pressed
    public void StartScene()
    {
        SceneManager.LoadSceneAsync(sceneToStart);
    }

    //Quit the game when quit is pressed
    public void QuitGame()
    {
        Application.Quit();
    }
}
