using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resolutions : MonoBehaviour
{
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] Toggle checkMark;

    List<string> resolutionNames = new List<string>();
    Resolution[] resolutionsMonitor = Screen.resolutions;

    public void FillResolutionDropDown()
    {
        

        for (int i = 0; i < resolutionsMonitor.Length; i++)
        {
            string resolution = resolutionsMonitor[i].width + " x " + resolutionsMonitor[i].height + " (" + resolutionsMonitor[i].refreshRate + "Hz)";
            Debug.Log(resolution);
            resolutionNames.Add(resolution);
        }         
    }

    public void SetResolution(int i)
    {
        Resolution[] resolutionsMonitor = Screen.resolutions;
        Screen.SetResolution(resolutionsMonitor[i].width, resolutionsMonitor[i].height, true, resolutionsMonitor[i].refreshRate);

        bool isFullScreen = PlayerPrefs.GetInt("FULLSCREEN") == 1;

        PlayerPrefs.SetInt("RESOLUTION", i);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Debug.Log(isFullScreen);

        Screen.fullScreen = isFullScreen;

        //using ternary operation to check for the value of the boolean. 1 active - 0 off
        PlayerPrefs.SetInt("FULLSCREEN", isFullScreen ? 1 : 0);
    }

    public void LoadScreenSettings()
    {
        Debug.Log("Loading screen settings...");

        //getting the values from keys
        int resolutionIndex = PlayerPrefs.GetInt("RESOLUTION");

        //here == 1 have a comparison purpose
        bool isFullScreen = PlayerPrefs.GetInt("FULLSCREEN") == 1;

        Resolution resolution = resolutionsMonitor[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen);

        checkMark.SetIsOnWithoutNotify(isFullScreen);
        resolutionDropdown.SetValueWithoutNotify(resolutionIndex);

        Debug.Log("Screen settings loaded.");
    }
}
