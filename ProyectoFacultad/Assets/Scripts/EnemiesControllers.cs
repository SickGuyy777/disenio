using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControllers : MonoBehaviour
{
    public bool ExplosiveEnemy = false;
    public float health, range;
    public float maxHealth = 4;
    public AudioSource sonidodisparo;
    public AudioSource sonidodo;
    public float attackDamage = 1f;

    [Space]
    public Transform player;
    private float _distToPlayer;

    [Space]
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    [Space]
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    public Transform LaunchOffset;

    [Space]
    public GameObject ammoBox;

    [Space]
    public Animator anim;

    [Space]
    public GameObject deathEffect;

    public GameObject explosionEffect;

    public AudioSource explosionsfw;
    
    public float explosionForce=10f;
    public float radius=10f;

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
            anim.SetBool("IsWalking", true);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
             anim.SetBool("IsWalking", false);
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
        GameObject.Instantiate(sonidodo);

        if (health <= 0 & ExplosiveEnemy == false)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            DropAmmo();
        }

        if (health <= 0 & ExplosiveEnemy == true)
        {
            Explode();

        }
    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void DropAmmo()
    {
        Vector3 position = transform.position;
        GameObject boxAmmo = Instantiate(ammoBox, position + new Vector3(0.1f,1f,0f), Quaternion.identity);
        Destroy(boxAmmo, 5f);
    }

    private void Explode()
    {
        
        Collider[]colliders=Physics.OverlapSphere(transform.position,radius);
        
        foreach(Collider near in colliders)
        {

        
            Rigidbody rig=near.GetComponent<Rigidbody>();
        
            if(rig!=null)
            rig.AddExplosionForce(explosionForce,transform.position,radius,1f,ForceMode.Impulse);
        
            // if (near.gameObject.TryGetComponent<EnemiesControllers>(out EnemiesControllers enemyComponent))
            // {
            //     enemyComponent.TakeDamage(2);
            // }
            if (near.gameObject.TryGetComponent<HealthSystem>(out HealthSystem playerComponent))
            {
                playerComponent.TakeDamage(2);
            }
        }
        


        
        Instantiate(explosionEffect,transform.position,transform.rotation);
        Instantiate(explosionsfw);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) 
    {
        
        var pl = other.gameObject.GetComponent<HealthSystem>();
        if (pl != null & ExplosiveEnemy)
        {
           Explode();
        }
    }
}
