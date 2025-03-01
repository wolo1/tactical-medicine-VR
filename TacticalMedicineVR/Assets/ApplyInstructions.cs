using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ApplyInstructions : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public float rotationSpeed = 2.0f; // Speed of smooth rotation

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("PatientInstruction"))
        {
            if (other.gameObject.name == "WalkAway")
            {
                StartCoroutine(WalkAwaySequence());
            }
            else if (other.gameObject.name == "HoldHand")
            {
                StartCoroutine(HoldHand());
            }
            else if (other.gameObject.name == "DontDisturb")
            {
                // Handle Don't Disturb case if needed
            }
            DestroyAllInstructions();
        }
    }

    IEnumerator WalkAwaySequence()
    {
        animator.SetLayerWeight(3, 1);
        yield return StartCoroutine(SmoothRotate(-100)); // Rotate -100° on Y-axis
        yield return new WaitForSeconds(0.2f); // Wait for 1-2 steps
        yield return StartCoroutine(SmoothRotate(-100)); // Rotate another -90° on Y-axis
    }

    IEnumerator SmoothRotate(float angle)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + angle, 0);
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * rotationSpeed; // Adjust speed here
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure precise final rotation
    }

    IEnumerator HoldHand()
    {
        animator.SetLayerWeight(2, 1);
        animator.SetTrigger("Crouch");
        yield return StartCoroutine(SmoothRotate(-20)); // Rotate -100° on Y-axis

    }

    void DestroyAllInstructions()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("PatientInstruction"))
            {
                Destroy(child.gameObject);
            }
        }
    }
}
