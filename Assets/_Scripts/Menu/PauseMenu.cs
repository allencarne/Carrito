using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SoccerManager.instance.gameState == SoccerManager.GameState.Playing)
        {
            SoccerManager.instance.gameState = SoccerManager.GameState.Paused;
        }
        else if (SoccerManager.instance.gameState == SoccerManager.GameState.Paused)
        {
            ResumeButton();
        }
    }

    public void ResetButton()
    {
        if (SoccerManager.instance.gameMode == SoccerManager.GameMode.FreePlay)
        {
            if (SoccerManager.instance.gameState == SoccerManager.GameState.Playing)
            {
                SceneManager.LoadScene("Soccer");
            }
        }

        if (SoccerManager.instance.gameMode == SoccerManager.GameMode.Training)
        {
            if (SoccerManager.instance.gameState == SoccerManager.GameState.Playing)
            {
                SoccerManager.instance.GetComponent<SoccerTraining>().ReloadTrainingLevel();
            }
        }
    }
}
