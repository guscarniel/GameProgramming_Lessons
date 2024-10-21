using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTable : MonoBehaviour
{

    [SerializeField] GameObject blackPiece;
    [SerializeField] GameObject whitePiece;
    [SerializeField] Transform[] slots;

    //reference a variable which is in another script
    private InstantiatePieces instantiatePieces;

    List<GameObject> newGamePrefabs = new List<GameObject>();

    int checkNumberClicks = 0;

    private void Start()
    {
        instantiatePieces = GetComponent<InstantiatePieces>();
    }

    public void DebugListInformation()
    {
        //retriving the list's count from an external method (script)
        int numberPieces = instantiatePieces.PrefabsList();
        Debug.Log("The number of pieces in the list is: " + numberPieces);

        //prints each element with name and index
        string stringPieces = instantiatePieces.PrefabsStrings();
        Debug.Log("The list is ordered like this : " + stringPieces);
    }

    public List<int> DebugActualIndexes()
    {
        //get the actual list of indexes
        return instantiatePieces.ListOfIndexes();
    }

    public void MovePiecesOnGrid(List<GameObject> gameObjects, Transform[] slots)
    {
        //verify if the list is populated and slots are available
        if (gameObjects.Count == 0 || slots.Length == 0) return;

        //store the last piece (to wrap it around)
        GameObject lastPiece = gameObjects[gameObjects.Count - 1];

        //the loop continues as long as i is greater than 0
        for (int i = gameObjects.Count - 1; i > 0; i--)
        {
            //move the current piece to the next slot
            gameObjects[i].transform.position = slots[i - 1].position;
        }

        //move the first piece to the last slot
        gameObjects[0].transform.position = slots[gameObjects.Count - 1].position;

        //moves all the reordenated pieces one slot further
        for (int i = 0; i < gameObjects.Count; i++)
        {
            //updates to a new list order
            //newGamePrefabs.Add(gameObjects[i]);

            //the modulo operator % is used to wrap around the index and create a circular behaviour ((4 + 1) % 5 = 0)
            int newSlotIndex = (i + 1) % slots.Length;
            gameObjects[i].transform.position = slots[newSlotIndex].position;
        }
    }

    public void SpawnNewGrid()
    {
        checkNumberClicks++;
        List<GameObject> gamePrefabs = instantiatePieces.listingPieces;

        //calling the method to instantiate the list of objects
        MovePiecesOnGrid(gamePrefabs, slots);
        Debug.Log("SpawnNewGrid was called");

        /*if (checkNumberClicks >= 2)
        {
            MovePiecesOnGrid(newGamePrefabs, slots);
            Debug.Log("New order of game objects");
        }*/
    }
}
