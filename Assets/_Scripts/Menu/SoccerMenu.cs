using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoccerMenu : MonoBehaviour
{
    public void FreePlayButton()
    {
        // Tell the GameManager that FreePlay is Selected
        PlayerPrefs.SetInt("GameMode", (int)SoccerManager.GameMode.FreePlay);

        SceneManager.LoadScene("Soccer");
    }

    public void TrainingButton()
    {
        // Tell the GameManager that FreePlay is Selected
        PlayerPrefs.SetInt("GameMode", (int)SoccerManager.GameMode.Training);

        SceneManager.LoadScene("Soccer");
    }

    public void OneVsOneButton()
    {
        // Game Mode

        // Players

        SceneManager.LoadScene("Soccer");
    }

    public void TwoVsTwoButton()
    {
        // Game Mode

        // Players

        SceneManager.LoadScene("Soccer");
    }

    public void ThreeVsThreeButton()
    {
        // Game Mode

        // Players

        SceneManager.LoadScene("Soccer");
    }
}
