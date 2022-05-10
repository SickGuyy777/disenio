using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    Rigidbody _rigidbody;
    public bool playerIsOnTheGround = true;

    [Space]
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if(Input.GetKeyDown(KeyCode.Space) && playerIsOnTheGround)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerIsOnTheGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsOnTheGround = true;
        }
    }
}