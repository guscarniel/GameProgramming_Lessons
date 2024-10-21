using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

        public GameObject parentObject; // Assign your null GameObject in the Inspector

        public void DoTheMagic()
        {
            Transform[] children = parentObject.GetComponentsInChildren<Transform>(true);

            for (int i = 1; i < children.Length; i++)
            {
                // Get the next GameObject in the list
                Transform currentChild = children[i];
                Transform nextSibling = children[i + 1];

                if (nextSibling != null)
                {
                    // Set the current child's position to the next sibling's position
                    currentChild.position = nextSibling.position;
                }
            }
        }
    }

