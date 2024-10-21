using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class RotateTable : MonoBehaviour
{
    [SerializeField] GameObject blackPiece;
    [SerializeField] GameObject whitePiece;
    [SerializeField] Transform[] slots;

    List<int> rotatedOrderIndexes;

    //reference a variable which is in another script
    private InstantiatePieces instantiatePieces;

    private void Start()
    {
        instantiatePieces = GetComponent<InstantiatePieces>();
    }

    public void RotatePieces()
    {
        //retriving the list's count from an external method (script)
        int numberPieces = instantiatePieces.PrefabsList();
        Debug.Log("The number of pieces in the list is: " + numberPieces);

        //prints each element with name and index
        string stringPieces = instantiatePieces.PrefabsStrings();
        Debug.Log("The list is ordered like this : " + stringPieces);

    }
    //this function will pass a list and do the magic
    public void RotateList<T>(List<T> list)
    {
        //verifies if the list is populated
        if (list.Count == 0) return;

        //takes the last element
        T lastElement = list[list.Count - 1];

        for (int i = list.Count - 1; i > 0; i--)
        {
            //moves each element to the right
            list[i] = list[i - 1];
        }

        //the last element will be placed to the first position of the list
        list[0] = lastElement;
    }

    public List<int> ActualIndexes()
    {
        //get the actual list of indexes
        return instantiatePieces.ListOfIndexes();
    }

    public List<int> RotateIndexes()
    {
        //creating a list so it can be passed as input
        List<int> rotatedIndexes = ActualIndexes();
        RotateList(rotatedIndexes);
        
        //saving the list to a global variable
        return rotatedOrderIndexes = rotatedIndexes;
    }

    public void DebugRotateIndexes()
    {
        List<int> rotatedIndexes = RotateIndexes();

        //convert the list of int into string
        string indexesString = string.Join(", ", rotatedIndexes);

        Debug.Log("The index order is now: " + indexesString);
    }

    public void SpawnGridOnNewIndexes(List<GameObject> gameObjects)
    {
        //debugging purposes
        if (gameObjects == null)
        {
            Debug.LogError("gameObjects is null");
            return;
        }

        //debugging purposes
        if (gameObjects.Count == 0)
        {
            Debug.LogError("gameObjects list is empty");
            return;
        }

        for (int i = 0; i < rotatedOrderIndexes.Count && i < slots.Length;  i++)
        {
            GameObject newPositions = Instantiate(gameObjects[i], slots[i].transform.position, slots[i].transform.rotation, slots[i]);
        }
    }

    public void SpawnNewGrid()
    {
        List<GameObject> gamePrefabs = instantiatePieces.listingPieces;
        
        //calling the method to instantiate the list of objects
        SpawnGridOnNewIndexes(gamePrefabs);
        Debug.Log("SpawnNewGrid was called");
    }
}
