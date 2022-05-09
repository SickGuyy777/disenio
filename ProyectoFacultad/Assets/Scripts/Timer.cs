using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timer = 0;
    public Text textTimer;

    void Update()
    {
        timer -= Time.deltaTime;

        textTimer.text = "" + timer.ToString("f0");

        if (timer <= 0)
        {
            SceneManager.LoadScene("MiniGame01");
        }
    }
}
