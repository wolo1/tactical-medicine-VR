using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTrainee : MonoBehaviour
{
    public Vector3 globalPosition; // Assign the global position from the inspector

    // Start is called before the first frame update
    void Start()
    {
        // Initially do nothing
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the number 1 key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1)) // KeyCode.Alpha1 corresponds to the number 1 key
        {
            // Place the current GameObject at the assigned global position
            transform.SetPositionAndRotation(globalPosition, Quaternion.identity);
        }
    }
}
