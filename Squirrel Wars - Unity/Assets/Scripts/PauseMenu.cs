using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    //pauseMenu function to be called on when a button is pressed
    public void pauseMenu()
    {
        if (GameIsPaused)
        {
            //if GameIsPaused is true then Resume function is called
            Resume();
        }
        else
        {
            //if GameIsPaused is false then Pause function is called
            Pause();
        }

    }
        
    //Resume Function
    public void Resume()
    {
        //pauseMenuUi object which was previously publicly set is set to false making it disappear from the screen
        pauseMenuUI.SetActive(false);
        //Game timescale is returned to 1 so game plays normally
        Time.timeScale = 1f;
        //GameIsPaused set to false
        GameIsPaused = false;
    }
    //Pause function
    public void Pause()
    {
        //pauseMenuUi object which was previously publicly set is set to true making it appear on screen
        pauseMenuUI.SetActive(true);
        //Game timescale is set to 0 so game is paused
        Time.timeScale = 0f;
        //GameIsPaused set to true
        GameIsPaused = true;
    }

    //function LoadMainMenu
    public void LoadMainMenu()
    {
        //Game timescale is returned to 1 so game plays normally
        Time.timeScale = 1f;
        //loads the scene Main Menu 
        SceneManager.LoadScene("Main Menu");
    }
}
