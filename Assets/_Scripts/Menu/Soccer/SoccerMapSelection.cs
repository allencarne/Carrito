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

    [Header("Weather")]
    [SerializeField] TextMeshProUGUI weatherText;
    [SerializeField] Button weatherLeft;
    [SerializeField] Button weatherRight;

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

    enum WeatherType
    {
        Random,
        None,
        Snow,
        Rain,
        Leaves,
    }

    WeatherType weatherType = WeatherType.Random;

    private void Start()
    {
        // Map
        int savedMapType = PlayerPrefs.GetInt("SelectedMapType", -1);
        // Check if the savedMapType is a valid enum value
        if (Enum.IsDefined(typeof(MapType), savedMapType))
        {
            mapType = (MapType)savedMapType;
        }
        UpdateMapText();

        // Weather
        int savedWeatherType = PlayerPrefs.GetInt("SelectedWeatherType", -1);
        // Check if the savedWeatherType is a valid enum value
        if (Enum.IsDefined(typeof(WeatherType), savedWeatherType))
        {
            weatherType = (WeatherType)savedWeatherType;
        }
        UpdateWeatherText();
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

    public void WeatherLeft()
    {
        // Cycle to the previous WeatherType
        weatherType = (WeatherType)(((int)weatherType - 1 + Enum.GetNames(typeof(WeatherType)).Length) % Enum.GetNames(typeof(WeatherType)).Length);
        UpdateWeatherText();
    }

    public void WeatherRight()
    {
        // Cycle to the next WeatherType
        weatherType = (WeatherType)(((int)weatherType + 1) % Enum.GetNames(typeof(WeatherType)).Length);
        UpdateWeatherText();
    }

    void UpdateWeatherText()
    {
        // Update the UI text based on the current WeatherType
        weatherText.text = weatherType.ToString();

        // Save the selected WeatherType to PlayerPrefs
        PlayerPrefs.SetInt("SelectedWeatherType", (int)weatherType);
        PlayerPrefs.Save();
    }
}
