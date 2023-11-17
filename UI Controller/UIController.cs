using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] string PrintCustomText = "Default text";
    [SerializeField] TMP_InputField inputField; //UI element from the UI library

    [SerializeField] GameObject panel001;
    [SerializeField] GameObject panel002;
    [SerializeField] GameObject panel003;
    [SerializeField] GameObject panel004;
    [SerializeField] GameObject panel005;
    [SerializeField] GameObject panel006;
    [SerializeField] GameObject panel007;

    void Start()
    {
        Default();
    }

    //start the game with the correct panels actives
    public void Default()
    {
        panel001.SetActive(true);
        panel002.SetActive(false);
        panel003.SetActive(false);
        panel004.SetActive(false);
        panel005.SetActive(false);
        panel006.SetActive(false);
        panel007.SetActive(false);
    }

    //load scenes from build settings
    public void LoadSceneMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSceneTransform()
    {
        panel007.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void LoadSceneShooter()
    {
        panel007.SetActive(false);
        SceneManager.LoadScene(2);
    }

    public void LoadScenePlatform()
    {
        panel007.SetActive(false);
        SceneManager.LoadScene(3);
    }

    //close the build
    public void Quit()
    {
        Application.Quit();
    }

    //move to the menu's options panels
    public void MenuToLevels()
    {
        panel002.SetActive(false);
        panel007.SetActive(true);
    }

    public void MenuToCredits()
    {
        panel001.SetActive(false);
        panel003.SetActive(true);
    }

    public void MenuToSettings()
    {
        panel001.SetActive(false);
        panel005.SetActive(true);
    }

    //return from advanced layers to the main menu
    public void BackFromLevels()
    {
        panel007.SetActive(false);
        panel001.SetActive(true);
    }

    public void BackFromCredits()
    {
        panel003.SetActive(false);
        panel001.SetActive(true);
    }

    public void BackFromSettings()
    {
        panel005.SetActive(false);
        panel001.SetActive(true);
    }

    //show UI panels warnings
    public void UserDeny()
    {
        panel002.SetActive(false);
        panel004.SetActive(false);
        panel001.SetActive(true);
    }

    public void QuitConfirm()
    {
        panel004.SetActive(true);
    }

    public void QuitDeny()
    {
        panel004.SetActive(false);
        panel001.SetActive(true);
    }

    //debugs and get text's input 
    public void InputField()
    {
        string inputFieldString = inputField.text;
        Debug.Log(inputFieldString);
        PlayerPrefs.GetString("INPUTFIELD", inputFieldString);
    }

    public void CustomTextLog()
    {
        Debug.Log(PrintCustomText);
    }

    public void GameStartConfirmation()
    {
        Debug.Log("Game Started!");
    }

    public void DenyGameStart()
    {
        panel001.SetActive(false);
        panel002.SetActive(true);

        if (inputField.text == "")
        {
            Debug.Log("You need to enter your name!");
        }
    }
}
