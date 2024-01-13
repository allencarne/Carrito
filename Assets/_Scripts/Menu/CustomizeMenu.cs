using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CustomizeMenu : MonoBehaviour
{
    bool isBlueActive = true;

    [SerializeField] Transform trailTransform;

    [SerializeField] Transform carPreview;

    [SerializeField] CarOptions blueOptions;
    [SerializeField] CarOptions redOptions;

    [SerializeField] Image body;
    [SerializeField] Image _light;
    [SerializeField] Image tire;
    [SerializeField] Image wing;
    [SerializeField] ParticleSystem trail;
    [SerializeField] GameObject explosion;
    ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule;

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

    [SerializeField] TextMeshProUGUI trailColorText;
    private int blueTrailColorIndex = 0;
    private int redTrailColorIndex = 0;

    [SerializeField] TextMeshProUGUI explosionText;
    private int blueExplosionIndex = 0;
    private int redExplosionIndex = 0;

    [SerializeField] TextMeshProUGUI explosionColorText;
    private int blueExplosionColorIndex = 0;
    private int redExplosionColorIndex = 0;

    private const string PLAYERPREFS_PREFIX = "PlayerCustomization_";

    private void Start()
    {
        LoadPlayerPrefs();
    }

    private void Update()
    {
        if (isBlueActive)
        {
            SelectCarOptions(blueOptions, blueBodyIndex, blueLightIndex, blueTireIndex, blueWingIndex, bluePaintIndex, blueTrailIndex, blueTrailColorIndex, blueExplosionIndex, blueExplosionColorIndex);
            UpdateText(blueBodyIndex, blueTireIndex, blueWingIndex, bluePaintIndex, blueTrailIndex, blueTrailColorIndex, blueExplosionIndex, blueExplosionColorIndex);

        }
        else
        {
            SelectCarOptions(redOptions, redBodyIndex, redLightIndex, redTireIndex, redWingIndex, redPaintIndex, redTrailIndex, redTrailColorIndex, redExplosionIndex, redExplosionColorIndex);
            UpdateText(redBodyIndex, redTireIndex, redWingIndex, redPaintIndex, redTrailIndex, redTrailColorIndex, redExplosionIndex, redExplosionColorIndex);
        }
    }

    public void SavePlayerPrefs()
    {
        SaveTeamPrefs("Blue_", blueBodyIndex, blueLightIndex, blueTireIndex, blueWingIndex, bluePaintIndex, blueTrailIndex, blueTrailColorIndex, blueExplosionIndex, blueExplosionColorIndex);
        SaveTeamPrefs("Red_", redBodyIndex, redLightIndex, redTireIndex, redWingIndex, redPaintIndex, redTrailIndex, redTrailColorIndex, redExplosionIndex, redExplosionColorIndex);

        PlayerPrefs.Save();
    }

    private void SaveTeamPrefs(string keyPrefix, int bodyIndex, int lightIndex, int tireIndex, int wingIndex, int paintIndex, int trailIndex, int trailColorIndex, int explosionIndex, int explosionColorIndex)
    {
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "BodyIndex", bodyIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "LightIndex", lightIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "TireIndex", tireIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "WingIndex", wingIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "PaintIndex", paintIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "TrailIndex", trailIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "TrailColorIndex", trailColorIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "ExplosionIndex", explosionIndex);
        PlayerPrefs.SetInt(PLAYERPREFS_PREFIX + keyPrefix + "ExplosionColorIndex", explosionColorIndex);
    }

    private void LoadPlayerPrefs()
    {
        LoadTeamPrefs("Blue_", ref blueBodyIndex, ref blueLightIndex, ref blueTireIndex, ref blueWingIndex, ref bluePaintIndex, ref blueTrailIndex, ref blueTrailColorIndex, ref blueExplosionIndex, ref blueExplosionColorIndex);
        LoadTeamPrefs("Red_", ref redBodyIndex, ref redLightIndex, ref redTireIndex, ref redWingIndex, ref redPaintIndex, ref redTrailIndex, ref redTrailColorIndex, ref redExplosionIndex, ref redExplosionColorIndex);
    }

    private void LoadTeamPrefs(string keyPrefix, ref int bodyIndex, ref int lightIndex, ref int tireIndex, ref int wingIndex, ref int paintIndex, ref int trailIndex, ref int trailColorIndex, ref int explosionIndex, ref int explosionColorIndex)
    {
        bodyIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "BodyIndex", 0);
        lightIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "LightIndex", 0);
        tireIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "TireIndex", 0);
        wingIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "WingIndex", 0);
        paintIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "PaintIndex", 0);
        trailIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "TrailIndex", 0);
        trailColorIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "TrailColorIndex", 0);
        explosionIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "ExplosionIndex", 0);
        explosionColorIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + keyPrefix + "ExplosionColorIndex", 0);
    }

    public void BlueButton()
    {
        isBlueActive = true;

        Destroy(trail.gameObject);

        Destroy(explosion.gameObject);

        LoadPlayerPrefs();
    }

    public void RedButton()
    {
        isBlueActive = false;

        Destroy(trail.gameObject);

        Destroy(explosion.gameObject);

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

            Destroy(trail.gameObject);
        }
        else
        {
            redTrailIndex = (redTrailIndex - 1 + redOptions.trails.Length) % redOptions.trails.Length;

            Destroy(trail.gameObject);
        }
    }

    public void TrailRight()
    {
        if (isBlueActive)
        {
            blueTrailIndex = (blueTrailIndex + 1) % blueOptions.trails.Length;

            Destroy(trail.gameObject);
        }
        else
        {
            redTrailIndex = (redTrailIndex + 1) % redOptions.trails.Length;

            Destroy(trail.gameObject);
        }
    }

    public void TrailColorLeft()
    {
        if (isBlueActive)
        {
            blueTrailColorIndex = (blueTrailColorIndex - 1 + blueOptions.trailColor.Length) % blueOptions.trailColor.Length;

            Destroy(trail.gameObject);
        }
        else
        {
            redTrailColorIndex = (redTrailColorIndex - 1 + redOptions.trailColor.Length) % redOptions.trailColor.Length;

            Destroy(trail.gameObject);
        }
    }

    public void TrailColorRight()
    {
        if (isBlueActive)
        {
            blueTrailColorIndex = (blueTrailColorIndex + 1) % blueOptions.trailColor.Length;

            Destroy(trail.gameObject);
        }
        else
        {
            redTrailColorIndex = (redTrailColorIndex + 1) % redOptions.trailColor.Length;

            Destroy(trail.gameObject);
        }
    }

    public void ExplosionLeft()
    {
        if (isBlueActive)
        {
            blueExplosionIndex = (blueExplosionIndex - 1 + blueOptions.explosions.Length) % blueOptions.explosions.Length;

            Destroy(explosion.gameObject);
        }
        else
        {
            redExplosionIndex = (redExplosionIndex - 1 + redOptions.explosions.Length) % redOptions.explosions.Length;
            Destroy(explosion.gameObject);
        }
    }

    public void ExplosionRight()
    {
        if (isBlueActive)
        {
            blueExplosionIndex = (blueExplosionIndex + 1) % blueOptions.explosions.Length;

            Destroy(explosion.gameObject);
        }
        else
        {
            redExplosionIndex = (redExplosionIndex + 1) % redOptions.explosions.Length;

            Destroy(explosion.gameObject);
        }
    }

    public void ExplosionColorLeft()
    {
        if (isBlueActive)
        {
            blueExplosionColorIndex = (blueExplosionColorIndex - 1 + blueOptions.trailColor.Length) % blueOptions.trailColor.Length;

            Destroy(explosion.gameObject);
        }
        else
        {
            redExplosionColorIndex = (redExplosionColorIndex - 1 + redOptions.trailColor.Length) % redOptions.trailColor.Length;

            Destroy(explosion.gameObject);
        }
    }

    public void ExplosionColorRight()
    {
        if (isBlueActive)
        {
            blueExplosionColorIndex = (blueExplosionColorIndex + 1) % blueOptions.trailColor.Length;

            Destroy(explosion.gameObject);
        }
        else
        {
            redExplosionColorIndex = (redExplosionColorIndex + 1) % redOptions.trailColor.Length;

            Destroy(explosion.gameObject);
        }
    }

    public void SelectCarOptions(CarOptions options, int bodyIndex, int lightIndex, int tireIndex, int wingIndex, int paintIndex, int trailIndex, int trailColorIndex, int explosionIndex, int explosionColorIndex)
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
        if (options.trails.Length > 0 && options.trailColor.Length > 0)
        {
            if (trail == null)
            {
                // Instantiate the Particle System prefab
                ParticleSystem instantiatedTrail = Instantiate(options.trails[trailIndex], trailTransform.transform.position, trailTransform.transform.rotation, carPreview.transform);

                // Set the scale of the instantiated trail
                instantiatedTrail.transform.localScale = new Vector3(5, 5, 1);

                // Start the Particle System manually
                instantiatedTrail.Play();

                // Assign the instantiated Particle System to trail
                trail = instantiatedTrail;

                // Assign the specified color to the trail
                colorOverLifetimeModule = instantiatedTrail.colorOverLifetime;
                colorOverLifetimeModule.color = options.trailColor[trailColorIndex];

                // Ensure the trail is emitting
                var emissionModule = instantiatedTrail.emission;
                emissionModule.enabled = true;

                // Set gravity
                var mainModule = instantiatedTrail.main;
                mainModule.gravityModifier = 10;
            }
        }

        // Explosion
        if (options.explosions.Length > 0)
        {
            if (explosion == null)
            {
                // Instantiate the Particle System prefab
                GameObject newExplosion = Instantiate(options.explosions[explosionIndex], transform.position, transform.rotation);

                // Get the Particle System component
                ParticleSystem explosionParticleSystem = newExplosion.GetComponent<ParticleSystem>();

                // Get the AudioSource component from the instantiated explosion object
                AudioSource explosionAudioSource = newExplosion.GetComponentInChildren<AudioSource>();

                // Mute the AudioSource
                if (explosionAudioSource != null)
                {
                    explosionAudioSource.volume = 0;
                }

                // Check if the Particle System component is not null
                if (explosionParticleSystem != null)
                {
                    // Get the main module of the Particle System
                    var mainModule = explosionParticleSystem.main;

                    // Check if the options and gradient are not null
                    if (options.trailColor.Length > 0)
                    {
                        // Make sure explosionColorIndex is within the bounds of options.trailColor
                        int colorIndex = Mathf.Clamp(explosionColorIndex, 0, options.trailColor.Length - 1);

                        // Set the start color to the specified color in the gradient
                        mainModule.startColor = options.trailColor[colorIndex];
                    }
                }

                // Assign the instantiated GameObject to explosion
                explosion = newExplosion;

                Destroy(newExplosion, 10);
            }
        }
    }

    private void UpdateText(int cBodyIndex, int cTireIndex, int cWingIndex, int cPaintIndex, int cTrailIndex, int cTrailColorIndex, int cExplosionIndex, int cExplosionColorIndex)
    {
        bodyText.text = cBodyIndex.ToString();
        tireText.text = cTireIndex.ToString();
        wingText.text = cWingIndex.ToString();
        paintText.text = cPaintIndex.ToString();
        trailText.text = cTrailIndex.ToString();
        trailColorText.text = cTrailColorIndex.ToString();
        explosionText.text = cExplosionIndex.ToString();
        explosionColorText.text = cExplosionColorIndex.ToString();
    }
}
