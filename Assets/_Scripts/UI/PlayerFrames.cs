using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFrames : MonoBehaviour
{
    [SerializeField] Image blue1Boost;
    float blue1cBoost;
    float blue1mBoost;

    [SerializeField] Image blue2Boost;
    float blue2cBoost;
    float blue2mBoost;

    [SerializeField] Image blue3Boost;
    float blue3cBoost;
    float blue3mBoost;

    [SerializeField] Image red1Boost;
    float red1cBoost;
    float red1mBoost;

    [SerializeField] Image red2Boost;
    float red2cBoost;
    float red2mBoost;

    [SerializeField] Image red3Boost;
    float red3cBoost;
    float red3mBoost;

    public enum PlayerType
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

    PlayerType blue1PlayerType = PlayerType.None;
    PlayerType red1PlayerType = PlayerType.None;

    PlayerType blue2PlayerType = PlayerType.None;
    PlayerType red2PlayerType = PlayerType.None;

    PlayerType blue3PlayerType = PlayerType.None;
    PlayerType red3PlayerType = PlayerType.None;

    // Update is called once per frame
    void Update()
    {
        // Retrieve player types from PlayerPrefs
        blue1PlayerType = (PlayerType)Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Blue1Type", PlayerType.None.ToString()));
        red1PlayerType = (PlayerType)Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Red1Type", PlayerType.None.ToString()));

        blue2PlayerType = (PlayerType)Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Blue2Type", PlayerType.None.ToString()));
        red2PlayerType = (PlayerType)Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Red2Type", PlayerType.None.ToString()));

        blue3PlayerType = (PlayerType)Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Blue3Type", PlayerType.None.ToString()));
        red3PlayerType = (PlayerType)Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Red3Type", PlayerType.None.ToString()));

        switch (SoccerManager.instance.gameMode)
        {
            case SoccerManager.GameMode.FreePlay:
                FreePlay();
                break;
            case SoccerManager.GameMode.Training:
                Training();
                break;
            case SoccerManager.GameMode.OneVsOne:
                OneVsOne();
                break;
            case SoccerManager.GameMode.TwoVsTwo:
                OneVsOne();
                TwoVsTwo();
                break;
            case SoccerManager.GameMode.ThreeVsThree:
                OneVsOne();
                TwoVsTwo();
                ThreeVsThree();
                break;
        }
    }

    void FreePlay()
    {
        if (SoccerManager.instance != null)
        {
            if (SoccerManager.instance.blue1Instance != null)
            {
                blue1cBoost = SoccerManager.instance.blue1Instance.GetComponent<Player>().currentBoost;
                blue1mBoost = SoccerManager.instance.blue1Instance.GetComponent<Player>().maxBoost;

                UpdateBoostBar(blue1Boost, blue1cBoost, blue1mBoost);
            }
        }
    }

    void Training()
    {

    }

    void OneVsOne()
    {
        if (SoccerManager.instance != null)
        {
            if (SoccerManager.instance.blue1Instance != null)
            {
                if (blue1PlayerType == PlayerType.AI)
                {
                    blue1cBoost = SoccerManager.instance.blue1Instance.GetComponent<SoccerAI>().currentBoost;
                    blue1mBoost = SoccerManager.instance.blue1Instance.GetComponent<SoccerAI>().maxBoost;

                    UpdateBoostBar(blue1Boost, blue1cBoost, blue1mBoost);
                }
                else
                {
                    blue1cBoost = SoccerManager.instance.blue1Instance.GetComponent<Player>().currentBoost;
                    blue1mBoost = SoccerManager.instance.blue1Instance.GetComponent<Player>().maxBoost;

                    UpdateBoostBar(blue1Boost, blue1cBoost, blue1mBoost);
                }
            }

            if (SoccerManager.instance.red1Instance != null)
            {
                if (red1PlayerType == PlayerType.AI)
                {
                    red1cBoost = SoccerManager.instance.red1Instance.GetComponent<SoccerAI>().currentBoost;
                    red1mBoost = SoccerManager.instance.red1Instance.GetComponent<SoccerAI>().maxBoost;

                    UpdateBoostBar(red1Boost, red1cBoost, red1mBoost);
                }
                else
                {
                    red1cBoost = SoccerManager.instance.red1Instance.GetComponent<Player>().currentBoost;
                    red1mBoost = SoccerManager.instance.red1Instance.GetComponent<Player>().maxBoost;

                    UpdateBoostBar(red1Boost, red1cBoost, red1mBoost);
                }
            }
        }
    }

    void TwoVsTwo()
    {
        if (SoccerManager.instance != null)
        {
            if (SoccerManager.instance.blue2Instance != null)
            {
                if (blue2PlayerType == PlayerType.AI)
                {
                    blue2cBoost = SoccerManager.instance.blue2Instance.GetComponent<SoccerAI>().currentBoost;
                    blue2mBoost = SoccerManager.instance.blue2Instance.GetComponent<SoccerAI>().maxBoost;

                    UpdateBoostBar(blue2Boost, blue2cBoost, blue2mBoost);
                }
                else
                {
                    blue2cBoost = SoccerManager.instance.blue2Instance.GetComponent<Player>().currentBoost;
                    blue2mBoost = SoccerManager.instance.blue2Instance.GetComponent<Player>().maxBoost;

                    UpdateBoostBar(blue2Boost, blue2cBoost, blue2mBoost);
                }
            }

            if (SoccerManager.instance.red2Instance != null)
            {
                if (red2PlayerType == PlayerType.AI)
                {
                    red2cBoost = SoccerManager.instance.red2Instance.GetComponent<SoccerAI>().currentBoost;
                    red2mBoost = SoccerManager.instance.red2Instance.GetComponent<SoccerAI>().maxBoost;

                    UpdateBoostBar(red2Boost, red2cBoost, red2mBoost);
                }
                else
                {
                    red2cBoost = SoccerManager.instance.red2Instance.GetComponent<Player>().currentBoost;
                    red2mBoost = SoccerManager.instance.red2Instance.GetComponent<Player>().maxBoost;

                    UpdateBoostBar(red2Boost, red2cBoost, red2mBoost);
                }
            }
        }
    }

    void ThreeVsThree()
    {
        if (SoccerManager.instance != null)
        {
            if (SoccerManager.instance.blue3Instance != null)
            {
                if (blue3PlayerType == PlayerType.AI)
                {
                    blue3cBoost = SoccerManager.instance.blue3Instance.GetComponent<SoccerAI>().currentBoost;
                    blue3mBoost = SoccerManager.instance.blue3Instance.GetComponent<SoccerAI>().maxBoost;

                    UpdateBoostBar(blue3Boost, blue3cBoost, blue3mBoost);
                }
                else
                {
                    blue3cBoost = SoccerManager.instance.blue3Instance.GetComponent<Player>().currentBoost;
                    blue3mBoost = SoccerManager.instance.blue3Instance.GetComponent<Player>().maxBoost;

                    UpdateBoostBar(blue3Boost, blue3cBoost, blue3mBoost);
                }
            }

            if (SoccerManager.instance.red3Instance != null)
            {
                if (red3PlayerType == PlayerType.AI)
                {
                    red3cBoost = SoccerManager.instance.red3Instance.GetComponent<SoccerAI>().currentBoost;
                    red3mBoost = SoccerManager.instance.red3Instance.GetComponent<SoccerAI>().maxBoost;

                    UpdateBoostBar(red3Boost, red3cBoost, red3mBoost);
                }
                else
                {
                    red3cBoost = SoccerManager.instance.red3Instance.GetComponent<Player>().currentBoost;
                    red3mBoost = SoccerManager.instance.red3Instance.GetComponent<Player>().maxBoost;

                    UpdateBoostBar(red3Boost, red3cBoost, red3mBoost);
                }
            }
        }
    }

    void UpdateBoostBar(Image boostBar, float currentBoost, float maxBoost)
    {
        // Ensure that maxBoost is not zero to avoid division by zero
        if (maxBoost > 0)
        {
            // Calculate the fill amount based on the current and maximum boost values
            float fillAmount = currentBoost / maxBoost;

            // Clamp the fill amount between 0 and 1
            fillAmount = Mathf.Clamp01(fillAmount);

            // Update the fill amount of the boost bar
            boostBar.fillAmount = fillAmount;
        }
        else
        {
            // Handle the case where maxBoost is zero (optional)
            // You may want to set the fillAmount to 0 or take other actions
            boostBar.fillAmount = 0f;
        }
    }
}
