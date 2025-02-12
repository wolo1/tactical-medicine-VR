using System.Collections;
using System.Collections.Generic;
using UMA.CharacterSystem;
using UMA;
using UnityEngine;

public class UseBandageChild : MonoBehaviour
{
    [SerializeField]
    private DynamicCharacterAvatar avatar;

    [SerializeField]
    private UMATextRecipe bandageRecipe;

    [SerializeField]
    private UMATextRecipe israeliBandageRecipe;





    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = other.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Bandage")
                {
                    Debug.Log("TRIGGER BANDAGE ENTER DETECTED");
                    EquipBandage();
                    medicalEquipment.applied = true;
                }

                else if (medicalEquipment.type == "Israeli Bandage")
                {
                    Debug.Log("TRIGGER ISRAELI BANDAGE ENTER DETECTED");
                    EquipIsraeli();
                    medicalEquipment.applied = true;
                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

    public void EquipBandage()
    {
        avatar.SetSlot(bandageRecipe);
        avatar.BuildCharacter();
    }

    public void EquipIsraeli()
    {
        avatar.SetSlot(israeliBandageRecipe);
        avatar.BuildCharacter();
    }
}
