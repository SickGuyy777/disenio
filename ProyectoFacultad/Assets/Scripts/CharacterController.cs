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
    public Animator an;
    public AudioSource sonidodisparo;

    [Space]
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;

    float posX;
    float posY;
    float posZ;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        posX = PlayerPrefs.GetFloat("posicionxguardado");
        posY = PlayerPrefs.GetFloat("posicionyguardado");
        posZ = PlayerPrefs.GetFloat("posicionzguardado");

        transform.position = new Vector3(posX, posY, posZ);
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime;

        an.SetFloat("Horizontal",Mathf.Abs( movement));

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if(Input.GetKeyDown(KeyCode.Space) && playerIsOnTheGround)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerIsOnTheGround = false;
            an.SetBool("ensuelo", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            GameObject.Instantiate(sonidodisparo);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsOnTheGround = true;
            an.SetBool("ensuelo", true);
        }
    }
    
    public void guardarPosicionPlayer()
    {
        PlayerPrefs.SetFloat("posicionxguardado", this.transform.position.x);
        PlayerPrefs.SetFloat("posicionyguardado", this.transform.position.y);
        PlayerPrefs.SetFloat("posicionzguardado", this.transform.position.z);
        PlayerPrefs.Save();
    }
}
