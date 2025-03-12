using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnAllObjectsAfterApplied : MonoBehaviour
{
    private Dictionary<Transform, Vector3> initialLocalPositions;
    private Dictionary<Transform, Quaternion> initialLocalRotations;

    // Start is called before the first frame update
    void Start()
    {
        initialLocalPositions = new Dictionary<Transform, Vector3>();
        initialLocalRotations = new Dictionary<Transform, Quaternion>();

        // Create a list of all child objects and store the initial local position and rotation of each one
        foreach (Transform child in transform)
        {
            initialLocalPositions[child] = child.localPosition;
            initialLocalRotations[child] = child.localRotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously check each child object
        foreach (Transform child in transform)
        {
            // Check if the child object has the script MedicalEquipment
            MedicalEquipment medicalEquipment = child.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null && medicalEquipment.applied)
            {
                // Start a coroutine to return the object to its initial position and rotation
                StartCoroutine(ReturnToInitialPosition(child, medicalEquipment));
            }
        }
    }

    private IEnumerator ReturnToInitialPosition(Transform child, MedicalEquipment medicalEquipment)
    {
        // Return the object to the initial local position and rotation relative to the parent
        child.localPosition = initialLocalPositions[child];
        child.localRotation = initialLocalRotations[child];

        // Find and disable the HandGrabInteraction child object
        Transform handGrabChild = child.Find("ISDK_HandGrabInteraction");
        if (handGrabChild != null)
        {
            handGrabChild.gameObject.SetActive(false);
        }

        // Wait for 1 second before setting applied back to false
        yield return new WaitForSeconds(1.0f);

        // Re-enable the HandGrabInteraction child object
        if (handGrabChild != null)
        {
            handGrabChild.gameObject.SetActive(true);
        }

        medicalEquipment.applied = false;
    }
}
