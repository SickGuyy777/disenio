using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMovement : MonoBehaviour
{

    public float movementSpeed;

    private void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, 0, 0) * movementSpeed * Time.deltaTime;
        transform.position += new Vector3(0, v, 0) * movementSpeed * Time.deltaTime;
    }  
}
