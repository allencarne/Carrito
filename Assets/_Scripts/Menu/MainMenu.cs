using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
