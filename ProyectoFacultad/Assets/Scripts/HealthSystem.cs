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

    private void Update()
    {
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 1)
        {
            SceneManager.LoadScene("DeadScene");
            GameObject.Instantiate(muerte);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        GameObject.Instantiate(sonidodañopj);
    }
}
