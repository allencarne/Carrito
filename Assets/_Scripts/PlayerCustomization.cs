using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    [SerializeField] CarOptions blueOptions;
    [SerializeField] CarOptions redOptions;

    [SerializeField] SpriteRenderer body;
    [SerializeField] SpriteRenderer _light;
    [SerializeField] SpriteRenderer tire;
    [SerializeField] SpriteRenderer wing;

    private int bodyIndex = 0;
    private int lightIndex = 0;
    private int tireIndex = 0;
    private int wingIndex = 0;
    private int paintIndex = 0;
    private int trailIndex = 0;
    private int trailColorIndex = 0;

    private const string PLAYERPREFS_PREFIX = "PlayerCustomization_";

    public bool isBlueTeam;

    public bool isAI = false;

    private void Start()
    {
        if (isBlueTeam)
        {
            LoadPlayerPrefs();
            SelectRandomOptions(blueOptions);
        }
        else
        {
            LoadPlayerPrefs();
            SelectRandomOptions(redOptions);
        }
    }

    private void LoadPlayerPrefs()
    {
        if (!isAI)
        {
            string keyPrefix = isBlueTeam ? "Blue_" : "Red_";

            // Load customization options from PlayerPrefs
            bodyIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "BodyIndex", 0);
            lightIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "LightIndex", 0);
            tireIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "TireIndex", 0);
            wingIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "WingIndex", 0);
            paintIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "PaintIndex", 0);
            trailIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "TrailIndex", 0);
            trailColorIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "TrailColorIndex", 0);
        }
    }

    private void SelectRandomOptions(CarOptions options)
    {
        if (!isAI)
        {
            // Set Body Based on Player Prefs
            if (options.bodys.Length > 0)
            {
                body.sprite = options.bodys[bodyIndex];

                // Set Light based on the selected body index
                if (options.lights.Length > 0)
                {
                    lightIndex = Mathf.Clamp(bodyIndex, 0, options.lights.Length - 1);
                    _light.sprite = options.lights[lightIndex];  // Update _light sprite based on lightIndex
                }
            }

            // Set Tire Based on Player Prefs
            if (options.tires.Length > 0)
                tire.sprite = options.tires[tireIndex];

            // Set Wing Based on Player Prefs
            if (options.wings.Length > 0)
                wing.sprite = options.wings[wingIndex];

            // Set Paint Based on Player Prefs
            if (options.paint.Length > 0)
                body.color = options.paint[paintIndex];

            // Set Trail Based on Player Prefs
            if (options.trails.Length > 0)
            {
                //trail = options.trails[trailIndex];
            }

            // Set Trail Color Based on Player Prefs
            if (options.trailColor.Length > 0)
            {
                //colorOverLifetimeModule.color = options.trailColor[trailColorIndex];
            }
        }
        else
        {
            // Body
            if (options.bodys.Length > 0)
            {
                int randomBodyIndex = Random.Range(0, options.bodys.Length);
                body.sprite = options.bodys[randomBodyIndex];

                // Light
                if (options.lights.Length > 0)
                {
                    lightIndex = Mathf.Clamp(randomBodyIndex, 0, options.lights.Length - 1);
                    _light.sprite = options.lights[lightIndex];  // Update _light sprite based on lightIndex
                }
            }

            // Tire
            if (options.tires.Length > 0)
                tire.sprite = options.tires[Random.Range(0, options.tires.Length)];

            // Wing
            if (options.wings.Length > 0)
                wing.sprite = options.wings[Random.Range(0, options.wings.Length)];

            // Paint
            if (options.paint.Length > 0)
                body.color = options.paint[Random.Range(0, options.paint.Length)];
        }
    }
}
