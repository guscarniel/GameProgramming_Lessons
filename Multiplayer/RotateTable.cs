using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (list.Count == 0) return; // Verifica se a lista não está vazia

        T lastElement = list[list.Count - 1]; // Pega o último elemento

        for (int i = list.Count - 1; i > 0; i--)
        {
            list[i] = list[i - 1]; // Move cada elemento para a direita
        }
        list[0] = lastElement; // Coloca o último elemento na primeira posição
    }

    public List<int> ActualIndexes()
    {
        //get the actual list of indexes
        return instantiatePieces.ListOfIndexes();
    }

    public List<int> RotateIndexes()
    {
        //creating a list so it can be passed as an input
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
        if (gameObjects == null)
        {
            Debug.LogError("gameObjects is null");
            return;
        }

        if (gameObjects.Count == 0)
        {
            Debug.LogError("gameObjects list is empty");
            return;
        }

        for (int i = 0; i < rotatedOrderIndexes.Count && i < slots.Length;  i++)
        {
            GameObject newPositions = Instantiate(gameObjects[i], this.transform.position, this.transform.rotation, slots[i]);
        }
    }

    public void SpawnNewGrid()
    {
        //here it is necessary to create an instance of the class so it can be accessed
        InstantiatePieces instantiatePiecesInstance = new InstantiatePieces();
        
        List<GameObject> gamePrefabs = instantiatePiecesInstance.listingPieces;
        SpawnGridOnNewIndexes(gamePrefabs);
    }
}
