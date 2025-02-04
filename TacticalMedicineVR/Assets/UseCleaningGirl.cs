using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class UseCleaningGirl : MonoBehaviour
{
    [SerializeField]
    private DynamicCharacterAvatar avatar; // Reference to your UMA character
 

    [SerializeField]
    private UMATextRecipe stomachCleanOverlay;

    // Wardrobe slot names
    [SerializeField]
    private string chestWardrobeSlot;



    [SerializeField]
    private Collider colliderChestSeal;

    [SerializeField]
    private Collider colliderCleaning;


    




    void Start()
    {
        if (avatar == null)
        {
            Debug.LogError("DynamicCharacterAvatar is not assigned!");
            return;
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
                if (medicalEquipment.type == "Gauze Swap")
                {
                    Debug.Log("GAUZE SWAP ENTER DETECTED");
                    //medicalEquipment.audioSource.Play();
               
                    colliderCleaning.enabled = false;
                    colliderChestSeal.enabled = true;
                    //blood.SetActive(true);
                    //bleeding.Play();
                    medicalEquipment.applied = true;
                    Equip();
                }

            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

    public void Equip()
    {
        avatar.SetSlot(stomachCleanOverlay);
        avatar.BuildCharacter();
    }
}
