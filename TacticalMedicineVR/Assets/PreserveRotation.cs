using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveRotation : MonoBehaviour
{
    private Animator animator;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float transitionTime = 0.3f; // Faster transition (0.3 seconds)
    private float elapsedTime = 0f;
    private bool isTransitioning = false;

    void Start()
    {
        animator = GetComponent<Animator>(); // Automatically get the Animator
        initialRotation = transform.rotation; // Store the initial rotation
        targetRotation = initialRotation; // Set targetRotation to initialRotation initially
    }

    void LateUpdate()
    {
        animator = GetComponent<Animator>(); // Automatically get the Animator

        if (animator && animator.GetCurrentAnimatorStateInfo(0).IsName("Take 001 Custom"))
        {
            Debug.Log("TAKE DETECTED");

            // Set the target rotation with +50 degrees on the Y-axis
            targetRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y + 50, initialRotation.eulerAngles.z);
        }
        else
        {
            // Reset back to initial rotation
            targetRotation = initialRotation;
        }

        // Smoothly interpolate rotation over time
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / transitionTime); // Normalize time (0 to 1)
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t);

        // Reset transition tracking when fully rotated
        if (t >= 1.0f)
        {
            elapsedTime = 0f;
        }
    }
}
