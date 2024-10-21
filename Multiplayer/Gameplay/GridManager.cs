using System.Collections.Generic;
using UnityEngine;

public class PrefabMover : MonoBehaviour
{
    public List<GameObject> prefabs; // List to hold prefab references
    public Transform[] slots; // Array of slots where the prefabs will be placed

    public List<GameObject> instantiatedPrefabs = new List<GameObject>(); // To track instantiated prefabs

    void Start()
    {
        // Instantiate the prefabs at the start
        for (int i = 0; i < prefabs.Count && i < slots.Length; i++)
        {
            GameObject instantiatedPrefab = Instantiate(prefabs[i], slots[i].position, Quaternion.identity, slots[i]);
            instantiatedPrefabs.Add(instantiatedPrefab); // Keep track of instantiated prefabs
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MovePrefabs();
        }
    }

    void MovePrefabs()
    {
        if (instantiatedPrefabs.Count == 0 || slots.Length == 0) return;

        // Store the last prefab
        GameObject lastPrefab = instantiatedPrefabs[instantiatedPrefabs.Count - 1];

        // Shift prefabs one position forward
        for (int i = instantiatedPrefabs.Count - 1; i > 0; i--)
        {
            // Move each prefab to the next slot
            instantiatedPrefabs[i].transform.position = slots[i].position;
            instantiatedPrefabs[i].transform.SetParent(slots[i]);
            instantiatedPrefabs[i] = instantiatedPrefabs[i - 1]; // Update the reference
        }

        // Move the first prefab to the last slot
        instantiatedPrefabs[0].transform.position = slots[0].position;
        instantiatedPrefabs[0].transform.SetParent(slots[0]);
        instantiatedPrefabs[0] = lastPrefab; // Update reference for the last prefab
        Instantiate(lastPrefab, slots[slots.Length - 1].position, Quaternion.identity, slots[slots.Length - 1]);
    }
}
