using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class UseScissors : MonoBehaviour
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
    private Collider colliderScissors;

    [SerializeField]
    private Collider colliderTourniquet;

    [SerializeField]
    private Collider colliderIsraeli;


    [SerializeField]
    private ParticleSystem arterialBleeding;


    [SerializeField]
    private GameObject bloodPuddle;

    private BloodHands bloodHands;

    [SerializeField]
    private GameObject useTourniquetOverJeans;

    [SerializeField]
    private bool tourniquetJeansApplied;

    [SerializeField] 
    private UMATextRecipe tourniquetUma;

    void Start()
    {
        if (avatar == null)
        {
            Debug.LogError("DynamicCharacterAvatar is not assigned!");
            return;
        }

        bloodHands = GetComponent<BloodHands>();

        
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
                    tourniquetJeansApplied = useTourniquetOverJeans.GetComponent<UseTourniquet>().TourniquetJeansApplied;

                    CutPants();
                    medicalEquipment.audioSource.Play();
                    clothesRemoved = true;
                    colliderScissors.enabled = false;

                    if (tourniquetJeansApplied == true)
                    {
                        colliderIsraeli.enabled = true;
                        ReplaceTourniquet();
                    }
                    else
                    {
                        colliderTourniquet.enabled = true;
                    }    
                    
                    //blood.SetActive(true);
                    medicalEquipment.applied = true;
                    bloodHands.ChangeTextureHands();
                    useTourniquetOverJeans.SetActive(false);
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
        if (string.IsNullOrEmpty(legsWardrobeSlot))
        {
            Debug.LogWarning("Wardrobe slot is not specified.");
            return;
        }

        // Clear the Legs slot to remove pants
        avatar.ClearSlot(legsWardrobeSlot);
    
        avatar.BuildCharacter(); //important otherwise no changes will take place
        Debug.Log("Pants removed");

    }



    void ReplaceTourniquet()
    {
        avatar.ClearSlot("Arms");
        avatar.SetSlot(tourniquetUma);
        avatar.BuildCharacter();
    }
}
