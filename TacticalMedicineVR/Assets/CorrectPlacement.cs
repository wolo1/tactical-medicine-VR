using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPlacement : MonoBehaviour
{
    // The target GameObject to place the current GameObject at
    public GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the targetObject is assigned in the inspector
        if (targetObject != null)
        {
            // Move the current GameObject to the target's position and rotation
            transform.position = targetObject.transform.position;
            transform.rotation = targetObject.transform.rotation;
        }
        else
        {
            Debug.LogError("Target Object is not assigned in the inspector!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: Add logic here if you want to continuously update the position and rotation
    }
}
