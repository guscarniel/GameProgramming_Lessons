using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateNewTurn : MonoBehaviour
{
    [SerializeField] GameObject[] outerGrid;
    [SerializeField] GameObject[] innerGrid;

    public void MovePiecesOuterGrid()
    {
        // Loop through the outerGrid
        for (int i = 0; i < outerGrid.Length; i++)
        {
            GameObject nextSlotPosition = outerGrid[i].GetComponentInChildren<Slots>().nextSlot;

            // Check if this GameObject has any children
            if (transform.childCount > i)
            {
                // Get the current child transform
                Transform child = transform.GetChild(i);

                // Move the child's position to the corresponding slot
                if (child != null)
                {
                    child.position = nextSlotPosition.transform.position;
                }
            }
        }
    }

    public void MovePiecesInnerGrid() 
    {
        // Loop through the outerGrid
        for (int i = 0; i < innerGrid.Length; i++)
        {
            GameObject nextSlotPosition = innerGrid[i].GetComponentInChildren<Slots>().nextSlot;

            // Check if this GameObject has any children
            if (transform.childCount > i)
            {
                // Get the current child transform
                Transform child = transform.GetChild(i);

                // Move the child's position to the corresponding slot
                if (child != null)
                {
                    child.position = nextSlotPosition.transform.position;
                }
            }
        }
    }
    
    public void RotateTable()
    {
        //makes the next turn
        MovePiecesOuterGrid();
        MovePiecesInnerGrid();
    }
}

