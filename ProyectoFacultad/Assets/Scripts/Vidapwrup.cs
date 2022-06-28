using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidapwrup : MonoBehaviour
{
    public HealthSystem reference;
    public AudioSource pickupsopund;
   private void OnCollisionEnter(Collision collision)
    {
        
        Instantiate(pickupsopund);
        reference.Takehealth();
        Destroy(gameObject);
        
    }
}
