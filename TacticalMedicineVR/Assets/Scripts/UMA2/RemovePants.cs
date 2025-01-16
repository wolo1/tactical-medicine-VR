using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class RemovePants : MonoBehaviour
{
    [SerializeField]
    private DynamicCharacterAvatar avatar; // Reference to your UMA character
    [SerializeField]
    private bool clothesRemoved = false;

    [SerializeField]
    private GameObject tourniquet;

    // Wardrobe slot names
    [SerializeField]
    private string legsWardrobeSlot; // Wardrobe slot for pants
    [SerializeField]
    private string underwearRecipe = "UnderwearRecipe"; // The recipe name for underwear
    [SerializeField]
    private string shortsRecipe = "*[Legs] MaleShorts1  (HumanMale )";


    [SerializeField]
    private Collider colliderScissors;

    [SerializeField]
    private Collider colliderTourniquet;


    public GameObject blood;


    void Start()
    {
        if (avatar == null)
        {
            Debug.LogError("DynamicCharacterAvatar is not assigned!");
            return;
        }

        
    }

    private void Update()
    {
    
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
                    RemovePants1();
                    medicalEquipment.audioSource.Play();
                    clothesRemoved = true;
                    colliderScissors.enabled = false;
                    colliderTourniquet.enabled = true;
                    blood.SetActive(true);
                }
                else if (medicalEquipment.type == "Tourniquet" && clothesRemoved)
                {
                    Debug.Log("TRIGGER TOURNIQUET ENTER DETECTED");
                    tourniquet.SetActive(true);
                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

    public void RemovePants1()
    {
        if (string.IsNullOrEmpty(legsWardrobeSlot))
        {
            Debug.LogWarning("Wardrobe slot is not specified.");
            return;
        }

        // Clear the Legs slot to remove pants
        avatar.ClearSlot(legsWardrobeSlot);


        //avatar.SetSlot(shortsRecipe);

        //avatar.SetSlot("Legs", "MaleShorts1");
        avatar.BuildCharacter(); //important otherwise no changes will take place
        Debug.Log("Pants removed");



        /* // Add the underwear back to the Legs slot
         if (!string.IsNullOrEmpty(underwearRecipe))
         {
             avatar.SetSlot(legsWardrobeSlot, underwearRecipe);
             Debug.Log("Underwear added back to the Legs slot.");
         }
         else
         {
             Debug.LogWarning("Underwear recipe not specified.");
         }

         // Rebuild the avatar to apply changes
         avatar.BuildCharacter();
         Debug.Log($"Pants removed and underwear added to the {legsWardrobeSlot} slot.");*/
    }
}
