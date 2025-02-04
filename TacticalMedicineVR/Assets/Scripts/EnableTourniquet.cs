using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTourniquet : MonoBehaviour
{
    [SerializeField]
    private GameObject tourniquet;

 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = other.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Tourniquet")
                {
                    Debug.Log("TRIGGER TOURNIQUET ENTER DETECTED");
                    tourniquet.SetActive(true);
                    medicalEquipment.applied = true;
                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

}
