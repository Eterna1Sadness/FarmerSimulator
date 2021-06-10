using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pausePanel;
    public GameObject toolbarPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ContinueGame();
        }
    }

    public void ContinueGame()
    {
        isPaused = !isPaused;
        toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        if (isPaused)
        {
            pausePanel.SetActive(true);
            toolbarPanel.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            toolbarPanel.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        ContinueGame();
    }

    public void QuitInMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
