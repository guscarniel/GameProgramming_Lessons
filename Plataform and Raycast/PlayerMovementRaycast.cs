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
        rb = GetComponent<Rigidbody2D>();
        //the component Rigidbody2D (which is inside the object this script is attached to) is now available to be accessed from the rb variable
    }

    void Update()
    {
        isMovingHorizontal = Input.GetAxisRaw("Horizontal"); //Raw goes from 0 to 1 and 0 to -1
        //Debug.Log(isMovingHorizontal);

        PlayerLooking(isMovingHorizontal); //this function uses isMovingHorizontal as the argument it asks for

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
        if (Input.GetKey(KeyCode.E)) //not the actual Raycast just for visualization purposes
        {
            Gizmos.color = Color.red; //first define the color of the gizmo - it need to be fully opaque (1)

            if (isLookingRight == true)
                Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + interactionDistance, transform.position.y));

            if (isLookingRight == false)
                Gizmos.DrawLine(transform.position, new Vector2(transform.position.x - interactionDistance, transform.position.y)); //invert the raycast direction based on the bool variable
        }
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(isMovingHorizontal * speed, rb.velocity.y);
        //velocity is for 2D movement, since it is a Vector2. The Y axis keeps the velocity of the Rigidbody2D
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //add the float value to the Y axis
            Debug.Log("Jump");
        }
    }

    protected void PlayerLooking(float lastMovement) //returns -1, 0 or 1. the variable lastMovement only exists inside this function to save memory
    {
        if (lastMovement > 0 && isLookingRight == false)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            isLookingRight = true; //updates the variable because now it's looking to the right
        }

        if (lastMovement < 0 && isLookingRight == true)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1); //flips the scale on the X axis
            isLookingRight = false;
        }
    }

    //shoots a straight line
    void RaycastInteraction()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, interactionDistance, 7); //raycast returns the 1st object it hits. 7 is the layer to ignore casting

        if (hit.transform && hit.transform.gameObject.tag == "Item") //if the first object next to the player exists and the tag is equal to "Item", object will be destroyed
        {
            Destroy(hit.transform.gameObject);
        }
    }
    //
    void MultipleRaycastInteraction()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.right, interactionDistance, 7); //stores all objects that were hitted
        Debug.Log(hits.Length);

        foreach (RaycastHit2D hit in hits) //loop for each element in the array
        {
            if (hit.transform && hit.transform.gameObject.tag == "Item") //destroy the objects with tags and preserve the non tagged
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

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

    void CircleOverlapRaycastInteraction()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionDistance, 7);
        foreach (Collider2D hit in hits)
        {
            if (hit.transform && hit.transform.gameObject.tag == "Item")
            {
                Destroy(hit.transform.gameObject);
            }

        }
    }
}
