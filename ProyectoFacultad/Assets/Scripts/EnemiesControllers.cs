using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControllers : MonoBehaviour
{
    public float health;
    public float maxHealth = 4;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
