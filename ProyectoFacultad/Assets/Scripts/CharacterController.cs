using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    Rigidbody _rigidbody;
    public bool playerIsOnTheGround = true;
    public Animator an;
    public AudioSource sonidodisparo;
    public Timer timer;

    [Space]
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;

    [Space]
    public GameObject minigame;

    [Space]
    public int currentClip, maxClipSize = 20, currentAmmo, maxAmmoSize = 100;

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

            if (Input.GetKeyDown(KeyCode.Mouse0) && currentClip > 0)
            {
                Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
                GameObject.Instantiate(sonidodisparo);
                currentClip--;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }

        else
        {
            minigame.SetActive(true);
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

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentClip - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if (currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }
}
