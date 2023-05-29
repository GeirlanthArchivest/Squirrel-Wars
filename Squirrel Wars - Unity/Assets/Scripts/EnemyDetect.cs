using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDetect : MonoBehaviour
{

    void Update()
    {

        //defines found as variable and checks for Enemy tag
        GameObject found = GameObject.FindWithTag("Enemy");

        //checks if there isnt any enemies
        if (found == null)
        {

            // loads specified scene
            SceneManager.LoadScene("LevelChange1");

        }



    }





    //public GameObject[] enemies;


    // Start is called before the first frame update
    // void Start()
    //{
    //    enemies = GameObject.FindGameObjectsWithTag("Enemy");
    //}

    // Update is called once per frame
    // void Update()
    // {
    //   if (enemies.Length == 0)
    //   {
    // Change the scene to the next level
    //       ChangeScene("LevelChange1");
    //   }
    // }


    //public void ChangeScene(string LevelChange1)
    //{
    //  SceneManager.LoadScene(LevelChange1);
    //}
}
