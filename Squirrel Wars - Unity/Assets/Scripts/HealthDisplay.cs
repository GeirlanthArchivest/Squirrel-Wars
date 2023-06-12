using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //Slider = variable is in the form of a slider component
    Slider healthBar;

    //Player health information
    BossHealth EnemySquirrel;

    // Start is called before the first frame update
    void Start()
    {
        //Attaches slider component to variable
        healthBar = GetComponent<Slider>();

        //Gets boss health and assigns it to EnemySquirrel variable
        EnemySquirrel = FindObjectOfType<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets current and max health
        float currentHealth = EnemySquirrel.GetHealth();
        float maxHealth = EnemySquirrel.startingHealth;

        //Updates slider value
        healthBar.value = currentHealth / maxHealth;
    }
}
