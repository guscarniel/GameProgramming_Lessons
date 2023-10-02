using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    //this script will be a component of an empty

    [SerializeField] private GameObject[] selectableObjects; //array of Gameobjects to be selected

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //press 1
            SelectObjects(0); //call the function

        if (Input.GetKeyDown(KeyCode.Alpha2)) //press 2
            SelectObjects(1);

        if (Input.GetKeyDown(KeyCode.Alpha3)) //press 3
            SelectObjects(2);
    }

    void SelectObjects(int selectedObjectIndex)
    {
        foreach (GameObject obj in selectableObjects) //deselect all
        {
            obj.SetActive(false);
        }

        selectableObjects[selectedObjectIndex].SetActive(true); //activate the selected object
    }
}