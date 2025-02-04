using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class UseScissorsGirl : MonoBehaviour
{
    [SerializeField]
    private DynamicCharacterAvatar avatar; // Reference to your UMA character
    [SerializeField]
    private bool clothesRemoved = false;



    // Wardrobe slot names
    [SerializeField]
    private string chestWardrobeSlot;



    [SerializeField]
    private Collider colliderScissors;

    [SerializeField]
    private Collider colliderCleaning;


    [SerializeField]
    private ParticleSystem bleeding;


    [SerializeField]
    private GameObject bloodPuddle;



    void Start()
    {
        if (avatar == null)
        {
            Debug.LogError("DynamicCharacterAvatar is not assigned!");
            return;
        }


    }

    private void LateUpdate()
    {
        if (clothesRemoved && bloodPuddle.transform.localScale.y >= 20)
        {
            bloodPuddle.GetComponent<Animator>().enabled = false;

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
                if (medicalEquipment.type == "Scissors")
                {
                    CutPants();
                    medicalEquipment.audioSource.Play();
                    clothesRemoved = true;
                    colliderScissors.enabled = false;
                    colliderCleaning.enabled = true;
                    //blood.SetActive(true);
                    //bleeding.Play();
                    medicalEquipment.applied = true;
                }

            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

    public void CutPants()
    {
        if (string.IsNullOrEmpty(chestWardrobeSlot))
        {
            Debug.LogWarning("Wardrobe slot is not specified.");
            return;
        }

        // Clear the Legs slot to remove pants
        avatar.ClearSlot(chestWardrobeSlot);

        avatar.BuildCharacter(); //important otherwise no changes will take place
        Debug.Log("Pants removed");

    }
}
