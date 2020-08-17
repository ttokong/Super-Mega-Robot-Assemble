using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // references to audiomixer
    public AudioMixer audioMixer;

    // references to dropdown
    public Dropdown resolutionDropdown;

    // stores an array of available resolutions
    Resolution[] resolutions;

    public Toggle skipTutorial;
    int check;
    bool checkSpace = true;

    void Start()
    {
        resolutions = Screen.resolutions;

        // clears out the defult option we have on the dropdown
        resolutionDropdown.ClearOptions();

        // to turn the array of resolutions into strings
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        // loops through each element in resolutions array
        for (int i = 0; i < resolutions.Length; i++)
        {
            // creates a formatted string for each of them
            string option = resolutions[i].width + " X " + resolutions[i].height;
            // adds it to options list
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        skipTutorialCheck();
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    void skipTutorialCheck()
    {
        check = PlayerPrefs.GetInt("skipTutorial");

        if (check == 0)
        {
            skipTutorial.isOn = false;
            checkSpace = false;
            Debug.Log("off");
        }
        else
        {
            skipTutorial.isOn = true;
            checkSpace = false;
            Debug.Log("on");
        }
    }

    
    public void skipingTutorial()
    {
        if (!checkSpace)
        {
            check = PlayerPrefs.GetInt("skipTutorial");

            if (check == 0)
            {
                PlayerPrefs.SetInt("skipTutorial", 1);
                Debug.Log("set on");
            }
            else
            {
                PlayerPrefs.SetInt("skipTutorial", 0);
                Debug.Log("set off");
            }
        }

        checkSpace = false;
    }

}
