using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SoccerManager;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject volumeMenu;
    [SerializeField] GameObject displayMenu;

    private void OnEnable()
    {
        SoccerManager.OnResumed += ResumeButton;
    }

    private void OnDisable()
    {
        SoccerManager.OnResumed -= ResumeButton;
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        volumeMenu.SetActive(false);
        displayMenu.SetActive(false);

        Time.timeScale = 1;

        SoccerManager.instance.gameState = SoccerManager.GameState.Playing;
    }

    public void VolumeButton()
    {
        pauseMenu.SetActive(false);

        volumeMenu.SetActive(true);
    }

    public void DisplayButton()
    {
        pauseMenu.SetActive(false);

        displayMenu.SetActive(true);
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackButon()
    {
        pauseMenu.SetActive(true);

        volumeMenu.SetActive(false);
        displayMenu.SetActive(false);
    }

    // Game UI
    public void PauseButton()
    {
        if (SoccerManager.instance.gameState == GameState.Playing)
        {
            SoccerManager.instance.gameState = GameState.Paused;
        }
        else if (SoccerManager.instance.gameState == GameState.Paused)
        {
            ResumeButton();
        }
    }
}
