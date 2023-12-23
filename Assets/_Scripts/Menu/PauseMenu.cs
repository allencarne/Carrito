using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SoccerManager;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] GameObject pauseMenu;

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

        Time.timeScale = 1;

        SoccerManager.instance.gameState = SoccerManager.GameState.Playing;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
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
