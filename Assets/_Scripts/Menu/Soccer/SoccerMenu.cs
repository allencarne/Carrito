using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class SoccerMenu : MonoBehaviour
{
    public bool isOneVsOneActive = false;
    public bool isTwoVsTwoActive = false;
    public bool isThreeVsThreeActive = false;

    [Header("Panels")]
    [SerializeField] GameObject blueSidePanel;
    [SerializeField] GameObject redSidePanel;

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

    public PlayerType Blue1Type = PlayerType.Player1;
    public PlayerType Red1Type = PlayerType.AI;

    public PlayerType Blue2Type = PlayerType.AI;
    public PlayerType Red2Type = PlayerType.AI;

    public PlayerType Blue3Type = PlayerType.AI;
    public PlayerType Red3Type = PlayerType.AI;

    private void Start()
    {
        // Panel
        blueSidePanel.SetActive(false);
        redSidePanel.SetActive(false);

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
        bool isBlue1Passing = Blue1Type != PlayerType.AI && (Blue1Type == Blue2Type || Blue1Type == Blue3Type || Blue1Type == Red1Type || Blue1Type == Red2Type || Blue1Type == Red3Type);
        bool isBlue2Passing = Blue2Type != PlayerType.AI && (Blue2Type == Blue1Type || Blue2Type == Blue3Type || Blue2Type == Red1Type || Blue2Type == Red2Type || Blue2Type == Red3Type);
        bool isBlue3Passing = Blue3Type != PlayerType.AI && (Blue3Type == Blue1Type || Blue3Type == Blue2Type || Blue3Type == Red1Type || Blue3Type == Red2Type || Blue3Type == Red3Type);

        bool isRed1Passing = Red1Type != PlayerType.AI && (Red1Type == Blue1Type || Red1Type == Blue2Type || Red1Type == Blue3Type || Red1Type == Red2Type || Red1Type == Red3Type);
        bool isRed2Passing = Red2Type != PlayerType.AI && (Red2Type == Blue1Type || Red2Type == Blue2Type || Red2Type == Blue3Type || Red2Type == Red1Type || Red2Type == Red3Type);
        bool isRed3Passing = Red3Type != PlayerType.AI && (Red3Type == Blue1Type || Red3Type == Blue2Type || Red3Type == Blue3Type || Red3Type == Red1Type || Red3Type == Red2Type);

        if (isOneVsOneActive)
        {
            if (isBlue1Passing || isRed1Passing)
            {
                playButton.SetActive(false);
            }
            else
            {
                playButton.SetActive(true);
            }
        }

        if (isTwoVsTwoActive)
        {
            if (isBlue1Passing || isRed1Passing || isBlue2Passing || isRed2Passing)
            {
                playButton.SetActive(false);
            }
            else
            {
                playButton.SetActive(true);
            }
        }

        if (isThreeVsThreeActive)
        {
            if (isBlue1Passing || isRed1Passing || isBlue2Passing || isRed2Passing || isBlue3Passing || isRed3Passing)
            {
                playButton.SetActive(false);
            }
            else
            {
                playButton.SetActive(true);
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
        isThreeVsThreeActive = false;

        // Panels
        blueSidePanel.SetActive(true);
        redSidePanel.SetActive(true);

        blue1.SetActive(true);
        red1.SetActive(true);

        blue2.SetActive(false);
        red2.SetActive(false);

        blue3.SetActive(false);
        red3.SetActive(false);

        // Blue
        blue1Text.text = Blue1Type.ToString();

        // Red
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
        isThreeVsThreeActive = false;

        // Panels
        blueSidePanel.SetActive(true);
        redSidePanel.SetActive(true);

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
        isThreeVsThreeActive = true;

        // Panels
        blueSidePanel.SetActive(true);
        redSidePanel.SetActive(true);

        blue1.SetActive(true);
        red1.SetActive(true);

        blue2.SetActive(true);
        red2.SetActive(true);

        blue3.SetActive(true);
        red3.SetActive(true);

        // Blue
        blue1Text.text = Blue1Type.ToString();
        blue2Text.text = Blue2Type.ToString();
        blue3Text.text = Blue3Type.ToString();

        // Red
        red1Text.text = Red1Type.ToString();
        red2Text.text = Red2Type.ToString();
        red3Text.text = Red3Type.ToString();
    }

    public void Blue3Left()
    {
        // Calculate the new value (cycling back to the end)
        Blue3Type = (PlayerType)(((int)Blue3Type - 1 + 7) % 7);

        // Update the UI text
        blue3Text.text = Blue3Type.ToString();
    }

    public void Blue3Right()
    {
        // Calculate the new value (cycling back to the beginning)
        Blue3Type = (PlayerType)(((int)Blue3Type + 1) % 7);

        // Update the UI text
        blue3Text.text = Blue3Type.ToString();
    }

    public void Red3Left()
    {
        // Calculate the new value (cycling back to the end)
        Red3Type = (PlayerType)(((int)Red3Type - 1 + 7) % 7);

        // Update the UI text
        red3Text.text = Red3Type.ToString();
    }

    public void Red3Right()
    {
        // Calculate the new value (cycling back to the beginning)
        Red3Type = (PlayerType)(((int)Red3Type + 1) % 7);

        // Update the UI text
        red3Text.text = Red3Type.ToString();
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

        if (isThreeVsThreeActive)
        {
            PlayerPrefs.SetInt("GameMode", (int)SoccerManager.GameMode.ThreeVsThree);

            PlayerPrefs.SetString("Blue1Type", Blue1Type.ToString());
            PlayerPrefs.SetString("Red1Type", Red1Type.ToString());

            PlayerPrefs.SetString("Blue2Type", Blue2Type.ToString());
            PlayerPrefs.SetString("Red2Type", Red2Type.ToString());

            PlayerPrefs.SetString("Blue3Type", Blue3Type.ToString());
            PlayerPrefs.SetString("Red3Type", Red3Type.ToString());

            PlayerPrefs.Save();

            SceneManager.LoadScene("Soccer");
        }
    }
}
