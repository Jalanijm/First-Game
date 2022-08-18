using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool PlayerIsDead = false;

    public GameObject PauseMenuUI;
    public GameObject DeathMenuUI;
    public GameObject NormalCamera;
    public GameObject DeathCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused && !PlayerIsDead)
            {
                Resume();
            } else if (!PlayerIsDead)
            {
                Pause();
            }
        }

        if (PlayerIsDead)
        {
            DeathMenuUI.SetActive(true);
            Time.timeScale = 0f;
            NormalCamera.SetActive(false);
            DeathCamera.SetActive(true);
            Cursor.visible = true;
        } else
        {
            NormalCamera.SetActive(true);
            DeathCamera.SetActive(false);
            DeathMenuUI.SetActive(false);
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
    }

    public void loadMenu ()
    {

    }

    public void QuitScene ()
    {
        Time.timeScale = 1f;
        DeathMenuUI.SetActive(false);
        GameIsPaused = false;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        PlayerIsDead = false;
        if (sceneName == "Base")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        } else
        {
            SceneManager.LoadScene("Base");
        }
    }
}
