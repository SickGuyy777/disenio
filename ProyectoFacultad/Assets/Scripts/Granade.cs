using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public GameObject explosionEffect;

    public AudioSource explosionsfw;
    public float delay;
    public float explosionForce=10f;
    public float radius=20f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", delay);
    }

    // Update is called once per frame
    private void Explode()
    {
        // Checking nearby colliders;
        Collider[]colliders=Physics.OverlapSphere(transform.position,radius);
        // Applying themaforce;
        foreach(Collider near in colliders)
        {

        
            Rigidbody rig=near.GetComponent<Rigidbody>();
        
            if(rig!=null)
            rig.AddExplosionForce(explosionForce,transform.position,radius,1f,ForceMode.Impulse);
        
            if (near.gameObject.TryGetComponent<EnemiesControllers>(out EnemiesControllers enemyComponent))
            {
                enemyComponent.TakeDamage(2);
            }
           
        }
        


        // Explosion effect
        Instantiate(explosionEffect,transform.position,transform.rotation);
        Instantiate(explosionsfw);
        Destroy(gameObject);
    }
}
