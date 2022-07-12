using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public AudioSource sonidodo;
    public int damage;

    public void OnTriggerEnter(Collider other)
    {
        HealthSystem hitHealth = other.GetComponent<HealthSystem>();
        if (hitHealth != null)
        {
            hitHealth.TakeDamage(damage);
        
        }
    }
}
