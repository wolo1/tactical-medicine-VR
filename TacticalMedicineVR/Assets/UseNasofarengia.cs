using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;


public class UseNasofarengia : MonoBehaviour
{

    [SerializeField]
    private DynamicCharacterAvatar avatar;

    [SerializeField]
    private UMATextRecipe nasofarengiaRecipe;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = other.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Nasofarengia")
                {
                    Debug.Log("TRIGGER NASOFARENGIA ENTER DETECTED");
                    EquipNasofarengia();
                    medicalEquipment.applied = true;
                }

      
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }


    public void EquipNasofarengia()
    {
        avatar.SetSlot(nasofarengiaRecipe);
        avatar.BuildCharacter();
    }
}
