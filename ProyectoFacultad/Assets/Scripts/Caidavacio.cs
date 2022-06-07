using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caidavacio : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.TryGetComponent<HealthSystem>(out HealthSystem playerComponent))
        {
            playerComponent.TakeDamage(20);
        }

        

    }
   
}
