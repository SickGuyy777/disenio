using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int baseHealth;
    public int currentHealth;
    public HealthBar healthBar;

    public void Start()
    {
        currentHealth = baseHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("MiniGame01");
        }

    }
}
