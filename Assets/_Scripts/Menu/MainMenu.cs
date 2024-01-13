using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource menuHover;
    [SerializeField] AudioSource menuSelect;

    private void Start()
    {
        // Reset the Time Scale (for allowing the particles to play)
        Time.timeScale = 1;

        // Reset the PlayerPrefs for tracking Current Training
        PlayerPrefs.SetInt("ResetS1", 0);
        PlayerPrefs.SetInt("ResetS2", 0);
        PlayerPrefs.SetInt("ResetS3", 0);
        PlayerPrefs.SetInt("ResetS4", 0);
        PlayerPrefs.SetInt("ResetS5", 0);
        PlayerPrefs.SetInt("ResetS6", 0);
        PlayerPrefs.SetInt("ResetS7", 0);
        PlayerPrefs.SetInt("ResetS8", 0);
        PlayerPrefs.SetInt("ResetS9", 0);
        PlayerPrefs.SetInt("ResetS10", 0);
        PlayerPrefs.SetInt("ResetD1", 0);
        PlayerPrefs.SetInt("ResetD2", 0);
        PlayerPrefs.SetInt("ResetD3", 0);
        PlayerPrefs.SetInt("ResetD4", 0);
        PlayerPrefs.SetInt("ResetD5", 0);
        PlayerPrefs.SetInt("ResetD6", 0);
        PlayerPrefs.SetInt("ResetD7", 0);
        PlayerPrefs.SetInt("ResetD8", 0);
        PlayerPrefs.SetInt("ResetD9", 0);
        PlayerPrefs.SetInt("ResetD10", 0);
    }

    public void SoccerButton()
    {
        //StartCoroutine(MenuDelay("SoccerMenu"));
        SceneManager.LoadScene("SoccerMenu");
    }

    public void RaceButton()
    {
        //StartCoroutine(MenuDelay("RaceMenu"));
        SceneManager.LoadScene("RaceMenu");
    }

    public void BattleButton()
    {
        //StartCoroutine(MenuDelay("BattleMenu"));
        SceneManager.LoadScene("BattleMenu");
    }

    public void OptionsButton()
    {
        //StartCoroutine(MenuDelay("OptionsMenu"));
        SceneManager.LoadScene("OptionsMenu");
    }

    public void BindsButton()
    {
        //StartCoroutine(MenuDelay("BindsMenu"));
        SceneManager.LoadScene("BindsMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void MenuHover()
    {
        menuHover.Play();
    }

    public void MenuSelect()
    {
        menuSelect.Play();
    }
}
