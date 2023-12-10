using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject volumeMenu;
    [SerializeField] GameObject displayMenu;

    private void OnEnable()
    {
        CustomPlayerInput.OnResumed += ResumeButton;
    }

    private void OnDisable()
    {
        CustomPlayerInput.OnResumed -= ResumeButton;
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);

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
}
