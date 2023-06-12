using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    public GameObject MenuUi;
    public GameObject levelSelect;

    //Function SelectScreen
    public void SelectScreen()
    {
        //menu UI which was publicly set is set false taking it out of view
        MenuUi.SetActive(false);
        //levelSelect also publicly set is seet to true showing it to the player
        levelSelect.SetActive(true);
    }

    //PlayGame function
    public void PlayGame(string targetSceneName)
    {
        //loads the scene specified in unity UI so that each button can use same code
        SceneManager.LoadScene(targetSceneName);
    }

    //OpenWebsite function
    public void OpenWebsite(string url)
    {
        //opens in default application the specified URL (specified in unity UI)
        Application.OpenURL(url);
    }
}
