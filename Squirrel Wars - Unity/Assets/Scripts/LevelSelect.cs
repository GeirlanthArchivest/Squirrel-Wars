using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    public GameObject MenuUi;
    public GameObject levelSelect;

    public void SelectScreen()
    {
        MenuUi.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void PlayGame(string targetSceneName)
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
