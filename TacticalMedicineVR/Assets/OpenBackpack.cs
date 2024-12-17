using UnityEngine;
using System;

public class OpenBackpack : MonoBehaviour
{
    // Event to notify when an object is grabbed while in collision
    public event Action OnGrabWhileColliding;

    private bool isCollidingWithHand = false;  // Tracks collision state
    public OVRGrabbable grabbableComponent;   // Reference to OVRGrabbable component

    void Start()
    {
        // Get the OVRGrabbable component
        grabbableComponent = GetComponent<OVRGrabbable>();

        if (grabbableComponent == null)
        {
            Debug.LogError("No OVRGrabbable component found. Add it to the object.");
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("VRHand")) // Detect collision with the VR Hand
        {
            isCollidingWithHand = true;
            Debug.Log("Collision with VR Hand detected.");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("VRHand"))
        {
            isCollidingWithHand = false;
            Debug.Log("VR Hand exited collision.");
        }
    }

    void Update()
    {
        // Fire the event only once when the object is grabbed during collision
        if (isCollidingWithHand && grabbableComponent.isGrabbed)
        {
            OnGrabWhileColliding?.Invoke();
            Debug.Log("Event Triggered: Object grabbed while colliding.");

            // Prevent repeated event triggers
            isCollidingWithHand = false;
        }
    }
}
