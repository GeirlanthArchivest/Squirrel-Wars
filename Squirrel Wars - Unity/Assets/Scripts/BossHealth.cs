using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int startingHealth = 5;
    private int currentHealth;

    public void Kill()
    {
        Destroy(gameObject); //Destroys boss object when function is called
    }

    public void Awake()
    {
        currentHealth = startingHealth; //Sets health amount
    }

    public void ChangeHealth(int changeAmount)
    {
        currentHealth = currentHealth + changeAmount; //Changed health value
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth); //Keeps health value between 0 and the starting health value
        if (currentHealth == 0)
        {
            Kill(); //Calls the kill function
        }
    }

    public int GetHealth()
    {
        return currentHealth; //Returns health value
    }
}
