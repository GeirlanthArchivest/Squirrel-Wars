using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //defines found as variable and checks for Enemy tag
        GameObject found = GameObject.FindWithTag("Character");

        //checks if there isnt any enemies
        if (found == null)
        {

            // loads specified scene
            SceneManager.LoadScene("DeathMenu");

        }
    }
}
