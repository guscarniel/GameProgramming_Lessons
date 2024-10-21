using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenPosition : MonoBehaviour
{

    public Vector3 PiecePosition()
    {
        return this.gameObject.transform.position;
    }
   
}
