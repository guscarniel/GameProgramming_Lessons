using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] private float speed = 10; //this value will be used inside MovePosition
    private Rigidbody rb;
    float axisX; //variable with no value declared
    float axisY;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //assign the object Rigidbody to the variable rb
    }

    void Update() //do not apply physics here, instead capture the user's input
    {
        axisX = Input.GetAxisRaw("Horizontal"); //GetAxisRaw is nice for 2D because returns integer numbers
        axisY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Debug.Log(axisX);
        Debug.Log(axisY);

        Vector3 direction = new Vector3(axisX, axisY, 0);
        rb.velocity = direction * speed; //move the objetct by changing the direction speed
    }
}

