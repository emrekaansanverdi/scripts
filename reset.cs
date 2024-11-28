using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    // List to store all the objects you want to reset
    private List<GameObject> objectsToReset = new List<GameObject>();

    // Dictionary to store the initial positions and rotations of the objects
    private Dictionary<GameObject, Vector3> initialPositions = new Dictionary<GameObject, Vector3>();
    private Dictionary<GameObject, Quaternion> initialRotations = new Dictionary<GameObject, Quaternion>();

    // Dictionary to store the rigidbodies of the objects, if they have any
    private Dictionary<GameObject, Rigidbody> rigidbodies = new Dictionary<GameObject, Rigidbody>();

    // Start is called before the first frame update
    void Start()
    {
        // Find all objects with a specific tag (e.g., "reset")
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("reset");

        foreach (GameObject obj in allObjects)
        {
            if (obj != null)
            {
                objectsToReset.Add(obj);
                initialPositions.Add(obj, obj.transform.position);    // Store their initial positions
                initialRotations.Add(obj, obj.transform.rotation);    // Store their initial rotations

                // Check if the object has a Rigidbody and store it if it does
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rigidbodies.Add(obj, rb);
                }
            }
        }
    }

    // Function to reset all objects to their original positions and rotations
    public void ResetObjects()
    {
        foreach (GameObject obj in objectsToReset)
        {
            if (obj != null && initialPositions.ContainsKey(obj))
            {
                // Reset position and rotation
                obj.transform.position = initialPositions[obj];
                obj.transform.rotation = initialRotations[obj];

                // If the object has a Rigidbody, reset velocity and stop movement
                if (rigidbodies.ContainsKey(obj))
                {
                    Rigidbody rb = rigidbodies[obj];
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;

                    // Optionally make the Rigidbody kinematic to stop it from being affected by physics
                    rb.isKinematic = true;
                }
            }
        }
    }
}
