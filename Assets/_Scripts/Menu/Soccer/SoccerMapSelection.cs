using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoccerMapSelection : MonoBehaviour
{
    [Header("Map")]
    [SerializeField] TextMeshProUGUI mapText;
    [SerializeField] Button mapLeft;
    [SerializeField] Button mapRight;

    enum MapType
    {
        Random,
        Green,
        Blue,
        Red,
        Black,
        Purple,
        Pink,
        Yellow,
        Brown,
    }

    MapType mapType = MapType.Random;

    private void Start()
    {
        int savedMapType = PlayerPrefs.GetInt("SelectedMapType", -1);

        // Check if the savedMapType is a valid enum value
        if (Enum.IsDefined(typeof(MapType), savedMapType))
        {
            mapType = (MapType)savedMapType;
        }

        UpdateMapText();
    }

    public void MapLeft()
    {
        // Cycle to the previous MapType
        mapType = (MapType)(((int)mapType - 1 + Enum.GetNames(typeof(MapType)).Length) % Enum.GetNames(typeof(MapType)).Length);
        UpdateMapText();
    }

    public void MapRight()
    {
        // Cycle to the next MapType
        mapType = (MapType)(((int)mapType + 1) % Enum.GetNames(typeof(MapType)).Length);
        UpdateMapText();
    }

    private void UpdateMapText()
    {
        // Update the UI text based on the current MapType
        mapText.text = mapType.ToString();

        // Save the selected MapType to PlayerPrefs
        PlayerPrefs.SetInt("SelectedMapType", (int)mapType);
        PlayerPrefs.Save();
    }
}
