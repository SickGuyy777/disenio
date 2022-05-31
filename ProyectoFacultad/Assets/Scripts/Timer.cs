using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timerTime = 120;
    public Text textTimer;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            timerTime = 5;
        }

        timerTime -= Time.deltaTime;

        textTimer.text = "" + timerTime.ToString("f0");

        //if (timer <= 0)
        //{
        //    SceneManager.LoadScene("MiniGame01");
        //}

        if (timerTime <= 0)
        {
            timerTime = 0;
        }
    }
}
