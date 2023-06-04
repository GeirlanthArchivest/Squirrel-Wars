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
        healthBar = GetComponent<Slider>();

        EnemySquirrel = FindObjectOfType<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentHealth = EnemySquirrel.GetHealth();
        float maxHealth = EnemySquirrel.startingHealth;

        healthBar.value = currentHealth / maxHealth;
    }
}
