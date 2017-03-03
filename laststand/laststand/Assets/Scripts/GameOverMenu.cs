using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Transform canvas;
    public Animator gameovermenu;
    public Animator menu;

    public void GameOver()
    {
        if (canvas.gameObject.activeInHierarchy == false) // checks to see if canvas us active or not
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.volume = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
            AudioListener.volume = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Mainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
