using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DisplayMenu : MonoBehaviour
{
    [SerializeField] TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;
    const string resName = "resolutionOption";
    const string prefname = "optionValue";
    private int screenInt;

    [SerializeField] Toggle fullScreenToggle;

    private void Awake()
    {
        screenInt = PlayerPrefs.GetInt("toggleState");

        if (screenInt == 1)
        {
            Screen.fullScreen = true;
            fullScreenToggle.isOn = true;
        }
        else
        {
            fullScreenToggle.isOn = false;
        }

        resolutionDropDown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName, resolutionDropDown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();
        HashSet<string> uniqueResolutions = new HashSet<string>();

        int currentResolutionIndex = 0;

        // Sort the resolutions in reverse order (largest width first)
        System.Array.Sort(resolutions, (a, b) =>
        {
            int result = b.width.CompareTo(a.width);
            if (result == 0)
            {
                result = b.height.CompareTo(a.height);
            }
            return result;
        });

        for (int i = 0; i < resolutions.Length; i++)
        {
            // Create a string without the refresh rate
            string resolutionString = resolutions[i].width + " x " + resolutions[i].height;

            // Check if this resolution has already been added
            if (!uniqueResolutions.Contains(resolutionString))
            {
                // Add it to the unique resolutions set and to the options list
                uniqueResolutions.Add(resolutionString);
                options.Add(resolutionString);
            }

            if (resolutions[i].width == Screen.currentResolution.width &&
              resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resolutionDropDown.RefreshShownValue();
    }

    public void SetFullScreen(bool setFullscreen)
    {
        Screen.fullScreen = setFullscreen;
        if (!setFullscreen)
        {
            PlayerPrefs.SetInt("toggleState", 0);
        }
        else
        {
            PlayerPrefs.SetInt("toggleState", 1);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
