using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    
    public void changelevel(string targetSceneName)
    {
        SceneManager.LoadScene(targetSceneName);

    }
    
}
