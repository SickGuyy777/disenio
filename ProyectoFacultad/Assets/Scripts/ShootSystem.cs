using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{

    public float speed;

    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.TryGetComponent<EnemiesControllers>(out EnemiesControllers enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }

        Destroy(this.gameObject);

    }
}
