using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    //function to change level
    public void changelevel(string targetSceneName)
    {
        //this loads specified scene
        SceneManager.LoadScene(targetSceneName);

    }
    
}
