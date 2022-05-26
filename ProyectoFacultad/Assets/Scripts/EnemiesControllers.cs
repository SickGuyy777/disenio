using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControllers : MonoBehaviour
{
    public float health;
    public float maxHealth = 4;
    public AudioSource sonidodaño;
    public float attackDamage = 1f;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        GameObject.Instantiate(sonidodaño);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
