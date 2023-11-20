using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoccerMenu : MonoBehaviour
{
    public void FreePlayButton()
    {
        // Tell the GameManager that FreePlay is Selected

        SceneManager.LoadScene("Soccer");
    }

    public void TrainingButton()
    {
        // Tell the GameManager that FreePlay is Selected

        SceneManager.LoadScene("Soccer");
    }
}
