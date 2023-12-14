using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;
using UnityEngine.UI;

public class CustomizeMenu : MonoBehaviour
{
    bool isBlueActive;

    [SerializeField] CarOptions blueOptions;
    [SerializeField] CarOptions redOptions;

    [SerializeField] SpriteRenderer body;
    [SerializeField] SpriteRenderer tire;
    [SerializeField] SpriteRenderer wing;

    [SerializeField] TextMeshProUGUI bodyText;
    private int blueBodyIndex = 0;
    private int redBodyIndex = 0;

    [SerializeField] TextMeshProUGUI tireText;
    private int blueTireIndex = 0;
    private int redTireIndex = 0;

    private void Start()
    {
        BlueButton();
    }

    private void Update()
    {
        if (isBlueActive)
        {
            SelectCarOptions(blueOptions, blueBodyIndex, blueTireIndex);
        }
        else
        {
            SelectCarOptions(redOptions, redBodyIndex, redTireIndex);
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
            SelectCarOptions(blueOptions, blueBodyIndex, blueTireIndex);
            UpdateText(blueBodyIndex, blueTireIndex);
        }
        else
        {
            redBodyIndex = (redBodyIndex - 1 + redOptions.bodys.Length) % redOptions.bodys.Length;
            SelectCarOptions(redOptions, redBodyIndex, redTireIndex);
            UpdateText(redBodyIndex, redTireIndex);
        }
    }

    public void BodyRight()
    {
        if (isBlueActive)
        {
            blueBodyIndex = (blueBodyIndex + 1) % blueOptions.bodys.Length;
            SelectCarOptions(blueOptions, blueBodyIndex, blueTireIndex);
            UpdateText(blueBodyIndex, blueTireIndex);
        }
        else
        {
            redBodyIndex = (redBodyIndex + 1) % redOptions.bodys.Length;
            SelectCarOptions(redOptions, redBodyIndex, redTireIndex);
            UpdateText(redBodyIndex, redTireIndex);
        }
    }

    public void TireLeft()
    {
        if (isBlueActive)
        {
            blueTireIndex = (blueTireIndex - 1 + blueOptions.tires.Length) % blueOptions.tires.Length;
            SelectCarOptions(blueOptions, blueBodyIndex, blueTireIndex);
            UpdateText(blueBodyIndex, blueTireIndex);
        }
        else
        {
            redTireIndex = (redTireIndex - 1 + redOptions.tires.Length) % redOptions.tires.Length;
            SelectCarOptions(redOptions, redBodyIndex, redTireIndex);
            UpdateText(redBodyIndex, redTireIndex);
        }
    }

    public void TireRight()
    {
        if (isBlueActive)
        {
            blueTireIndex = (blueTireIndex + 1) % blueOptions.tires.Length;
            SelectCarOptions(blueOptions, blueBodyIndex, blueTireIndex);
            UpdateText(blueBodyIndex, blueTireIndex);
        }
        else
        {
            redTireIndex = (redTireIndex + 1) % redOptions.tires.Length;
            SelectCarOptions(redOptions, redBodyIndex, redTireIndex);
            UpdateText(redBodyIndex, redTireIndex);
        }
    }

    public void SelectCarOptions(CarOptions options, int bodyIndex, int tireIndex)
    {
        // Display the current body sprite based on the index
        if (options.bodys.Length > 0)
            body.sprite = options.bodys[bodyIndex];

       // Display the current body sprite based on the index
       if (options.tires.Length > 0)
           tire.sprite = options.tires[tireIndex];
       /*
       // Set random wing sprite
       if (options.wings.Length > 0)
           wing.sprite = options.wings[Random.Range(0, options.wings.Length)];

       // Set random paint color
       if (options.paint.Length > 0)
           body.color = options.paint[Random.Range(0, options.paint.Length)];
        */
    }

    private void UpdateText(int cBodyInxed, int cTireIndex)
    {
        bodyText.text = cBodyInxed.ToString();
        tireText.text = cTireIndex.ToString();
    }
}
