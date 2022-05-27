using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParedSanake : MonoBehaviour
{  
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Snake"))
        {
            SceneManager.LoadScene ("Level1");
        }
    }
}
