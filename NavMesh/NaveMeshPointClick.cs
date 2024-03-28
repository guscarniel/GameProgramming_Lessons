using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class naveMeshPointClick : MonoBehaviour
{
    NavMeshAgent agent;

    //the camera is where the ray comes from
    [SerializeField] Camera mainCamera;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //gets the point on the screen and shoots a ray to that point
            Ray cameraRay;
            cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hittedObject;

            //sets the destination to the one saved in the variable above
            if (Physics.Raycast(cameraRay, out hittedObject))
            {
                agent.SetDestination(hittedObject.point);
            }
        }
    }
}
