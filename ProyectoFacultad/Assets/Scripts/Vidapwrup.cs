using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidapwrup : MonoBehaviour
{
    public HealthSystem reference;
   private void OnCollisionEnter(Collision collision)
    {
        
        reference.Takehealth();
        Destroy(gameObject);
        
        
    }
}
