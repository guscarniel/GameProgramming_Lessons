using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class naveMeshAI : MonoBehaviour
{
    //assigning to a variable
    NavMeshAgent agent;
    
    //vector3 direction
    [SerializeField] Transform objective;

    bool isFollowing;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //inverts the bool's value whenever pressing space
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFollowing = !isFollowing;
        }     
    }

    //with this condition, it will go to the last player's location until the bool is updated
    private void FixedUpdate()
    {
        if (isFollowing == true)
        {
            agent.SetDestination(objective.position);
        }
    }
}
