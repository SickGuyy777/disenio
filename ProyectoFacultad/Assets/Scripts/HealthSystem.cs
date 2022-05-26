using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
   
    public AudioSource sonidodañopj;
    public AudioSource muerte;
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
        GameObject.Instantiate(sonidodañopj);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("MiniGame01");
            GameObject.Instantiate(muerte);
        }

    }
}
