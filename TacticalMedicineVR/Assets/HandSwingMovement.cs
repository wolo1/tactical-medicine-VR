using UnityEngine;
using System;
using Oculus.Interaction.Input;

public class HandSwingMovement : MonoBehaviour
{
    public Hand leftHand;
    public Hand rightHand;

    public GameObject leftHandGameObject;
    public GameObject rightHandGameObject;

    public float moveSpeed = 5.0f;
    public float swingThreshold = 0.2f;

    private Vector3 previousLeftHandPosition;
    private Vector3 previousRightHandPosition;

    void Start()
    {



        // Corrected GetComponent Usage
        leftHand = leftHandGameObject.GetComponent<Hand>();
        rightHand = rightHandGameObject.GetComponent<Hand>();

        if (leftHand == null || rightHand == null)
        {
            Debug.LogError("Hand components are missing!");
            return;
        }

        // Initialize previous hand positions
        previousLeftHandPosition = GetHandPosition(leftHandGameObject);
        previousRightHandPosition = GetHandPosition(rightHandGameObject);
    }

    void Update()
    {
        // Recheck hands in case they get reassigned or deleted
        /*if (leftHand == null || rightHand == null)
        {
           FindHandsRecursively(transform);

            if (leftHandGameObject != null) leftHand = leftHandGameObject.GetComponent<Hand>();
            if (rightHandGameObject != null) rightHand = rightHandGameObject.GetComponent<Hand>();

            if (leftHand == null || rightHand == null)
            {
                Debug.LogWarning("Hand references are missing and couldn't be found!");
                return;
            }
        }
        */

        // Get current hand positions
        Vector3 currentLeftHandPosition = GetHandPosition(leftHandGameObject);
        Vector3 currentRightHandPosition = GetHandPosition(rightHandGameObject);

        // Calculate hand swing distances
        float leftHandSwingDistance = Vector3.Distance(currentLeftHandPosition, previousLeftHandPosition);
        float rightHandSwingDistance = Vector3.Distance(currentRightHandPosition, previousRightHandPosition);

        // Calculate average swing distance
        float averageSwingDistance = (leftHandSwingDistance + rightHandSwingDistance) / 2.0f;

        // Debug logs
        Debug.Log($"Left Swing: {leftHandSwingDistance}, Right Swing: {rightHandSwingDistance}, Avg: {averageSwingDistance}");

        // Move player if swing distance exceeds the threshold
        if (averageSwingDistance > swingThreshold)
        {
            if (TryGetComponent<CharacterController>(out CharacterController controller))
            {
                controller.Move(transform.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            Debug.Log("Player moved forward");
        }

        // Update previous hand positions
        previousLeftHandPosition = currentLeftHandPosition;
        previousRightHandPosition = currentRightHandPosition;
    }

    /// <summary>
    /// Recursively searches for Hand objects tagged "Hand" within the GameObject hierarchy.
    /// Assigns the first found hand as left and the second as right.
    /// </summary>
    private void FindHandsRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag("Hand"))
            {
                if (leftHandGameObject == null)
                {
                    leftHandGameObject = child.gameObject;
                }
                else if (rightHandGameObject == null)
                {
                    rightHandGameObject = child.gameObject;
                    return; // Stop once both hands are found
                }
            }
            // Recursively search deeper
            FindHandsRecursively(child);
        }
    }

    private Vector3 GetHandPosition(GameObject handObject)
    {
        if (handObject == null) return Vector3.zero;
        return handObject.transform.position; // Fallback if skeleton is unavailable
    }
}
