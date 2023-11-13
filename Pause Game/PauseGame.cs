using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{   
    //assign the painel GamePausedMenu to the variable
    [SerializeField] GameObject pauseWindow;
    bool isPaused = false;

    //OnClick() function to be called with a button 
    //load menu scene and resume the update Time
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    //disable panel and resume the update Time
    public void ResumeGame()
    {
        pauseWindow.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //resume the game
            if (isPaused == true)
            {
                isPaused = false;
                Time.timeScale = 1;
                Debug.Log(Time.timeScale);
                pauseWindow.SetActive(false);
            }
            //stop the game
            //this condition will be the first to run when pressing P
            else
            {
                isPaused = true;
                Time.timeScale = 0;
                Debug.Log(Time.timeScale);
                pauseWindow.SetActive(true);
            }
        }
    }
}
