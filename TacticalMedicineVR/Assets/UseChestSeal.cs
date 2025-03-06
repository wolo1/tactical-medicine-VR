using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class UseChestSeal : MonoBehaviour
{
    [SerializeField]
    private DynamicCharacterAvatar avatar; // Reference to your UMA character


    [SerializeField]
    private UMATextRecipe chestSealOverlay;


    [SerializeField]
    private GameObject Instructions;


    [SerializeField]
    private Collider colliderChestSeal;

    [SerializeField]
    private GameObject sphere;







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
                if (medicalEquipment.type == "Chest Seal")
                {
                    Debug.Log("CHEST SEAL ENTER DETECTED");
                    //medicalEquipment.audioSource.Play();

                    colliderChestSeal.enabled = false;
                    //blood.SetActive(true);
                    //bleeding.Play();
                    sphere.SetActive(true);
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
        avatar.SetSlot(chestSealOverlay);
        avatar.BuildCharacter();

        Instructions.SetActive(true);
    }
}
