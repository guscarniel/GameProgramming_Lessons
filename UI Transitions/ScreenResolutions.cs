using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenResolutions : MonoBehaviour
{
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] Toggle checkMark;

    private Resolution[] resolutionArray;
    private List<Resolution> resolutionList;

    private float currentRefreshRate;
    private int currentResolutionIndex;

    void Start()
    {
        //adding screen resolutions to the array
        resolutionArray = Screen.resolutions;

        //creating a new list of resolutions
        resolutionList = new List<Resolution>();

        //clearing the dropdown menu with the built-in ClearOptions() method
        resolutionDropdown.ClearOptions();

        //getting the current refresh rate and saving it to a variable of type float
        currentRefreshRate = Screen.currentResolution.refreshRate;

        
        //cheking if my current monitor refresh rate is the same as the options in the array
        for (int i = 0; i < resolutionArray.Length; i++)
        {
            //if the condition is true, the resolution will be added to the list
            if (resolutionArray[i].refreshRate == currentRefreshRate)
            {
                resolutionList.Add(resolutionArray[i]);
            }
        }

        //pasting the list of resolutions to the dropdown
        List<string> screenOptions = new List<string>();

        for (int i = 0; i < resolutionList.Count; i++)
        {
            //creating the list of strings that will be printed on the menu and saving them on a variable of type string
            string resolutionStringList = resolutionList[i].width + "x" + resolutionList[i].height + " " + resolutionList[i].refreshRate + "Hz";

            //adding the previous string concatenation to the list
            screenOptions.Add(resolutionStringList);


            //checking if the list matches the resolutions of my monitor
            if (resolutionList[i].width == Screen.width && resolutionList[i].height == Screen.height)
            {
                //set the current resolution index to the resolution index i
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(screenOptions);

        LoadScreenSettings();
    }

    //this function will set the chosen resolution
    public void SetResolution(int resolutionIndex)
    {
        Debug.Log("Setting resolution index: " + resolutionIndex);

        bool isFullScreen = PlayerPrefs.GetInt("FULLSCREEN") == 1;

        Resolution resolution = resolutionList[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen);

        PlayerPrefs.SetInt("RESOLUTION", resolutionIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Debug.Log(isFullScreen);

        Screen.fullScreen = !Screen.fullScreen;
        //Screen.fullScreen = isFullScreen;

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

        Resolution resolution = resolutionList[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen, resolution.refreshRate);

        checkMark.SetIsOnWithoutNotify(isFullScreen);
        resolutionDropdown.SetValueWithoutNotify(resolutionIndex);

        Debug.Log("Screen settings loaded.");
    }

}