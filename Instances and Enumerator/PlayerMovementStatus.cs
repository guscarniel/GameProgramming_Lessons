using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStatus : MonoBehaviour
{
    [SerializeField] private float velocity = 5;
    Rigidbody rb;
    float axisX;
    float axisY;

    //these status will change when touching game objects
    enum Status { Normal, Blue, Green, Red };
    Status status;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetDirections();
    }

    private void GetDirections()
    {
        axisX = Input.GetAxis("Horizontal");
        axisY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(axisX, 0, axisY);
        rb.MovePosition(rb.position + direction * velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //referencing objects by tags
        if (collision.gameObject.tag == "Cubo")
        {
            //changing status
            status = Status.Blue;
            Debug.Log(status);
            GetComponent<Renderer>().material.color = Color.blue;
        }

        if (collision.gameObject.tag == "Cubo1")
        {
            status = Status.Green;
            Debug.Log(status);
            GetComponent<Renderer>().material.color = Color.green;
        }

        if (collision.gameObject.tag == "Cubo2")
        {
            status = Status.Red;
            Debug.Log(status);
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //default color
        status = Status.Normal;
        Debug.Log(status);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
