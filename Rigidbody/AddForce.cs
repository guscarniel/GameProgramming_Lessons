using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private Rigidbody rb;
    float axisX;
    float axisY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        axisX = Input.GetAxisRaw("Horizontal");
        axisY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Debug.Log(axisX);
        Debug.Log(axisY);

        Vector3 direction = new Vector3(axisX, axisY, 0);
        rb.AddForce(direction * 2000 * Time.deltaTime); //AddForce is meant to inertia purposes, like bullets and rockets
    }
}
