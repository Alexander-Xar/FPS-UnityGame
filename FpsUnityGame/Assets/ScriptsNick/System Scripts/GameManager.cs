using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one instance of GameManager found!");
            Destroy(gameObject);
        }
    }
    #endregion

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject ammoScreen;
    public GameObject timer;
    public GameObject crossHair;
    private float defaultTimeScale = 1f;

    public void Start()
    {
        ammoScreen.SetActive(true);
        Time.timeScale = defaultTimeScale;
    }

    public void PlayerWins()
    {
        // Implement win condition
        ammoScreen.SetActive(false);
        Debug.Log("You win!");
        winScreen.SetActive(true);
        timer.SetActive(false);
        crossHair.SetActive(false);

    }

    public void PlayerLoses()
    {
        Debug.Log("You lose!");
        loseScreen.SetActive(true);
        ammoScreen.SetActive(false);
        crossHair.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;

    }
}
