using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet") //destroy everytime a bullet collides with something
        {
            Destroy(collision.gameObject);
        }
    }
}

