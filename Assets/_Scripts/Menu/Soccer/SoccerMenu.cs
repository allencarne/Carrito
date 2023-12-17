using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class SoccerMenu : MonoBehaviour
{
    bool isOneVsOneActive = false;
    bool isTwoVsTwoActive = false;
    //bool isThreeVsThreeActive = false;

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

    public enum PlayerType
    {
        AI,
        Player1,
        Player2,
        Player3,
        Player4,
        Player5,
        Player6,
    }

    PlayerType Blue1Type = PlayerType.Player1;
    PlayerType Red1Type = PlayerType.AI;

    PlayerType Blue2Type = PlayerType.AI;
    PlayerType Red2Type = PlayerType.AI;

    private void Start()
    {
        // Setup
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

    private void Update()
    {
        if (isOneVsOneActive)
        {
            // Check if both are not the same human player or both are AI
            if (Blue1Type != Red1Type || (Blue1Type == PlayerType.AI && Red1Type == PlayerType.AI))
            {
                playButton.SetActive(true);
            }
            else
            {
                playButton.SetActive(false);
            }
        }

        if (isTwoVsTwoActive)
        {
            // Check if all pairs are not the same human player or both are AI
            if ((Blue1Type != Red1Type || (Blue1Type == PlayerType.AI && Red1Type == PlayerType.AI)) &&
                (Blue2Type != Red2Type || (Blue2Type == PlayerType.AI && Red2Type == PlayerType.AI)) &&
                (Blue1Type != Blue2Type || (Blue1Type == PlayerType.AI && Blue2Type == PlayerType.AI)) &&
                (Red1Type != Red2Type || (Red1Type == PlayerType.AI && Red2Type == PlayerType.AI)))
            {
                playButton.SetActive(true);
            }
            else
            {
                playButton.SetActive(false);
            }
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void FreePlayButton()
    {
        // Tell the SoccerManager that FreePlay is Selected
        PlayerPrefs.SetInt("GameMode", (int)SoccerManager.GameMode.FreePlay);

        SceneManager.LoadScene("Soccer");
    }

    public void TrainingButton()
    {
        // Tell the SoccerManager that Training is Selected
        PlayerPrefs.SetInt("GameMode", (int)SoccerManager.GameMode.Training);

        SceneManager.LoadScene("Soccer");
    }

    public void OneVsOneButton()
    {
        // Bools
        isOneVsOneActive = true;
        isTwoVsTwoActive = false;
        //isThreeVsThreeActive = false;

        // Buttons
        blueSide.SetActive(true);
        redSide.SetActive(true);

        blue1.SetActive(true);
        red1.SetActive(true);

        blue2.SetActive(false);
        red2.SetActive(false);

        blue3.SetActive(false);
        red3.SetActive(false);

        // Blue 1
        blue1Text.text = Blue1Type.ToString();

        // Red 1
        red1Text.text = Red1Type.ToString();
    }

    public void Blue1Left()
    {
        // Calculate the new value (cycling back to the end)
        Blue1Type = (PlayerType)(((int)Blue1Type - 1 + 7) % 7);

        // Update the UI text
        blue1Text.text = Blue1Type.ToString();
    }

    public void Blue1Right()
    {
        // Calculate the new value (cycling back to the beginning)
        Blue1Type = (PlayerType)(((int)Blue1Type + 1) % 7);

        // Update the UI text
        blue1Text.text = Blue1Type.ToString();
    }

    public void Red1Left()
    {
        // Calculate the new value (cycling back to the end)
        Red1Type = (PlayerType)(((int)Red1Type - 1 + 7) % 7);

        // Update the UI text
        red1Text.text = Red1Type.ToString();
    }

    public void Red1Right()
    {
        // Calculate the new value (cycling back to the beginning)
        Red1Type = (PlayerType)(((int)Red1Type + 1) % 7);

        // Update the UI text
        red1Text.text = Red1Type.ToString();
    }

    public void TwoVsTwoButton()
    {
        // Bools
        isOneVsOneActive = false;
        isTwoVsTwoActive = true;
        //isThreeVsThreeActive = false;

        // Buttons
        blueSide.SetActive(true);
        redSide.SetActive(true);

        blue1.SetActive(true);
        red1.SetActive(true);

        blue2.SetActive(true);
        red2.SetActive(true);

        blue3.SetActive(false);
        red3.SetActive(false);

        // Blue
        blue1Text.text = Blue1Type.ToString();
        blue2Text.text = Blue2Type.ToString();

        // Red
        red1Text.text = Red1Type.ToString();
        red2Text.text = Red2Type.ToString();
    }

    public void Blue2Left()
    {
        // Calculate the new value (cycling back to the end)
        Blue2Type = (PlayerType)(((int)Blue2Type - 1 + 7) % 7);

        // Update the UI text
        blue2Text.text = Blue2Type.ToString();
    }

    public void Blue2Right()
    {
        // Calculate the new value (cycling back to the beginning)
        Blue2Type = (PlayerType)(((int)Blue2Type + 1) % 7);

        // Update the UI text
        blue2Text.text = Blue2Type.ToString();
    }

    public void Red2Left()
    {
        // Calculate the new value (cycling back to the end)
        Red2Type = (PlayerType)(((int)Red2Type - 1 + 7) % 7);

        // Update the UI text
        red2Text.text = Red2Type.ToString();
    }

    public void Red2Right()
    {
        // Calculate the new value (cycling back to the beginning)
        Red2Type = (PlayerType)(((int)Red2Type + 1) % 7);

        // Update the UI text
        red2Text.text = Red2Type.ToString();
    }

    public void ThreeVsThreeButton()
    {
        // Bools
        isOneVsOneActive = false;
        isTwoVsTwoActive = false;
        //isThreeVsThreeActive = true;

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

    public void PlayButton()
    {
        if (isOneVsOneActive)
        {
            PlayerPrefs.SetInt("GameMode", (int)SoccerManager.GameMode.OneVsOne);

            PlayerPrefs.SetString("Blue1Type", Blue1Type.ToString());
            PlayerPrefs.SetString("Red1Type", Red1Type.ToString());

            PlayerPrefs.Save();

            SceneManager.LoadScene("Soccer");
        }

        if (isTwoVsTwoActive)
        {
            PlayerPrefs.SetInt("GameMode", (int)SoccerManager.GameMode.TwoVsTwo);

            PlayerPrefs.SetString("Blue1Type", Blue1Type.ToString());
            PlayerPrefs.SetString("Red1Type", Red1Type.ToString());

            PlayerPrefs.SetString("Blue2Type", Blue2Type.ToString());
            PlayerPrefs.SetString("Red2Type", Red2Type.ToString());

            PlayerPrefs.Save();

            SceneManager.LoadScene("Soccer");
        }
    }
}
