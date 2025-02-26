using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNextStep : MonoBehaviour
{
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
                    Debug.Log("TRIGGER Tourniquet ENTER DETECTED");
                    gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }
}
