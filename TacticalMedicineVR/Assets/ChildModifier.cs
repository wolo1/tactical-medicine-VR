using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class ChildModifier : MonoBehaviour
{
    [SerializeField]
    private DynamicCharacterAvatar avatar;

    void Start()
    {
        if (avatar == null)
        {
            Debug.LogError("Avatar is not assigned!");
            return;
        }

        // Ensure the DNA is properly loaded
        avatar.CharacterCreated.AddListener(OnCharacterCreated);
    }

    private void OnCharacterCreated(UMAData data)
    {
        ModifyBaseRecipe();
    }

    private void ModifyBaseRecipe()
    {
        // Get the DNA dictionary
        Dictionary<string, DnaSetter> dna = avatar.GetDNA();

        if (dna == null)
        {
            Debug.LogError("DNA data not found!");
            return;
        }

        // Modify some DNA values correctly
        if (dna.ContainsKey("headSize")) dna["headSize"].Value = 0.7f;
        if (dna.ContainsKey("headWidth")) dna["headWidth"].Value = 0.8f;
        if (dna.ContainsKey("noseSize")) dna["noseSize"].Value = 0.5f;

        // Apply the changes
        avatar.ForceUpdate(true, true, true);
    }
}
