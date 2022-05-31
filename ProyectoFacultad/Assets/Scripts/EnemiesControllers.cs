using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControllers : MonoBehaviour
{
    public float health, range;
    public float maxHealth = 4;
    public AudioSource sonidodisparo;
    public AudioSource sonidodaño;
    public float attackDamage = 1f;

    public Transform player;
    private float _distToPlayer;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    public Transform LaunchOffset;

    private void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    
    void Update()
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

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) <= range)
        {
              transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0 && Vector2.Distance(transform.position, player.position) <= range)
        {
            Instantiate(projectile, LaunchOffset.position, Quaternion.identity );
            timeBtwShots = startTimeBtwShots;
            GameObject.Instantiate(sonidodisparo);

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
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
