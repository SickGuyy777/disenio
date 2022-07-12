using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel4 : MonoBehaviour
{
       private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("Level4");
    }
}
