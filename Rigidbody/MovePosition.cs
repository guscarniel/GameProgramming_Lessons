using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour
{
    [SerializeField] private float speed = 10; //to be used inside MovePosition
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
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime); //MovePosition is easier to control the final position
    }
}
