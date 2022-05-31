using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParedSanake : MonoBehaviour
{
    public GameObject minigameCanv;
    public HealthSystem health;

    private void Start()
    {
        health = FindObjectOfType<HealthSystem>();
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.CompareTag("Snake"))
        {
            minigameCanv.SetActive(false);

            health.currentHealth = health.currentHealth / 2;
        }
    }
}
