using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public void RestartButton()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void ExitButtion()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
