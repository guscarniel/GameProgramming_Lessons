using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject instanceObject; //object to instance (prefab)
    [SerializeField] Transform spawnPoint; //point in space for the object spawn

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shoot = Instantiate(instanceObject, spawnPoint.position, spawnPoint.rotation); //new gameobject variable
            shoot.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000f); //getting the rigidbody from the new instantiated object
            Destroy(shoot, 2f); //destroy with delay
        }
    }
}
