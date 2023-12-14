using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;
using UnityEngine.UI;

public class CustomizeMenu : MonoBehaviour
{
    //[SerializeField] Transform playerPreview;

    bool isBlueActive;

    [SerializeField] CarOptions blueOptions;
    [SerializeField] CarOptions redOptions;

    [SerializeField] SpriteRenderer body;
    [SerializeField] SpriteRenderer tire;
    [SerializeField] SpriteRenderer wing;

    [SerializeField] Button bodyLeft;
    [SerializeField] Button bodyRight;
    [SerializeField] TextMeshProUGUI bodyText;
    private int blueBodyIndex = 0;
    private int redBodyIndex = 0;

    private void Start()
    {
        BlueButton();
    }

    private void Update()
    {
        if (isBlueActive)
        {
            SelectCarOptions(blueOptions, blueBodyIndex);
        }
        else
        {
            SelectCarOptions(redOptions, redBodyIndex);
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
            SelectCarOptions(blueOptions, blueBodyIndex);
            UpdateBodyText(blueBodyIndex);
        }
        else
        {
            redBodyIndex = (redBodyIndex - 1 + redOptions.bodys.Length) % redOptions.bodys.Length;
            SelectCarOptions(redOptions, redBodyIndex);
            UpdateBodyText(redBodyIndex);
        }
    }

    public void BodyRight()
    {
        if (isBlueActive)
        {
            blueBodyIndex = (blueBodyIndex + 1) % blueOptions.bodys.Length;
            SelectCarOptions(blueOptions, blueBodyIndex);
            UpdateBodyText(blueBodyIndex);
        }
        else
        {
            redBodyIndex = (redBodyIndex + 1) % redOptions.bodys.Length;
            SelectCarOptions(redOptions, redBodyIndex);
            UpdateBodyText(redBodyIndex);
        }
    }

    public void SelectCarOptions(CarOptions options, int bodyIndex)
    {
        // Display the current body sprite based on the index
        if (options.bodys.Length > 0)
            body.sprite = options.bodys[bodyIndex];
         /*
        // Set random tire sprite
        if (options.tires.Length > 0)
            tire.sprite = options.tires[Random.Range(0, options.tires.Length)];

        // Set random wing sprite
        if (options.wings.Length > 0)
            wing.sprite = options.wings[Random.Range(0, options.wings.Length)];

        // Set random paint color
        if (options.paint.Length > 0)
            body.color = options.paint[Random.Range(0, options.paint.Length)];
         */
    }

    private void UpdateBodyText(int currentIndex)
    {
        bodyText.text = currentIndex.ToString();
    }
}
