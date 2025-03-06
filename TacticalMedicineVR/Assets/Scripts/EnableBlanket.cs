using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class EnableBlanket : MonoBehaviour
{
    [SerializeField]
    private GameObject blanket;

    [SerializeField]
    private UMATextRecipe blanketRecipe;


    [SerializeField]
    private DynamicCharacterAvatar avatar;

    


 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED ENABLEBLANKET");
        if (other.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = other.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Blanket")
                {
                    Debug.Log("TRIGGER BLANKET ENTER DETECTED");
                    blanket.SetActive(true);
                    if (blanketRecipe != null)
                                    EquipBlanket();
                    medicalEquipment.applied = true;

                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

    public void EquipBlanket()
    {
        avatar.SetSlot(blanketRecipe);
        avatar.BuildCharacter();
    }
}
