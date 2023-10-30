using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] string PrintCustomText = "Default text";
    [SerializeField] TMP_InputField inputField; //UI element from the UI library

    [SerializeField] GameObject panelOne;
    [SerializeField] GameObject panelTwo;
    [SerializeField] GameObject panelThree;
    [SerializeField] GameObject panelFour;
    [SerializeField] GameObject panelFive;

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Default();
    }

    public void Default() //this safely start the game even panels are disable in the editor
    {
        panelOne.SetActive(true);
        panelTwo.SetActive(false);
        panelThree.SetActive(false);
        panelFour.SetActive(false);
        panelFive.SetActive(false);
    }

    public void FullScreen(bool isMax)
    {
        Debug.Log(isMax);
        Screen.fullScreen = isMax;
    }

    public void CustomTextLog()
    {
        Debug.Log(PrintCustomText);
    }

    public void GameStartConfirmation()
    {
        Debug.Log("Game Started!");
    }

    public void InputField()
    {
        string inputFieldString = inputField.text; //can be saved as string
        //Debug.Log(inputFieldString);
    }

    public void GameStart()
    {
        if (inputField.text == "")
        {
            Debug.Log("You need to enter your name!");
        }
        else
        {
            panelOne.SetActive(false);
            panelTwo.SetActive(true);
        }
    }

    public void Credits()
    {
        panelOne.SetActive(false);
        panelThree.SetActive(true);
    }

    public void Settings()
    {
        panelOne.SetActive(false);
        panelFive.SetActive(true);
    }

    public void BackFromSettings()
    {     
        panelFive.SetActive(false);
        panelOne.SetActive(true);
    }

    public void UserConfirm()
    {
        panelTwo.SetActive(false);
        SceneManager.LoadScene(1); //load scene 1 from build settings
    }

    public void UserDeny()
    {
        panelTwo.SetActive(false);
        panelOne.SetActive(true);
    }

    public void QuitConfirm()
    {
        panelFour.SetActive(true);
    }

    public void QuitDeny()
    {
        panelFour.SetActive(false);
        panelOne.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Volume(float value)
    {
        Debug.Log(value);
        float convertedVolume = Mathf.Log10(value) * 20f;
        audioMixer.SetFloat("VolumeSlider", convertedVolume);
    }

    // Update is called once per frame
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
}
