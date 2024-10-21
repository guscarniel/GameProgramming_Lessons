using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiatePieces : MonoBehaviour
{
    [SerializeField] GameObject blackPiece;
    [SerializeField] GameObject whitePiece;
    [SerializeField] Transform[] slots;
    [SerializeField] Button spawnBlackButton;
    [SerializeField] Button spawnWhiteButton;

    public List<GameObject> listingPieces = new List<GameObject>();

    private int listCount = 0;

    public void InstantiateBlack()
    {
        Debug.Log("The array's length is " + slots.Length);

        //when this condition is met, the code will stop running
        if (listCount >= slots.Length)
        {           
            Debug.Log("Out of slots!");
            spawnBlackButton.interactable = false;
            return;
        }

        //writing the slot's position for debug purposes
        Transform currentSlot = slots[listCount];
        Debug.Log("Instantiating black piece at slot: " + currentSlot.position);

        //instantiate a defined prefab for each slot 
        GameObject instantiatedPrefab = Instantiate(blackPiece, slots[listCount].position, Quaternion.identity, slots[listCount].transform);
        
        //add the previous instantiated prefab to the list
        listingPieces.Add(instantiatedPrefab);
        
        //adding up to the int variable counter
        listCount++;

        ////debug purposes
        Debug.Log("The list's length is " + listingPieces.Count);
        Debug.Log("The slot's count is on " + listCount);
        Debug.Log("Black piece is on the board");
    }

    //follows the same logic as the previous one
    public void InstantiateWhite()
    {
        Debug.Log("The array's length is " + slots.Length);

        if (listCount >= slots.Length)
        {
            Debug.Log("Out of slots!");
            spawnBlackButton.interactable = false;
            return;
        }

        Transform currentSlot = slots[listCount];
        Debug.Log("Instantiating white piece at slot: " + currentSlot.position);

        GameObject instantiatedPrefab = Instantiate(whitePiece, slots[listCount].position, Quaternion.identity, slots[listCount]);
        listingPieces.Add(instantiatedPrefab);
        listCount++;

        Debug.Log("The list's length is " + listingPieces.Count);
        Debug.Log("The slot's count is on " + listCount);
        Debug.Log("White piece is on the board");
    }

    //this method returns an integer of the current count list and prints all elements
    public int PrefabsList()
    {
        return listingPieces.Count;
    }

    //this method is for debugging purposes
    public string PrefabsStrings()
    {
        //declaring a new list
        List<string> names = new List<string>();

        for (int i = 0; i < listingPieces.Count; i++)
        {
            //adding each name to the list individually
            names.Add($"{i}: {listingPieces[i]}");
        }

        //it will join all the names in one string
        return string.Join(", ", names);
    }

    //this method will pass a list of gameobjects and get their indexes
    public List<int> GetIndexesFromGameObjects(List<GameObject> gameObjects)
    {
        // Declarando uma nova lista para armazenar os índices
        List<int> indexes = new List<int>();

        for (int i = 0; i < gameObjects.Count; i++)
        {
            // Adicionando o índice de cada GameObject na lista
            indexes.Add(i); // Adiciona o índice do loop
        }

        return indexes; // Retorna a lista de índices
    }

    //returning the indexes so they can be remaped later
    public List<int> ListOfIndexes()
    {
        return GetIndexesFromGameObjects(listingPieces);
    }
}
