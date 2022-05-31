using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColliderSystemSnake : MonoBehaviour
{
    public GameObject minigame;
    public HealthSystem health;
    public Timer timer;

    [Space]
    public bool mGisRunning, goodCol, badCol;

    private Vector3 spawnPos;
    private Quaternion spawnRot;

    private void Awake()
    {
        health = FindObjectOfType<HealthSystem>();
        mGisRunning = true;

        goodCol = false;
        badCol = false;

        timer = FindObjectOfType<Timer>();

        spawnPos = transform.position;
        spawnRot = transform.rotation;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log("CHOQUE");

        if (collision.gameObject.CompareTag("Good Col"))
        {
            goodCol = true;
        }
        else if (collision.gameObject.CompareTag("Bad Col"))
        {
            badCol = true;
        }
        mGisRunning = false;
    }

    private void Update()
    {
        if (mGisRunning == false)
        {
            timer.timerTime = 120;
            minigame.SetActive(false);
            ResetToSpawn();
            mGisRunning = true;

            if (goodCol == true && badCol == false)
            {
                RaiseHealth();
                goodCol = false;
            }
            else if (badCol == true && goodCol == false)
            {
                DownHealth();
                badCol = false;
            }
        }
    }

    void RaiseHealth()
    {
        health.currentHealth = 10;
    }

    void DownHealth()
    {
        health.currentHealth = health.currentHealth / 2;
    }

    void ResetToSpawn()
    {
        transform.position = spawnPos;
        transform.rotation = spawnRot;
    }
}
