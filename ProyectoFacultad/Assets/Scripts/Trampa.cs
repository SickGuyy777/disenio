using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.TryGetComponent<HealthSystem>(out HealthSystem playerComponent))
        {
            playerComponent.TakeDamage(1);
        }



    }
}
