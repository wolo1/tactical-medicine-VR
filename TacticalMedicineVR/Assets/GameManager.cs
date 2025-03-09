using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA.CharacterSystem;
using UMA;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private DynamicCharacterAvatar patientOne;
    [SerializeField]
    private DynamicCharacterAvatar patientWoman;
    [SerializeField]
    private DynamicCharacterAvatar patientChild;

    private Dictionary<string, bool> patientOneSolution = new Dictionary<string, bool>();

    [SerializeField]
    private float time = 10f; // Time in seconds before calling verifyWardrobe()

    private bool hasCheckedRecipes = false; // Ensures verification runs only once

    // Start is called before the first frame update
    void Start()
    {
        // Initialize dictionary with all needed items, marked as false
        patientOneSolution.Add("Tourniquet", false);
        patientOneSolution.Add("Israeli", false);
        patientOneSolution.Add("Recovery Position", false);
        patientOneSolution.Add("Blanket", false);
        patientOneSolution.Add("Instruction", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasCheckedRecipes)
        {
            time -= Time.deltaTime; // Countdown timer

            if (time <= 0)
            {
                Debug.Log("Timer ended, calling VerifyWardrobe()");
                VerifyWardrobe(patientOne, patientOneSolution);
            }
        }
    }

    void VerifyWardrobe(DynamicCharacterAvatar patient, Dictionary<string, bool> patientSolution)
    {
        // ✅ Ensure function runs only once
        hasCheckedRecipes = true;

        if (patient == null)
        {
            Debug.LogError("Patient is NULL! Make sure the avatar is assigned.");
            return;
        }

        if (patient.WardrobeRecipes == null || patient.WardrobeRecipes.Count == 0)
        {
            Debug.LogWarning("WardrobeRecipes is empty!");
            return;
        }

        // ✅ Iterate through wardrobe recipes and match with dictionary keys
        foreach (var entry in patient.WardrobeRecipes)
        {
            string recipeName = entry.Value.name.ToLower(); // Convert to lowercase for case-insensitive matching

            foreach (var key in patientSolution.Keys)
            {
                if (recipeName.Contains(key.ToLower())) // Check if recipe name contains solution keyword
                {
                    patientSolution[key] = true; // Mark item as found
                    Debug.Log($"Matched: '{recipeName}' contains '{key}'");
                }
            }
        }

        // ✅ Print final results only once
        Debug.Log("Final solution check:");
        foreach (var item in patientSolution)
        {
            Debug.Log($"Item: {item.Key}, Found: {item.Value}");
        }
    }
}
