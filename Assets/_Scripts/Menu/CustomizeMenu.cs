using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;
using UnityEngine.UI;

public class CustomizeMenu : MonoBehaviour
{
    bool isBlueActive = true;

    [SerializeField] CarOptions blueOptions;
    [SerializeField] CarOptions redOptions;

    [SerializeField] Image body;
    [SerializeField] Image _light;
    [SerializeField] Image tire;
    [SerializeField] Image wing;
    [SerializeField] TrailRenderer trail;

    [SerializeField] TextMeshProUGUI bodyText;
    private int blueBodyIndex = 0;
    private int redBodyIndex = 0;

    private int blueLightIndex = 0;
    private int redLightIndex = 0;

    [SerializeField] TextMeshProUGUI tireText;
    private int blueTireIndex = 0;
    private int redTireIndex = 0;

    [SerializeField] TextMeshProUGUI wingText;
    private int blueWingIndex = 0;
    private int redWingIndex = 0;

    [SerializeField] TextMeshProUGUI paintText;
    private int bluePaintIndex = 0;
    private int redPaintIndex = 0;

    [SerializeField] TextMeshProUGUI trailText;
    private int blueTrailIndex = 0;
    private int redTrailIndex = 0;

    [SerializeField] TextMeshProUGUI explosionText;
    private int blueExplosionIndex = 0;
    private int redExplosionIndex = 0;
    [SerializeField] GameObject currentExplosion;

    private const string PLAYERPREFS_PREFIX = "PlayerCustomization_";

    private void Start()
    {
        LoadPlayerPrefs();
    }

    private void Update()
    {
        if (isBlueActive)
        {
            SelectCarOptions(blueOptions, blueBodyIndex, blueLightIndex, blueTireIndex, blueWingIndex, bluePaintIndex, blueTrailIndex, blueExplosionIndex);
            UpdateText(blueBodyIndex, blueTireIndex, blueWingIndex, bluePaintIndex, blueTrailIndex, blueExplosionIndex);

        }
        else
        {
            SelectCarOptions(redOptions, redBodyIndex, redLightIndex, redTireIndex, redWingIndex, redPaintIndex, redTrailIndex, redExplosionIndex);
            UpdateText(redBodyIndex, redTireIndex, redWingIndex, redPaintIndex, redTrailIndex, redExplosionIndex);
        }
    }

    public void SavePlayerPrefs()
    {
        SaveTeamPrefs("Blue_", blueBodyIndex, blueLightIndex, blueTireIndex, blueWingIndex, bluePaintIndex, blueTrailIndex);
        SaveTeamPrefs("Red_", redBodyIndex, redLightIndex, redTireIndex, redWingIndex, redPaintIndex, redTrailIndex);

        PlayerPrefs.Save();
    }

