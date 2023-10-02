using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //using _ for all private variables

    [SerializeField] private float _velocity = 10; //custom player's velocity
    private Rigidbody _rigidbody;
    float _axisX;
    float _axisY;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    //Update is always calling the function
    private void Update()
    {
        GetDirections();
    }

    //getting inputs
    private void GetDirections()
    {
        _axisX = Input.GetAxis("Horizontal");
        _axisY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //instancing a new Vector3 object and passing the inputs as arguments
        Vector3 direction = new Vector3(_axisX, 0, _axisY);

        //MovePosition is a property of the RigidBody
        _rigidbody.MovePosition(_rigidbody.position + direction * _velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //referencing objects by tags
        if (collision.gameObject.tag == "Cubo")
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }

        if (collision.gameObject.tag == "Cubo1")
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        if (collision.gameObject.tag == "Cubo2")
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //default color
        GetComponent<Renderer>().material.color = Color.white;
    }
}