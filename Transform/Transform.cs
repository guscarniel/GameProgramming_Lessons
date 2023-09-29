using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform : MonoBehaviour
{
    private UnityEngine.Transform myTransform;

    [SerializeField] int userXValueRotation; //custom input value
    [SerializeField] int userScaleValue; //custom input value

    void Start()
    {
        myTransform = GetComponent<UnityEngine.Transform>();
    }

    void Update()
    {
        Directions(); //this method is always being called

        if (Input.GetKeyDown(KeyCode.Space))
            ScaleUp();

        if (Input.GetKeyDown(KeyCode.LeftControl))
            ScaleDown();

        if (Input.GetKeyDown(KeyCode.R))
            CustomXRotation();
    }

    void Directions()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 vc3 = new Vector3(1, 0, 0); //Instantiated a new object to be used as a Translate argument
            myTransform.Translate(vc3, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myTransform.Translate(Vector3.left, Space.World); //another way of using Vector3
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myTransform.Translate(Vector3.up, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myTransform.Translate(Vector3.down, Space.World);
        }
    }

    void ScaleUp()
    {
        myTransform.localScale += new Vector3(userScaleValue, userScaleValue, userScaleValue);
    }

    void ScaleDown()
    {
        myTransform.localScale -= new Vector3(userScaleValue, userScaleValue, userScaleValue);
    }

    void CustomXRotation()
    {
        Vector3 vc3 = new Vector3(userXValueRotation, 0, 0);
        myTransform.Rotate(vc3);
    }
}