using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRelativeMovement : MonoBehaviour
{
    Rigidbody rb;

    Transform playerTransform;

    [SerializeField] Transform sceneCamera;

    [SerializeField] float movementSpeed = 7;
    [SerializeField] float rotationSpeed = 3;

    Vector2 inputMovement;
    Vector3 movementDirection;

    void Start()
    {
        //the first one do not need for GetComponent because Unity knows that transform is always there
        playerTransform = this.transform;
        rb = GetComponent<Rigidbody>();
    }

    //inputs goes here
    void Update()
    {
        GetInput();
        SetPlayerDirection();  
    }

    //physics goes here
    private void FixedUpdate()
    {
        ApplyMovement();
    }

    //assign the player's inputs to the inputMovement variable, but having to break it for each dimension
    void GetInput()
    {
        inputMovement.x = Input.GetAxis("Horizontal");
        inputMovement.y = Input.GetAxis("Vertical");
    }

    void SetPlayerDirection()
    {
        //always move towards the camera's front
        movementDirection = sceneCamera.forward * inputMovement.y;

        //adding to the previous values so it is now able to move horizontally
        movementDirection += sceneCamera.right * inputMovement.x;

        //we need to normalize, so it's not sum the two vectors above.
        //the vector will be projected to the ground and this will be used to player stay on the ground
        //in this case Vector3.up is being used because the ground is flat
        movementDirection = Vector3.ProjectOnPlane(movementDirection, Vector3.up);
    }

    //how the movement will occur
    void ApplyMovement()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
}
