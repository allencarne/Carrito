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

    [Header("Red 1")]
    [SerializeField] Button red1;
    [SerializeField] TextMeshProUGUI red1Text;
    [SerializeField] Button red1Left;
    [SerializeField] Button red1Right;

    public enum ControlType
    {
        Keyboard,
        GamePad,
    }

    ControlType Blue1ControlType = ControlType.Keyboard;
    ControlType Red1ControlType = ControlType.GamePad;

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
    }

    void UpdatePlayerUI()
    {
        // Update the UI text for Blue 1 and Red 1 based on the selected control type
        blue1Text.text = Blue1ControlType.ToString();
        red1Text.text = Red1ControlType.ToString();

        PlayerPrefs.SetString("Blue1ControlScheme", Blue1ControlType.ToString());
        PlayerPrefs.SetString("Red1ControlScheme", Red1ControlType.ToString());

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
}
