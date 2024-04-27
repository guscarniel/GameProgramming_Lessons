using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    [SerializeField] Transform cameraTarget;
    
    //default camera distance from the object it is orbiting
    [SerializeField] Vector3 cameraDistance = new Vector3 (0, 3, -5);

    [SerializeField] Vector3 cameraOffset;

    //default values to the camera's rotation sensibility. using Vector2 for this because usually a screen is not square
    [SerializeField] Vector2 cameraRotationSensibility = new Vector3 (1, 1);

    Vector3 cameraFinalPosition;

    public Vector2 mouseInput;

    public float scrollInput;

    //whenever mouse moves, apply the player's rotation
    float rotation;


    //the calling order matters
    void Update()
    {
        GetMouseInputs();
        ApplyMouseInputs();

        SettingCameraPosition();
        RotateCameraAround();
        CameraLookAtTarget();
    }

    //read mouse and store values in the variables
    void GetMouseInputs()
    {
        mouseInput.x = Input.GetAxis("Mouse X");
        mouseInput.y = Input.GetAxis("Mouse Y");
        scrollInput = Input.GetAxis("Mouse ScrollWheel");
    }

    //it is important to determine what axis, since it's an integer
    void ApplyMouseInputs()
    {
        rotation += mouseInput.x * cameraRotationSensibility.x;
    }

    void SettingCameraPosition()
    {
        //camera goes inside the target (0,0,0)
        cameraFinalPosition = cameraTarget.position;

        //applying the distance using the cameraDistance vectors. this is world based not player based
        cameraFinalPosition += Vector3.forward * cameraDistance.z;
        cameraFinalPosition += Vector3.right * cameraDistance.x;
        cameraFinalPosition += Vector3.up * cameraDistance.y;

        //by the previous logic, the variable is updated
        this.transform.position = cameraFinalPosition;
    }

    //what will it rotate around, what global axis it will rotate from, how much degrees 
    void RotateCameraAround() 
    {
        this.transform.RotateAround(cameraTarget.position, Vector3.up, rotation); 
    }

    void CameraLookAtTarget()
    {
        this.transform.LookAt(cameraTarget);
    }

}
