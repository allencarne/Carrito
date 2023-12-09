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

    // Update is called once per frame
    void Update()
    {
        if (SoccerManager.instance.blue1Instance != null)
        {
            blue1cBoost = SoccerManager.instance.blue1Instance.GetComponent<Player>().currentBoost;
            blue1mBoost = SoccerManager.instance.blue1Instance.GetComponent<Player>().maxBoost;

            UpdateBoostBar(blue1Boost, blue1cBoost, blue1mBoost);

            red1cBoost = SoccerManager.instance.red1Instance.GetComponent<Player>().currentBoost;
            red1mBoost = SoccerManager.instance.red1Instance.GetComponent<Player>().maxBoost;

            UpdateBoostBar(red1Boost, red1cBoost, red1mBoost);
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
