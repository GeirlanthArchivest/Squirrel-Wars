using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int startingHealth = 5;
    private int currentHealth;
    public void Kill()
    {
        Destroy(gameObject);
    }

    public void Awake()
    {
        currentHealth = startingHealth;
    }

    public void ChangeHealth(int changeAmount)
    {
        currentHealth = currentHealth + changeAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
        if (currentHealth == 0)
        {
            Kill();
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
