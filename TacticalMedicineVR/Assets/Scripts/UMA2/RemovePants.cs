using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class RemovePants : MonoBehaviour
{
    public DynamicCharacterAvatar avatar; // Reference to your UMA character

    public bool removePantsAddUnderwear;
    // Wardrobe slot names
    public string legsWardrobeSlot; // Wardrobe slot for pants
    public string underwearRecipe = "UnderwearRecipe"; // The recipe name for underwear
    public string shortsRecipe = "*[Legs] MaleShorts1  (HumanMale )";

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
        // Remove pants and add underwear
        if (removePantsAddUnderwear)
        {
            RemovePantsAndAddUnderwear();
            removePantsAddUnderwear = false;
        }
    }

    public void RemovePantsAndAddUnderwear()
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
