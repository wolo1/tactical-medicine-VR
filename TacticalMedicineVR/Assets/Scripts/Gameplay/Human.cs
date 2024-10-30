using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Texture2D clothesCut;
    public Texture2D medicineApplied;
    public GameObject clothes;
    private bool clothesRemoved = false;

    public GameObject bleeding;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION DETECTED");
        if (collision.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = collision.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Scissors")
                {
                    clothes.GetComponent<Renderer>().material.SetTexture("_BaseMap", clothesCut);
                    medicalEquipment.audioSource.Play();
                    clothesRemoved = true;
                }
                else if (medicalEquipment.type == "Tourniquet" && clothesRemoved)
                {
                    clothes.GetComponent<Renderer>().material.SetTexture("_BaseMap", medicineApplied);
                    medicalEquipment.audioSource.Play();
                    StopBleeding();
                }
            }
            else
            {
                Debug.Log("The collided object is not a MedicalEquipment");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = other.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Scissors")
                {
                    clothes.GetComponent<Renderer>().material.SetTexture("_BaseMap", clothesCut);
                    medicalEquipment.audioSource.Play();
                    clothesRemoved = true;
                }
                else if (medicalEquipment.type == "Tourniquet" && clothesRemoved)
                {
                    clothes.GetComponent<Renderer>().material.SetTexture("_BaseMap", medicineApplied);
                    medicalEquipment.audioSource.Play();
                    StopBleeding();
                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

    private void StopBleeding()
    {
        Debug.Log("StopBleeding method called.");

        // Disable the Animator on the bleeding GameObject
        var animator = bleeding.GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = false;
            Debug.Log("Bleeding animation stopped by disabling the Animator.");
        }
        else
        {
            Debug.Log("No Animator component found on the bleeding GameObject.");
        }

        // Disable the Animator on the current GameObject if it exists
        var currentAnimator = GetComponent<Animator>();
        if (currentAnimator != null)
        {
            currentAnimator.enabled = false;
            Debug.Log("Animator on the current GameObject disabled.");
        }
        else
        {
            Debug.Log("No Animator component found on the current GameObject.");
        }
    }
}
