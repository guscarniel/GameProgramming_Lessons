using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPreferences : MonoBehaviour
{
    //select the dynamic float volume function inside the slider button
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        LoadSettings();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
            else
                audioSource.Play();
        }
    }

    public void Volume(float sliderValue)
    {
        Debug.Log(sliderValue);
        float convertedSliderVolume = Mathf.Log10(sliderValue) * 20f;
        //the value is set on the audio mixer's exposed parameter VolumeSlider
        audioMixer.SetFloat("VolumeSlider", convertedSliderVolume);
        
        //saving the values of volume and the position of the slider with SetFloat
        PlayerPrefs.SetFloat("VOLUME", convertedSliderVolume);
        PlayerPrefs.SetFloat("VOLUME_SLIDER", sliderValue);
    }

    void LoadSettings()
    {
        float previousVolume;
        //using GetFloat to load VOLUME information on the System Registry
        previousVolume = PlayerPrefs.GetFloat("VOLUME");
        //the value is set on the audio mixer's exposed parameter VolumeSlider
        audioMixer.SetFloat("VolumeSlider", previousVolume);

        float previousSliderPosition;
        previousSliderPosition = PlayerPrefs.GetFloat("VOLUME_SLIDER");
        volumeSlider.SetValueWithoutNotify(previousSliderPosition);
    }

}
