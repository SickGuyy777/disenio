using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel5 : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
