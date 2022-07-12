using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public int fuerzadetrampolin;
    public float movementSpeed;
    public float jumpForce;
    Rigidbody _rigidbody;
    public bool playerIsOnTheGround = true;
    public Animator an;
    public AudioSource sonidodisparo;
    public AudioSource sonidotrampolin;

    public AudioSource sonidorecarga;
    public Timer timer;

    [Space]
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;

    [Space]
    public GameObject minigame;

    [Space]
    public int currentClip;
    public int maxClipSize = 20;
    public int currentAmmo;
    public int maxAmmoSize = 100;

    [Space]
    public GameObject granadePrefab;
    

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        timer = FindObjectOfType<Timer>();
        currentAmmo = maxAmmoSize;
        currentClip = maxClipSize;
    }

    void Update()
    {
        if (timer.timerTime > 0)
        {
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * movementSpeed * Time.deltaTime;

            an.SetFloat("Horizontal", Mathf.Abs(movement));

            if (!Mathf.Approximately(0, movement))
                transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

            if (Input.GetKeyDown(KeyCode.Space) && playerIsOnTheGround)
            {
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerIsOnTheGround = false;
                an.SetBool("ensuelo", false);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && currentClip > 0 && PauseMenu.GameIsPaused == false)
            {
                Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
                GameObject.Instantiate(sonidodisparo);
                currentClip--;
            }

            Reload();
        }

        else
        {
            minigame.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            TrowGranade();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsOnTheGround = true;
            an.SetBool("ensuelo", true);
        }

        if (collision.gameObject.CompareTag("Trampolin"))
        {
            _rigidbody.velocity = Vector3.up * fuerzadetrampolin;
           Instantiate(sonidotrampolin);
        }
    }

    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo > 0 && currentClip < 20)
        {
            GameObject.Instantiate(sonidorecarga);
            currentAmmo = currentAmmo - 20;
            currentClip = currentClip + 20;
            if (currentClip > 20)
            {
                currentClip = 20;
            }
        }
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if (currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }

    void TrowGranade()
    {
        
        GameObject newGranade = Instantiate(granadePrefab, LaunchOffset.position, LaunchOffset.rotation);

        
        newGranade.GetComponent<Rigidbody>().AddForce(-LaunchOffset.right * 5, ForceMode.Impulse);
    }

    
}
