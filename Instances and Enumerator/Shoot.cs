using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject instanceObject; //object to instance
    [SerializeField] Transform spawnPoint; //point in space to the object spawn

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shoot = Instantiate(instanceObject, spawnPoint.position, spawnPoint.rotation); //new object
            shoot.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000f); //getting the rigidbody from the new instantiate object
            Destroy(shoot, 2f);
        }
    }
}
