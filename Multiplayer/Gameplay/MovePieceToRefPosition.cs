using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePieceToRefPosition : MonoBehaviour
{
    [SerializeField] Slots firstPoint;
    InstantiatePieces instantiatePieces;
    RotateNewTurn prefabComponentPosition;
    public void MovePiecesOnGrid()
    {
        GetComponent<RotateNewTurn>();

        for (int i = 0; instantiatePieces.listingPieces.Count < i; i++)
        {


           // transform.position = firstPoint.referencePositionPoint.transform.position;
            //firstPoint = firstPoint.referencePositionPoint;
        }

        
    }
}
