using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFrames : MonoBehaviour
{
    [SerializeField] Image player1Boost;
    float player1cBoost;
    float player1mBoost;

    [SerializeField] Image player2Boost;
    float player2cBoost;
    float player2mBoost;

    [SerializeField] Image player3Boost;
    float player3cBoost;
    float player3mBoost;

    [SerializeField] Image player4Boost;
    float player4cBoost;
    float player4mBoost;

    [SerializeField] Image player5Boost;
    float player5cBoost;
    float player5mBoost;

    [SerializeField] Image player6Boost;
    float player6cBoost;
    float player6mBoost;

    // Update is called once per frame
    void Update()
    {
        if (SoccerManager.instance.bluePlayerInstance != null)
        {
            player1cBoost = SoccerManager.instance.bluePlayerInstance.GetComponent<Player>().currentBoost;
            player1mBoost = SoccerManager.instance.bluePlayerInstance.GetComponent<Player>().maxBoost;
        }

        UpdateBoostBar(player1Boost, player1cBoost, player1mBoost);
        //UpdateBoostBar(player2Boost, player2cBoost, player2mBoost);
        //UpdateBoostBar(player3Boost, player3cBoost, player3mBoost);
        //UpdateBoostBar(player4Boost, player4cBoost, player4mBoost);
        //UpdateBoostBar(player5Boost, player5cBoost, player5mBoost);
        //UpdateBoostBar(player6Boost, player6cBoost, player6edmBoost);
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
