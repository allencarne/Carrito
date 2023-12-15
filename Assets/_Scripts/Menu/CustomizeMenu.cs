using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;
using UnityEngine.UI;

public class CustomizeMenu : MonoBehaviour
{
    [SerializeField] GameObject preview;
    [SerializeField] float previewSpeed;

    bool isBlueActive;

    [SerializeField] CarOptions blueOptions;
    [SerializeField] CarOptions redOptions;

    [SerializeField] Image body;
    [SerializeField] Image tire;
    [SerializeField] Image wing;
    [SerializeField] TrailRenderer trail;

    [SerializeField] TextMeshProUGUI bodyText;
    private int blueBodyIndex = 0;
    private int redBodyIndex = 0;

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

    private void Start()
    {
        BlueButton();
    }

    private void Update()
    {
        if (isBlueActive)
        {
            SelectCarOptions(blueOptions, blueBodyIndex, blueTireIndex, blueWingIndex, bluePaintIndex, blueTrailIndex);
            UpdateText(blueBodyIndex, blueTireIndex, blueWingIndex, bluePaintIndex, blueTrailIndex);
        }
        else
        {
            SelectCarOptions(redOptions, redBodyIndex, redTireIndex, redWingIndex, redPaintIndex, redTrailIndex);
            UpdateText(redBodyIndex, redTireIndex, redWingIndex, redPaintIndex, redTrailIndex);
        }
    }

    public void BlueButton()
    {
        isBlueActive = true;
    }

    public void RedButton()
    {
        isBlueActive = false;
    }

    public void BodyLeft()
    {
        if (isBlueActive)
        {
            blueBodyIndex = (blueBodyIndex - 1 + blueOptions.bodys.Length) % blueOptions.bodys.Length;
        }
        else
        {
            redBodyIndex = (redBodyIndex - 1 + redOptions.bodys.Length) % redOptions.bodys.Length;
        }
    }

    public void BodyRight()
    {
        if (isBlueActive)
        {
            blueBodyIndex = (blueBodyIndex + 1) % blueOptions.bodys.Length;
        }
        else
        {
            redBodyIndex = (redBodyIndex + 1) % redOptions.bodys.Length;
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

    public void SelectCarOptions(CarOptions options, int bodyIndex, int tireIndex, int wingIndex, int paintIndex, int trailIndex)
    {
        // Body
        if (options.bodys.Length > 0)
            body.sprite = options.bodys[bodyIndex];

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
    }

    private void UpdateText(int cBodyInxed, int cTireIndex, int cWingIndex, int cPaintIndex, int cTrailIndex)
    {
        bodyText.text = cBodyInxed.ToString();
        tireText.text = cTireIndex.ToString();
        wingText.text = cWingIndex.ToString();
        paintText.text = cPaintIndex.ToString();
        trailText.text = cTrailIndex.ToString();
    }
}