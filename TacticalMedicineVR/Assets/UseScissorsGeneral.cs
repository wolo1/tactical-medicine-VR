using System.Collections;
using System.Collections.Generic;
using UMA.CharacterSystem;
using UMA;
using UnityEngine;

public class UseScissorsGeneral : MonoBehaviour
{
    [SerializeField]
    private DynamicCharacterAvatar avatar;

    [SerializeField]
    private string wardrobeSlotToRemove;

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
                    Debug.Log("SCISSORS");
                    medicalEquipment.applied = true;
                    RemoveCloth(); 

                }
                else
                {
                    Debug.Log("The triggered object is not a MedicalEquipment");
                }
            }
        }
    }

     void RemoveCloth()
    {
        if (string.IsNullOrEmpty(wardrobeSlotToRemove))
        {
            Debug.LogWarning("Wardrobe slot is not specified.");
            return;
        }

        // Clear the Legs slot to remove pants
        avatar.ClearSlot(wardrobeSlotToRemove);

        avatar.BuildCharacter(); 
        Debug.Log("Cloth removed");
    }


}
