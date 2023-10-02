using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStatus : MonoBehaviour
{
    // Using _ for all private variables

    [SerializeField] private float _velocity = 5;
    private Rigidbody _rigidbody;
    float _axisX;
    float _axisY;

    enum Status { Normal, Blue, Green, Red };
    Status status;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    //always calling the function
    private void Update()
    {
        GetDirections();
    }

    // Getting the input
    private void GetDirections()
    {
        _axisX = Input.GetAxis("Horizontal");
        _axisY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // Instancing Vector3 and passing the inputs as arguments for the translate
        Vector3 direction = new Vector3(_axisX, 0, _axisY);

        // MovePosition is a property of the RigidBody
        _rigidbody.MovePosition(_rigidbody.position + direction * _velocity * Time.deltaTime);
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
        // Default color
        status = Status.Normal;
        Debug.Log(status);
        GetComponent<Renderer>().material.color = Color.white;
    }
}
