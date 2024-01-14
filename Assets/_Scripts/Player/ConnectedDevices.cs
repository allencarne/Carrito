using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConnectedDevices : MonoBehaviour
{
    [SerializeField] SoccerMenu menu;

    [Header("Blue 1")]
    [SerializeField] Button blue1;
    [SerializeField] TextMeshProUGUI blue1Text;
    [SerializeField] Button blue1Left;
    [SerializeField] Button blue1Right;

    [Header("Blue 2")]
    [SerializeField] Button blue2;
    [SerializeField] TextMeshProUGUI blue2Text;
    [SerializeField] Button blue2Left;
    [SerializeField] Button blue2Right;

    [Header("Blue 3")]
    [SerializeField] Button blue3;
    [SerializeField] TextMeshProUGUI blue3Text;
    [SerializeField] Button blue3Left;
    [SerializeField] Button blue3Right;

    [Header("Red 1")]
    [SerializeField] Button red1;
    [SerializeField] TextMeshProUGUI red1Text;
    [SerializeField] Button red1Left;
    [SerializeField] Button red1Right;

    [Header("Red 2")]
    [SerializeField] Button red2;
    [SerializeField] TextMeshProUGUI red2Text;
    [SerializeField] Button red2Left;
    [SerializeField] Button red2Right;

    [Header("Red 3")]
    [SerializeField] Button red3;
    [SerializeField] TextMeshProUGUI red3Text;
    [SerializeField] Button red3Left;
    [SerializeField] Button red3Right;

    public enum ControlType
    {
        Keyboard,
        GamePad,
    }

    ControlType Blue1ControlType = ControlType.Keyboard;
    ControlType Blue2ControlType = ControlType.GamePad;
    ControlType Blue3ControlType = ControlType.GamePad;
    ControlType Red1ControlType = ControlType.GamePad;
    ControlType Red2ControlType = ControlType.GamePad;
    ControlType Red3ControlType = ControlType.GamePad;

    void Start()
    {
        UpdatePlayerUI();
    }

    void Update()
    {
        if (menu.isOneVsOneActive)
        {
            if (menu.Blue1Type != SoccerMenu.PlayerType.AI)
            {
                blue1.gameObject.SetActive(true);
                blue1Left.gameObject.SetActive(true);
                blue1Right.gameObject.SetActive(true);
            }
            else
            {
                blue1.gameObject.SetActive(false);
                blue1Left.gameObject.SetActive(false);
                blue1Right.gameObject.SetActive(false);
            }

            if (menu.Red1Type != SoccerMenu.PlayerType.AI)
            {
                red1.gameObject.SetActive(true);
                red1Left.gameObject.SetActive(true);
                red1Right.gameObject.SetActive(true);
            }
            else
            {
                red1.gameObject.SetActive(false);
                red1Left.gameObject.SetActive(false);
                red1Right.gameObject.SetActive(false);
            }
        }

        if (menu.isTwoVsTwoActive)
        {
            // Blue 1
            if (menu.Blue1Type != SoccerMenu.PlayerType.AI)
            {
                blue1.gameObject.SetActive(true);
                blue1Left.gameObject.SetActive(true);
                blue1Right.gameObject.SetActive(true);
            }
            else
            {
                blue1.gameObject.SetActive(false);
                blue1Left.gameObject.SetActive(false);
                blue1Right.gameObject.SetActive(false);
            }

            // Red 1
            if (menu.Red1Type != SoccerMenu.PlayerType.AI)
            {
                red1.gameObject.SetActive(true);
                red1Left.gameObject.SetActive(true);
                red1Right.gameObject.SetActive(true);
            }
            else
            {
                red1.gameObject.SetActive(false);
                red1Left.gameObject.SetActive(false);
                red1Right.gameObject.SetActive(false);
            }

            // Blue 2
            if (menu.Blue2Type != SoccerMenu.PlayerType.AI)
            {
                blue2.gameObject.SetActive(true);
                blue2Left.gameObject.SetActive(true);
                blue2Right.gameObject.SetActive(true);
            }
            else
            {
                blue2.gameObject.SetActive(false);
                blue2Left.gameObject.SetActive(false);
                blue2Right.gameObject.SetActive(false);
            }

            // Red 2
            if (menu.Red2Type != SoccerMenu.PlayerType.AI)
            {
                red2.gameObject.SetActive(true);
                red2Left.gameObject.SetActive(true);
                red2Right.gameObject.SetActive(true);
            }
            else
            {
                red2.gameObject.SetActive(false);
                red2Left.gameObject.SetActive(false);
                red2Right.gameObject.SetActive(false);
            }
        }

        if (menu.isThreeVsThreeActive)
        {
            // Blue 1
            if (menu.Blue1Type != SoccerMenu.PlayerType.AI)
            {
                blue1.gameObject.SetActive(true);
                blue1Left.gameObject.SetActive(true);
                blue1Right.gameObject.SetActive(true);
            }
            else
            {
                blue1.gameObject.SetActive(false);
                blue1Left.gameObject.SetActive(false);
                blue1Right.gameObject.SetActive(false);
            }

            // Red 1
            if (menu.Red1Type != SoccerMenu.PlayerType.AI)
            {
                red1.gameObject.SetActive(true);
                red1Left.gameObject.SetActive(true);
                red1Right.gameObject.SetActive(true);
            }
            else
            {
                red1.gameObject.SetActive(false);
                red1Left.gameObject.SetActive(false);
                red1Right.gameObject.SetActive(false);
            }

            // Blue 2
            if (menu.Blue2Type != SoccerMenu.PlayerType.AI)
            {
                blue2.gameObject.SetActive(true);
                blue2Left.gameObject.SetActive(true);
                blue2Right.gameObject.SetActive(true);
            }
            else
            {
                blue2.gameObject.SetActive(false);
                blue2Left.gameObject.SetActive(false);
                blue2Right.gameObject.SetActive(false);
            }

            // Red 2
            if (menu.Red2Type != SoccerMenu.PlayerType.AI)
            {
                red2.gameObject.SetActive(true);
                red2Left.gameObject.SetActive(true);
                red2Right.gameObject.SetActive(true);
            }
            else
            {
                red2.gameObject.SetActive(false);
                red2Left.gameObject.SetActive(false);
                red2Right.gameObject.SetActive(false);
            }

            // Blue 3
            if (menu.Blue3Type != SoccerMenu.PlayerType.AI)
            {
                blue3.gameObject.SetActive(true);
                blue3Left.gameObject.SetActive(true);
                blue3Right.gameObject.SetActive(true);
            }
            else
            {
                blue3.gameObject.SetActive(false);
                blue3Left.gameObject.SetActive(false);
                blue3Right.gameObject.SetActive(false);
            }

            // Red 3
            if (menu.Red3Type != SoccerMenu.PlayerType.AI)
            {
                red3.gameObject.SetActive(true);
                red3Left.gameObject.SetActive(true);
                red3Right.gameObject.SetActive(true);
            }
            else
            {
                red3.gameObject.SetActive(false);
                red3Left.gameObject.SetActive(false);
                red3Right.gameObject.SetActive(false);
            }
        }
    }

    void UpdatePlayerUI()
    {
        // Update the UI text for Blue 1 and Red 1 based on the selected control type
        blue1Text.text = Blue1ControlType.ToString();
        red1Text.text = Red1ControlType.ToString();

        blue2Text.text = Blue2ControlType.ToString();
        red2Text.text = Red2ControlType.ToString();

        blue3Text.text = Blue3ControlType.ToString();
        red3Text.text = Red3ControlType.ToString();

        PlayerPrefs.SetString("Blue1ControlScheme", Blue1ControlType.ToString());
        PlayerPrefs.SetString("Red1ControlScheme", Red1ControlType.ToString());

        PlayerPrefs.SetString("Blue2ControlScheme", Blue2ControlType.ToString());
        PlayerPrefs.SetString("Red2ControlScheme", Red2ControlType.ToString());

        PlayerPrefs.SetString("Blue3ControlScheme", Blue3ControlType.ToString());
        PlayerPrefs.SetString("Red3ControlScheme", Red3ControlType.ToString());

        PlayerPrefs.Save();
    }

    public void Blue1CycleLeft()
    {
        // Cycle to the left in the control types for Blue 1
        Blue1ControlType = Blue1ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Blue1CycleRight()
    {
        // Cycle to the right in the control types for Blue 1
        Blue1ControlType = Blue1ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Red1CycleLeft()
    {
        // Cycle to the left in the control types for Red 1
        Red1ControlType = Red1ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Red1CycleRight()
    {
        // Cycle to the right in the control types for Red 1
        Red1ControlType = Red1ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Blue2CycleLeft()
    {
        // Cycle to the left in the control types for Blue 1
        Blue2ControlType = Blue2ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Blue2CycleRight()
    {
        // Cycle to the right in the control types for Blue 1
        Blue2ControlType = Blue2ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Red2CycleLeft()
    {
        // Cycle to the left in the control types for Red 1
        Red2ControlType = Red2ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Red2CycleRight()
    {
        // Cycle to the right in the control types for Red 1
        Red2ControlType = Red2ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Blue3CycleLeft()
    {
        // Cycle to the left in the control types for Blue 1
        Blue3ControlType = Blue3ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Blue3CycleRight()
    {
        // Cycle to the right in the control types for Blue 1
        Blue3ControlType = Blue3ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Red3CycleLeft()
    {
        // Cycle to the left in the control types for Red 1
        Red3ControlType = Red3ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }

    public void Red3CycleRight()
    {
        // Cycle to the right in the control types for Red 1
        Red3ControlType = Red3ControlType == ControlType.Keyboard ? ControlType.GamePad : ControlType.Keyboard;

        UpdatePlayerUI();
    }
}
