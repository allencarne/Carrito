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
    //bool isTwoVsTwoActive = false;
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

    public enum Blue1Type
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

    enum Red1Type
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
            // Parse enum values to integers
            int blue1TypeValue = (int)(Blue1Type)Enum.Parse(typeof(Blue1Type), blue1Text.text);
            int red1TypeValue = (int)(Red1Type)Enum.Parse(typeof(Red1Type), red1Text.text);

            // Check if both are not players before checking distinctiveness
            if (blue1TypeValue != (int)Blue1Type.None && red1TypeValue != (int)Red1Type.None &&
                (blue1TypeValue != red1TypeValue || blue1TypeValue == (int)Blue1Type.AI || red1TypeValue == (int)Red1Type.AI))
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
        //isTwoVsTwoActive = false;
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
        blue1Text.text = Blue1Type.None.ToString();

        // Red 1
        red1Text.text = Red1Type.None.ToString();
    }

    public void Blue1Left()
    {
        // Get the current Blue1Type value
        Blue1Type currentType = (Blue1Type)Enum.Parse(typeof(Blue1Type), blue1Text.text);

        // Calculate the new value (cycling back to the end if reaching None)
        Blue1Type newType = (Blue1Type)(((int)currentType - 1 + 8) % 8);

        // Update the UI text
        blue1Text.text = newType.ToString();
    }

    public void Blue1Right()
    {
        // Get the current Blue1Type value
        Blue1Type currentType = (Blue1Type)Enum.Parse(typeof(Blue1Type), blue1Text.text);

        // Calculate the new value (cycling back to None if reaching the end)
        Blue1Type newType = (Blue1Type)(((int)currentType + 1) % 8);

        // Update the UI text
        blue1Text.text = newType.ToString();
    }

    public void Red1Left()
    {
        // Get the current Blue1Type value
        Red1Type currentType = (Red1Type)Enum.Parse(typeof(Red1Type), red1Text.text);

        // Calculate the new value (cycling back to the end if reaching None)
        Red1Type newType = (Red1Type)(((int)currentType - 1 + 8) % 8);

        // Update the UI text
        red1Text.text = newType.ToString();
    }

    public void Red1Right()
    {
        // Get the current Blue1Type value
        Red1Type currentType = (Red1Type)Enum.Parse(typeof(Red1Type), red1Text.text);

        // Calculate the new value (cycling back to None if reaching the end)
        Red1Type newType = (Red1Type)(((int)currentType + 1) % 8);

        // Update the UI text
        red1Text.text = newType.ToString();
    }

    public void TwoVsTwoButton()
    {
        // Bools
        isOneVsOneActive = false;
        //isTwoVsTwoActive = true;
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
    }

    public void ThreeVsThreeButton()
    {
        // Bools
        isOneVsOneActive = false;
        //isTwoVsTwoActive = false;
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
            int blue1TypeValue = (int)(Blue1Type)Enum.Parse(typeof(Blue1Type), blue1Text.text);
            int red1TypeValue = (int)(Red1Type)Enum.Parse(typeof(Red1Type), red1Text.text);

            if (blue1TypeValue != (int)Blue1Type.None && red1TypeValue != (int)Red1Type.None &&
                (blue1TypeValue != red1TypeValue || blue1TypeValue == (int)Blue1Type.AI || red1TypeValue == (int)Red1Type.AI))
            {
                PlayerPrefs.SetInt("GameMode", (int)SoccerManager.GameMode.OneVsOne);

                PlayerPrefs.SetString("Blue1Type", blue1Text.text);
                PlayerPrefs.SetString("Red1Type", red1Text.text);

                PlayerPrefs.Save();

                SceneManager.LoadScene("Soccer");
            }
        }
    }
}
