using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SoccerMenu : MonoBehaviour
{
    [Header("Sides")]
    [SerializeField] GameObject blueSide;
    [SerializeField] GameObject redSide;

    [Header("Blue 1")]
    [SerializeField] GameObject blue1;
    [SerializeField] TextMeshProUGUI blue1Text;
    [SerializeField] Button blue1Left;
    [SerializeField] Button blue1Right;

    [Header("Red 1")]
    [SerializeField] GameObject red1;
    [SerializeField] TextMeshProUGUI red1Text;
    [SerializeField] Button red1Left;
    [SerializeField] Button red1Right;

    [Header("Blue 2")]
    [SerializeField] GameObject blue2;
    [SerializeField] TextMeshProUGUI blue2Text;
    [SerializeField] Button blue2Left;
    [SerializeField] Button blue2Right;

    [Header("Red 2")]
    [SerializeField] GameObject red2;
    [SerializeField] TextMeshProUGUI red2Text;
    [SerializeField] Button red2Left;
    [SerializeField] Button red2Right;

    [Header("Blue 3")]
    [SerializeField] GameObject blue3;
    [SerializeField] TextMeshProUGUI blue3Text;
    [SerializeField] Button blue3Left;
    [SerializeField] Button blue3Right;

    [Header("Red 3")]
    [SerializeField] GameObject red3;
    [SerializeField] TextMeshProUGUI red3Text;
    [SerializeField] Button red3Left;
    [SerializeField] Button red3Right;

    [SerializeField] GameObject playButton;

    enum PlayerType 
    {
        None,
        AI,
        Player1,
        Player2,
        Player3,
        Player4,
        Player5,
        Player6,
    }

    private void Start()
    {
        blueSide.SetActive(false);
        redSide.SetActive(false);

        blue1.SetActive(false);
        red1.SetActive(false);

        blue2.SetActive(false);
        red2.SetActive(false);

        blue3.SetActive(false);
        red3.SetActive(false);

        playButton.SetActive(false);
    }

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
        // Buttons
        blueSide.SetActive(true);
        redSide.SetActive(true);

        blue1.SetActive(true);
        red1.SetActive(true);

        blue2.SetActive(false);
        red2.SetActive(false);

        blue3.SetActive(false);
        red3.SetActive(false);
    }

    public void TwoVsTwoButton()
    {
        // Buttons
        blueSide.SetActive(true);
        redSide.SetActive(true);

        blue1.SetActive(true);
        red1.SetActive(true);

        blue2.SetActive(true);
        red2.SetActive(true);

        blue3.SetActive(false);
        red3.SetActive(false);
    }

    public void ThreeVsThreeButton()
    {
        // Buttons
        blueSide.SetActive(true);
        redSide.SetActive(true);

        blue1.SetActive(true);
        red1.SetActive(true);

        blue2.SetActive(true);
        red2.SetActive(true);

        blue3.SetActive(true);
        red3.SetActive(true);
    }
}
