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

    }

    public void BattleButton()
    {

    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
