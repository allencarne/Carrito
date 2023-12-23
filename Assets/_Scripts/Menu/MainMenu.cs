using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
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
        SceneManager.LoadScene("SoccerMenu");
    }

    public void RaceButton()
    {
        SceneManager.LoadScene("RaceMenu");
    }

    public void BattleButton()
    {
        SceneManager.LoadScene("BattleMenu");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void BindsButton()
    {
        SceneManager.LoadScene("BindsMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
