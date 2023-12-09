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

    // Update is called once per frame
    void Update()
    {
        // Retrieve player types from PlayerPrefs
        blue1PlayerType = (PlayerType)Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Blue1Type", PlayerType.None.ToString()));
        red1PlayerType = (PlayerType)Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Red1Type", PlayerType.None.ToString()));


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
