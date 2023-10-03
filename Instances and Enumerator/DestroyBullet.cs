using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    //this script is attached to the bullet target
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Bullet")) //destroy the bullet everytime it collides with something
        {
            Destroy(collision.gameObject);
        }
    }
}

