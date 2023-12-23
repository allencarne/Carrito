using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerField : MonoBehaviour
{
    [SerializeField] SpriteRenderer ground;
    [SerializeField] SpriteRenderer lines;
    [Header("Green")]
    [SerializeField] Color groundColorGreen;
    [SerializeField] Color lineColorGreen;
    [Header("Red")]
    [SerializeField] Color groundColorRed;
    [SerializeField] Color linesColorRed;
    [Header("Blue")]
    [SerializeField] Color groundColorBlue;
    [SerializeField] Color linesColorBlue;
    [Header("Black")]
    [SerializeField] Color groundColorBlack;
    [SerializeField] Color linesColorBlack;
    [Header("Purple")]
    [SerializeField] Color groundColorPurple;
    [SerializeField] Color linesColorPurple;
    [Header("Pink")]
    [SerializeField] Color groundColorPink;
    [SerializeField] Color linesColorPink;
    [Header("Yellow")]
    [SerializeField] Color groundColorYellow;
    [SerializeField] Color linesColorYellow;
    [Header("Brown")]
    [SerializeField] Color groundColorBrown;
    [SerializeField] Color linesColorBrown;

    [Header("Weather")]
    [SerializeField] GameObject snowWeather;
    [SerializeField] GameObject rainWeather;
    [SerializeField] GameObject leavesWeather;

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

    void Start()
    {
        switch (PlayerPrefs.GetInt("SelectedWeatherType"))
        {
            case 0:
                // Random
                int random = Random.Range(0, 3);

                switch (random)
                {
                    case 0:
                        // Snow
                        snowWeather.SetActive(true);
                        rainWeather.SetActive(false);
                        leavesWeather.SetActive(false);
                        break;
                    case 1:
                        // Rain
                        snowWeather.SetActive(false);
                        rainWeather.SetActive(true);
                        leavesWeather.SetActive(false);
                        break;
                    case 2:
                        // Leaves
                        snowWeather.SetActive(false);
                        rainWeather.SetActive(false);
                        leavesWeather.SetActive(true);
                        break;
                }

                break;
            case 1:
                // None
                snowWeather.SetActive(false);
                rainWeather.SetActive(false);
                leavesWeather.SetActive(false);
                break;
            case 2:
                // Snow
                snowWeather.SetActive(true);
                rainWeather.SetActive(false);
                leavesWeather.SetActive(false);
                break;
            case 3:
                // Rain
                snowWeather.SetActive(false);
                rainWeather.SetActive(true);
                leavesWeather.SetActive(false);
                break;
            case 4:
                // Leaves
                snowWeather.SetActive(false);
                rainWeather.SetActive(false);
                leavesWeather.SetActive(true);
                break;
        }


        // Check if the PlayerPrefs key exists
        if (PlayerPrefs.HasKey("SelectedMapType"))
        {
            // Retrieve the mapType from PlayerPrefs
            int mapTypeValue = PlayerPrefs.GetInt("SelectedMapType");

            // Check if the retrieved value is a valid MapType enum value
            if (System.Enum.IsDefined(typeof(MapType), mapTypeValue))
            {
                MapType mapType;

                // If "Random" is selected, choose a random map type
                if ((MapType)mapTypeValue == MapType.Random)
                {
                    mapType = (MapType)Random.Range(1, 5); // Exclude MapType.Random
                }
                else
                {
                    mapType = (MapType)mapTypeValue;
                }

                // Update colors based on the selected MapType
                switch (mapType)
                {
                    case MapType.Green:
                        ground.color = groundColorGreen;
                        lines.color = lineColorGreen;
                        break;

                    case MapType.Red:
                        ground.color = groundColorRed;
                        lines.color = linesColorRed;
                        break;

                    case MapType.Blue:
                        ground.color = groundColorBlue;
                        lines.color = linesColorBlue;
                        break;

                    case MapType.Black:
                        ground.color = groundColorBlack;
                        lines.color = linesColorBlack;
                        break;

                    case MapType.Purple:
                        ground.color = groundColorPurple;
                        lines.color = linesColorPurple;
                        break;

                    case MapType.Pink:
                        ground.color = groundColorPink;
                        lines.color = linesColorPink;
                        break;

                    case MapType.Yellow:
                        ground.color = groundColorYellow;
                        lines.color = linesColorYellow;
                        break;

                    case MapType.Brown:
                        ground.color = groundColorBrown;
                        lines.color = linesColorBrown;
                        break;
                }
            }
            else
            {
                Debug.LogError("Invalid mapType value retrieved from PlayerPrefs.");
            }
        }
    }
}
