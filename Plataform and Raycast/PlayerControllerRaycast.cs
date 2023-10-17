using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRaycast : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 15f;
    [SerializeField] float jumpForce = 12f;
    [SerializeField] float interactionDistance = 50f;
    float isMovingHorizontal;
    bool isLookingRight = true;

    void Start()
    {
        //the component Rigidbody2D (which is inside the object this script is attached to) is now available to be accessed from the rb variable
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Raw goes from 0 to 1 and 0 to -1
        isMovingHorizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log(isMovingHorizontal);

        //this function uses isMovingHorizontal as the argument it asks for
        PlayerLooking(isMovingHorizontal);

        MovePlayer();

        JumpPlayer();

        if (Input.GetKey(KeyCode.R))
        {
            RaycastInteraction();
        }

        if (Input.GetKey(KeyCode.M))
        {
            MultipleRaycastInteraction();
        }

        if (Input.GetKey(KeyCode.C))
        {
            CircleRaycastInteraction();
        }

        if (Input.GetKey(KeyCode.O))
        {
            CircleOverlapRaycastInteraction();
        }
    }

    private void OnDrawGizmos()
    {
        //not the actual Raycast just for visualization purposes
        if (Input.GetKey(KeyCode.E))
        {
            //first define the color of the gizmo - it need to be fully opaque (1)
            Gizmos.color = Color.red;

            if (isLookingRight == true)
                Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + interactionDistance, transform.position.y));

            //invert the raycast direction based on the bool variable
            if (isLookingRight == false)
                Gizmos.DrawLine(transform.position, new Vector2(transform.position.x - interactionDistance, transform.position.y));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, interactionDistance);
        }
    }

    void MovePlayer()
    {
        //velocity is for 2D linear movement, since it is a Vector2. The Y axis keeps the velocity of the Rigidbody2D
        rb.velocity = new Vector2(isMovingHorizontal * speed, rb.velocity.y);
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //add the float value to the Y axis
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("Jump");
        }
    }

    //returns -1, 0 or 1. the variable lastMovement only exists inside this function to save memory
    protected void PlayerLooking(float lastMovement)
    {
        if (lastMovement > 0 && isLookingRight == false)
        {
            //updates the variable because now it's looking to the right
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            isLookingRight = true;
        }

        if (lastMovement < 0 && isLookingRight == true)
        {
            //flips the scale on the X axis
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            isLookingRight = false;
        }
    }

    //shoots a straight line and returns only the 1st object it hits
    void RaycastInteraction()
    {
        //7 is the layer to ignore casting. no array needed, it stores one value
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, interactionDistance, 7);

        //if the first object next to the player exists and the tag is equal to "Item", object will be destroyed
        if (hit.transform && hit.transform.gameObject.tag == "Item")
        {
            Destroy(hit.transform.gameObject);
        }
    }
    //stores in an array all objects that were hitted by the ray
    void MultipleRaycastInteraction()
    {
        //stores all objects that were hitted
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.right, interactionDistance);
        Debug.Log(hits.Length);

        //loop for each element in the array
        foreach (RaycastHit2D hit in hits)
        {
            //destroy the objects with tags and preserve the non tagged
            if (hit.transform && hit.transform.gameObject.tag == "Item")
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    //creates a circle around the origin with range and distance from origin. store the casts in an array
    void CircleRaycastInteraction()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, interactionDistance, Vector2.zero);
        Debug.Log(hits.Length);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform && hit.transform.gameObject.tag == "Item")
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    //uses the Collider class to store the hits. this is a way that uses less memory to store more objects in an array
    void CircleOverlapRaycastInteraction()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionDistance);
        foreach (Collider2D hit in hits)
        {
            if (hit.transform && hit.transform.gameObject.tag == "Item")
            {
                Destroy(hit.transform.gameObject);
            }

        }
    }
}
