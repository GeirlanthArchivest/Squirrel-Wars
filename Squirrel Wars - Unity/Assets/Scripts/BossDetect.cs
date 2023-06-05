using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDetect : MonoBehaviour
{
    void Update()
    {

        //defines found as variable and checks for Enemy tag
        GameObject found = GameObject.FindWithTag("Boss");

        //checks if there isnt any enemies
        if (found == null)
        {

            // loads specified scene
            SceneManager.LoadScene("WinMenu");

        }



    }
}