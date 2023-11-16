using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //you need to be using UnityEngine.UI
    //this is the text that will print the time on the screen
    [SerializeField] TMP_Text textTimer;

    //this variable holds the values
    float timer = 0;

    void Update()
    {
        //updates timer at every tick
        timer += Time.deltaTime;

        //rounds the timer value to the nearest integer
        int roundedTimer = Mathf.RoundToInt(timer);

        //converts integer to string and updates the text
        textTimer.text = roundedTimer.ToString();
    }

}
