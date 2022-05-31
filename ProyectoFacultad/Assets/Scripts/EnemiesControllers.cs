using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControllers : MonoBehaviour
{
    public float health, range;
    public float maxHealth = 4;
    public AudioSource sonidodaño;
    public float attackDamage = 1f;

    public Transform player;
    private float _distToPlayer;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        _distToPlayer = Vector2.Distance(transform.position, player.position);

        if (_distToPlayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0 
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
        }
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

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
