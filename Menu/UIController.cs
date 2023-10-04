using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] string PrintCustomText = "Default text";
    [SerializeField] GameObject panelOne;
    [SerializeField] GameObject panelTwo;
    [SerializeField] GameObject panelThree;

    [SerializeField] TMP_InputField inputField; //UI element from the UI library


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

    // Update is called once per frame
    void Update()
    {

    }
}
