using UnityEngine;
using System.Collections;

public class NPCMover : MonoBehaviour
{
    public float moveDistance = 5f;   // Distance to move
    public float moveSpeed = 2f;      // Speed of movement
    public float rotationAngle = 90f; // Angle to rotate on Y-axis
    public float rotationSpeed = 200f; // Rotation speed
    public Animator animator;         // Optional: Assign NPC's Animator

    private Vector3 startPos;
    private bool isMoving = false;

    void Start()
    {
        startPos = transform.position;
        StartCoroutine(RotateThenMove());
    }

    IEnumerator RotateThenMove()
    {
        isMoving = true;

        // Calculate target rotation
        Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + rotationAngle, 0);

        // Play animation if available
        if (animator != null)
        {
            animator.SetFloat("Speed", 0.5f); // Play rotation animation if any
        }

        // Rotate first
        while (Quaternion.Angle(transform.rotation, targetRotation) > 1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        // Reset animation speed (if there's a specific rotation animation)
        if (animator != null)
        {
            animator.SetFloat("Speed", 1f); // Start walking animation
        }

        // Calculate target position after rotation
        Vector3 targetPos = transform.position + transform.forward * moveDistance;

        // Move forward after rotation
        while (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Stop animation once movement is complete
        if (animator != null)
        {
            animator.SetFloat("Speed", 0f);
        }

        isMoving = false;
        animator.SetTrigger("Guarding");
    }
}
