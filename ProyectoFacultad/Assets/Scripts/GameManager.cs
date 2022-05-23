using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public SaveSystem saveSystem;

    private void Awake()
    {
        SceneManager.sceneLoaded += Initialize;
        DontDestroyOnLoad(gameObject);
    }

    public void Initialize(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("Loaded GameManager");
        var playerInput = FindObjectOfType<CharacterController>();
        if (playerInput != null)
            player = playerInput.gameObject;
        saveSystem = FindObjectOfType<SaveSystem>();
        if(player != null && saveSystem.LoadedData != null)
        {
            var damagable = player.GetComponentInChildren<HealthSystem>();
            damagable.currentHealth = saveSystem.LoadedData.playerHealt;
        }
    }

    public void LoadLevel()
    {
        if (saveSystem.LoadedData != null)
        {
            SceneManager.LoadScene(saveSystem.LoadedData.sceneIndex);
                return;
        }
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {

    }
}
