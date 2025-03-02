using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA.CharacterSystem;
using UMA;

public class UseTeddyBear : MonoBehaviour
{
    [SerializeField]
    private DynamicCharacterAvatar avatar;

    [SerializeField]
    private UMATextRecipe teddyBearRecipe;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = other.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "TeddyBear")
                {
                    Debug.Log("TRIGGER TEDDYBEAR ENTER DETECTED");
                    EquipTeddyBear();
                    medicalEquipment.applied = true;
                }

            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

    public void EquipTeddyBear()
    {
        avatar.SetSlot(teddyBearRecipe);
        avatar.BuildCharacter();
    }
}
