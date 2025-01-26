using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;


public class UseIsraeli : MonoBehaviour
{

    [SerializeField]
    private DynamicCharacterAvatar avatar;

    [SerializeField]
    private UMATextRecipe israeliRecipe;

    [SerializeField]
    private Collider colliderBlanket;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = other.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Israeli Bandage")
                {
                    Debug.Log("TRIGGER ISRAELI ENTER DETECTED");
                    EquipTourniquet();
                    colliderBlanket.enabled = true;
                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

    public void EquipTourniquet()
    {
        avatar.SetSlot(israeliRecipe);
        avatar.BuildCharacter();
    }
}
