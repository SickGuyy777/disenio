using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AudioSource pickupsopund;
    private void OnTriggerEnter(Collider other)
    {
        CharacterController weapon = other.gameObject.GetComponentInChildren<CharacterController>();
        if (weapon)
        {
            Instantiate(pickupsopund);
            weapon.AddAmmo(weapon.maxAmmoSize);
            Destroy(gameObject);
        }
    }
}
