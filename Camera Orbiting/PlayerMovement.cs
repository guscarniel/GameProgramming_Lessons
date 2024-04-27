using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //inputs and parameters
    [SerializeField] float speed;
    
    float verticalInput;
    
    float horizontalInput;
    
    Vector3 finalDirection;
    
    Rigidbody objectRigidbody;


    //getting the component into the variable
    void Start() 
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    //here it checks for the inputs
    void Update()
    {
        GetInputs();
    }

    //here it apllies the physics
    private void FixedUpdate()
    {
        PlayerMove();
    }

    void GetInputs()
    {
        //assign the player's inputs to these variables
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //the previous vector values (x and z axis) are assigned to finalDirection, as a Vector3 data
        finalDirection = new Vector3 (horizontalInput, 0, verticalInput);
    }

    //using velocity to move the player, as it uses a vector for position
    void PlayerMove()
    {
        objectRigidbody.velocity = finalDirection * speed;
    }

}
