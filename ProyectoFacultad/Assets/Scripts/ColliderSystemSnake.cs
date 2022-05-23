using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderSystemSnake : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Meta"))
        {
            SceneManager.LoadScene("Level1");
        }
        else if (CompareTag("DeathCollider"))
        {

            SceneManager.LoadScene("Level1");
        }
    }
}