    private void SaveTeamPrefs(string keyPrefix, int bodyIndex, int lightIndex, int tireIndex, int wingIndex, int paintIndex, int trailIndex)
    {
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "BodyIndex", bodyIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "LightIndex", lightIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "TireIndex", tireIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "WingIndex", wingIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "PaintIndex", paintIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "TrailIndex", trailIndex);
    }

    private void LoadPlayerPrefs()
    {
        LoadTeamPrefs("Blue_", ref blueBodyIndex, ref blueLightIndex, ref blueTireIndex, ref blueWingIndex, ref bluePaintIndex, ref blueTrailIndex);
        LoadTeamPrefs("Red_", ref redBodyIndex, ref redLightIndex, ref redTireIndex, ref redWingIndex, ref redPaintIndex, ref redTrailIndex);
    }

    private void LoadTeamPrefs(string keyPrefix, ref int bodyIndex, ref int lightIndex, ref int tireIndex, ref int wingIndex, ref int paintIndex, ref int trailIndex)
    {
        bodyIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "BodyIndex", 0);
        lightIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "LightIndex", 0);
        tireIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "TireIndex", 0);
        wingIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "WingIndex", 0);
        paintIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "PaintIndex", 0);
        trailIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "TrailIndex", 0);
    }

    public void BlueButton()
    {
        isBlueActive = true;
        LoadPlayerPrefs();
    }

    public void RedButton()
    {
        isBlueActive = false;
        LoadPlayerPrefs();

    }

    public void BodyLeft()
    {
        if (isBlueActive)
        {
            blueBodyIndex = (blueBodyIndex - 1 + blueOptions.bodys.Length) % blueOptions.bodys.Length;
            blueLightIndex = Mathf.Clamp(blueBodyIndex, 0, blueOptions.lights.Length - 1);
        }
        else
        {
            redBodyIndex = (redBodyIndex - 1 + redOptions.bodys.Length) % redOptions.bodys.Length;
            redLightIndex = Mathf.Clamp(redBodyIndex, 0, redOptions.lights.Length - 1);
        }
    }

    public void BodyRight()
    {
        if (isBlueActive)
        {
            blueBodyIndex = (blueBodyIndex + 1) % blueOptions.bodys.Length;
            blueLightIndex = Mathf.Clamp(blueBodyIndex, 0, blueOptions.lights.Length - 1);
        }
        else
        {
            redBodyIndex = (redBodyIndex + 1) % redOptions.bodys.Length;
            redLightIndex = Mathf.Clamp(redBodyIndex, 0, redOptions.lights.Length - 1);
        }
    }

    public void TireLeft()
    {
        if (isBlueActive)
        {
            blueTireIndex = (blueTireIndex - 1 + blueOptions.tires.Length) % blueOptions.tires.Length;
        }
        else
        {
            redTireIndex = (redTireIndex - 1 + redOptions.tires.Length) % redOptions.tires.Length;
        }
    }

    public void TireRight()
    {
        if (isBlueActive)
        {
            blueTireIndex = (blueTireIndex + 1) % blueOptions.tires.Length;
        }
        else
        {
            redTireIndex = (redTireIndex + 1) % redOptions.tires.Length;
        }
    }

    public void WingLeft()
    {
        if (isBlueActive)
        {
            blueWingIndex = (blueWingIndex - 1 + blueOptions.wings.Length) % blueOptions.wings.Length;
        }
        else
        {
            redWingIndex = (redWingIndex - 1 + redOptions.wings.Length) % redOptions.wings.Length;
        }
    }

    public void WingRight()
    {
        if (isBlueActive)
        {
            blueWingIndex = (blueWingIndex + 1) % blueOptions.wings.Length;
        }
        else
        {
            redWingIndex = (redWingIndex + 1) % redOptions.wings.Length;
        }
    }

    public void PaintLeft()
    {
        if (isBlueActive)
        {
            bluePaintIndex = (bluePaintIndex - 1 + blueOptions.paint.Length) % blueOptions.paint.Length;
        }
        else
        {
            redPaintIndex = (redPaintIndex - 1 + redOptions.paint.Length) % redOptions.paint.Length;
        }
    }

    public void PaintRight()
    {
        if (isBlueActive)
        {
            bluePaintIndex = (bluePaintIndex + 1) % blueOptions.paint.Length;
        }
        else
        {
            redPaintIndex = (redPaintIndex + 1) % redOptions.paint.Length;
        }
    }

    public void TrailLeft()
    {
        if (isBlueActive)
        {
            blueTrailIndex = (blueTrailIndex - 1 + blueOptions.trails.Length) % blueOptions.trails.Length;
        }
        else
        {
            redTrailIndex = (redTrailIndex - 1 + redOptions.trails.Length) % redOptions.trails.Length;
        }
    }

    public void TrailRight()
    {
        if (isBlueActive)
        {
            blueTrailIndex = (blueTrailIndex + 1) % blueOptions.trails.Length;
        }
        else
        {
            redTrailIndex = (redTrailIndex + 1) % redOptions.trails.Length;
        }
    }

    public void ExplosionLeft()
    {
        if (isBlueActive)
        {
            blueExplosionIndex = (blueExplosionIndex - 1 + blueOptions.explosions.Length) % blueOptions.explosions.Length;
        }
        else
        {
            redExplosionIndex = (redExplosionIndex - 1 + redOptions.explosions.Length) % redOptions.explosions.Length;
        }
    }

    public void ExplosionRight()
    {
        if (isBlueActive)
        {
            blueExplosionIndex = (blueExplosionIndex + 1) % blueOptions.explosions.Length;
        }
        else
        {
            redExplosionIndex = (redExplosionIndex + 1) % redOptions.explosions.Length;
        }
    }

    public void SelectCarOptions(CarOptions options, int bodyIndex, int lightIndex, int tireIndex, int wingIndex, int paintIndex, int trailIndex, int explosionIndex)
    {
        // Body
        if (options.bodys.Length > 0)
            body.sprite = options.bodys[bodyIndex];

        // Light
        if (options.lights.Length > 0)
            _light.sprite = options.lights[Mathf.Clamp(lightIndex, 0, options.lights.Length - 1)];

        // Tires
        if (options.tires.Length > 0)
           tire.sprite = options.tires[tireIndex];

        // Wing
        if (options.wings.Length > 0)
            wing.sprite = options.wings[wingIndex];

        // Paint
        if (options.paint.Length > 0)
            body.color = options.paint[paintIndex];

        // Trail
        if (options.trails.Length > 0)
            trail.colorGradient = options.trails[trailIndex];

        // Explosion
        if (options.explosions.Length > 0)
        {
            if (currentExplosion == null)
            {
                switch (explosionIndex)
                {
                    case 0:
                        currentExplosion = Instantiate(options.explosions[0], transform.position, transform.rotation, transform);
                        break;
                    case 1:
                        currentExplosion = Instantiate(options.explosions[1], transform.position, transform.rotation, transform);
                        break;
                    case 2:
                        currentExplosion = Instantiate(options.explosions[2], transform.position, transform.rotation, transform);
                        break;
                    case 3:
                        currentExplosion = Instantiate(options.explosions[3], transform.position, transform.rotation, transform);
                        break;
                    case 4:
                        currentExplosion = Instantiate(options.explosions[4], transform.position, transform.rotation, transform);
                        break;
                    case 5:
                        currentExplosion = Instantiate(options.explosions[5], transform.position, transform.rotation, transform);
                        break;
                }

                Destroy(currentExplosion, 1);
            }
        }
    }

    private void UpdateText(int cBodyIndex, int cTireIndex, int cWingIndex, int cPaintIndex, int cTrailIndex, int cExplosionIndex)
    {
        bodyText.text = cBodyIndex.ToString();
        tireText.text = cTireIndex.ToString();
        wingText.text = cWingIndex.ToString();
        paintText.text = cPaintIndex.ToString();
        trailText.text = cTrailIndex.ToString();
        explosionText.text = cExplosionIndex.ToString();
    }
}
