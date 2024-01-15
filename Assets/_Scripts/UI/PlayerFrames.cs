using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFrames : MonoBehaviour
{
    [SerializeField] GameObject blue1Frame;
    [SerializeField] Image blue1Boost;
    [SerializeField] Image blue1Picture;
    float blue1cBoost;
    float blue1mBoost;

    [SerializeField] GameObject blue2Frame;
    [SerializeField] Image blue2Boost;
    [SerializeField] Image blue2Picture;
    float blue2cBoost;
    float blue2mBoost;

    [SerializeField] GameObject blue3Frame;
    [SerializeField] Image blue3Boost;
    [SerializeField] Image blue3Picture;
    float blue3cBoost;
    float blue3mBoost;

    [SerializeField] GameObject red1Frame;
    [SerializeField] Image red1Boost;
    [SerializeField] Image red1Picture;
    float red1cBoost;
    float red1mBoost;

    [SerializeField] GameObject red2Frame;
    [SerializeField] Image red2Boost;
    [SerializeField] Image red2Picture;
    float red2cBoost;
    float red2mBoost;

    [SerializeField] GameObject red3Frame;
    [SerializeField] Image red3Boost;
    [SerializeField] Image red3Picture;
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

    private void Awake()
    {

    }

    private void Start()
    {
        RectTransform rectTransform = blue1Frame.GetComponent<RectTransform>();


        switch (SoccerManager.instance.gameMode)
        {
            case SoccerManager.GameMode.FreePlay:

                rectTransform.anchoredPosition = new Vector2(0f, rectTransform.anchoredPosition.y);

                blue1Frame.SetActive(true);
                blue2Frame.SetActive(false);
                blue3Frame.SetActive(false);
                red1Frame.SetActive(false);
                red2Frame.SetActive(false);
                red3Frame.SetActive(false);
                break;
            case SoccerManager.GameMode.Training:

                rectTransform.anchoredPosition = new Vector2(0f, rectTransform.anchoredPosition.y);

                blue1Frame.SetActive(true);
                blue2Frame.SetActive(false);
                blue3Frame.SetActive(false);
                red1Frame.SetActive(false);
                red2Frame.SetActive(false);
                red3Frame.SetActive(false);
                break;
            case SoccerManager.GameMode.OneVsOne:
                blue1Frame.SetActive(true);
                blue2Frame.SetActive(false);
                blue3Frame.SetActive(false);
                red1Frame.SetActive(true);
                red2Frame.SetActive(false);
                red3Frame.SetActive(false);
                break;
            case SoccerManager.GameMode.TwoVsTwo:
                blue1Frame.SetActive(true);
                blue2Frame.SetActive(true);
                blue3Frame.SetActive(false);
                red1Frame.SetActive(true);
                red2Frame.SetActive(true);
                red3Frame.SetActive(false);
                break;
            case SoccerManager.GameMode.ThreeVsThree:
                blue1Frame.SetActive(true);
                blue2Frame.SetActive(true);
                blue3Frame.SetActive(true);
                red1Frame.SetActive(true);
                red2Frame.SetActive(true);
                red3Frame.SetActive(true);
                break;
        }
    }

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

                // Find the "Body" GameObject within the hierarchy
                Transform bodyTransform = SoccerManager.instance.blue1Instance.transform.Find("Body");

                // Get the SpriteRenderer from the "Body" GameObject
                SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                // Update Picture Color
                blue1Picture.color = bodySpriteRenderer.color;

                UpdateBoostBar(blue1Boost, blue1cBoost, blue1mBoost);
            }
        }
    }

    void Training()
    {
        if (SoccerManager.instance != null)
        {
            if (SoccerManager.instance.blue1Instance != null)
            {
                blue1cBoost = SoccerManager.instance.blue1Instance.GetComponent<Player>().currentBoost;
                blue1mBoost = SoccerManager.instance.blue1Instance.GetComponent<Player>().maxBoost;

                // Find the "Body" GameObject within the hierarchy
                Transform bodyTransform = SoccerManager.instance.blue1Instance.transform.Find("Body");

                // Get the SpriteRenderer from the "Body" GameObject
                SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                // Update Picture Color
                blue1Picture.color = bodySpriteRenderer.color;

                UpdateBoostBar(blue1Boost, blue1cBoost, blue1mBoost);
            }
        }
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

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.blue1Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    blue1Picture.color = bodySpriteRenderer.color;

                    UpdateBoostBar(blue1Boost, blue1cBoost, blue1mBoost);
                }
                else
                {
                    blue1cBoost = SoccerManager.instance.blue1Instance.GetComponent<Player>().currentBoost;
                    blue1mBoost = SoccerManager.instance.blue1Instance.GetComponent<Player>().maxBoost;

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.blue1Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    blue1Picture.color = bodySpriteRenderer.color;

                    UpdateBoostBar(blue1Boost, blue1cBoost, blue1mBoost);
                }
            }

            if (SoccerManager.instance.red1Instance != null)
            {
                if (red1PlayerType == PlayerType.AI)
                {
                    red1cBoost = SoccerManager.instance.red1Instance.GetComponent<SoccerAI>().currentBoost;
                    red1mBoost = SoccerManager.instance.red1Instance.GetComponent<SoccerAI>().maxBoost;

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.red1Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    red1Picture.color = bodySpriteRenderer.color;

                    UpdateBoostBar(red1Boost, red1cBoost, red1mBoost);
                }
                else
                {
                    red1cBoost = SoccerManager.instance.red1Instance.GetComponent<Player>().currentBoost;
                    red1mBoost = SoccerManager.instance.red1Instance.GetComponent<Player>().maxBoost;

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.red1Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    red1Picture.color = bodySpriteRenderer.color;

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

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.blue2Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    blue2Picture.color = bodySpriteRenderer.color;

                    UpdateBoostBar(blue2Boost, blue2cBoost, blue2mBoost);
                }
                else
                {
                    blue2cBoost = SoccerManager.instance.blue2Instance.GetComponent<Player>().currentBoost;
                    blue2mBoost = SoccerManager.instance.blue2Instance.GetComponent<Player>().maxBoost;

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.blue2Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    blue2Picture.color = bodySpriteRenderer.color;

                    UpdateBoostBar(blue2Boost, blue2cBoost, blue2mBoost);
                }
            }

            if (SoccerManager.instance.red2Instance != null)
            {
                if (red2PlayerType == PlayerType.AI)
                {
                    red2cBoost = SoccerManager.instance.red2Instance.GetComponent<SoccerAI>().currentBoost;
                    red2mBoost = SoccerManager.instance.red2Instance.GetComponent<SoccerAI>().maxBoost;

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.red2Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    red2Picture.color = bodySpriteRenderer.color;

                    UpdateBoostBar(red2Boost, red2cBoost, red2mBoost);
                }
                else
                {
                    red2cBoost = SoccerManager.instance.red2Instance.GetComponent<Player>().currentBoost;
                    red2mBoost = SoccerManager.instance.red2Instance.GetComponent<Player>().maxBoost;

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.red2Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    red2Picture.color = bodySpriteRenderer.color;

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

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.blue3Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    blue3Picture.color = bodySpriteRenderer.color;

                    UpdateBoostBar(blue3Boost, blue3cBoost, blue3mBoost);
                }
                else
                {
                    blue3cBoost = SoccerManager.instance.blue3Instance.GetComponent<Player>().currentBoost;
                    blue3mBoost = SoccerManager.instance.blue3Instance.GetComponent<Player>().maxBoost;

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.blue3Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    blue3Picture.color = bodySpriteRenderer.color;

                    UpdateBoostBar(blue3Boost, blue3cBoost, blue3mBoost);
                }
            }

            if (SoccerManager.instance.red3Instance != null)
            {
                if (red3PlayerType == PlayerType.AI)
                {
                    red3cBoost = SoccerManager.instance.red3Instance.GetComponent<SoccerAI>().currentBoost;
                    red3mBoost = SoccerManager.instance.red3Instance.GetComponent<SoccerAI>().maxBoost;

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.red3Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    red3Picture.color = bodySpriteRenderer.color;

                    UpdateBoostBar(red3Boost, red3cBoost, red3mBoost);
                }
                else
                {
                    red3cBoost = SoccerManager.instance.red3Instance.GetComponent<Player>().currentBoost;
                    red3mBoost = SoccerManager.instance.red3Instance.GetComponent<Player>().maxBoost;

                    // Find the "Body" GameObject within the hierarchy
                    Transform bodyTransform = SoccerManager.instance.red3Instance.transform.Find("Body");

                    // Get the SpriteRenderer from the "Body" GameObject
                    SpriteRenderer bodySpriteRenderer = bodyTransform.GetComponent<SpriteRenderer>();

                    // Update Picture Color
                    red3Picture.color = bodySpriteRenderer.color;

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
