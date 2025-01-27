using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class SecureTourniquet : MonoBehaviour
{
    [SerializeField]
    private GameObject windlass;

    [SerializeField]
    private DynamicCharacterAvatar avatar;

    [SerializeField]
    private UMATextRecipe tourniquetRecipe;

    [SerializeField]
    private Collider colliderIsraeli;

    [SerializeField]
    private ParticleSystem arterialBleeding;

    [SerializeField]
    private GameObject tourniquet;

    [SerializeField]
    private float scaleStep = 0.1f;

    private float previousWindlassRotationZ;
    private float totalRotationZ;
    private float scaleRotationTracker;

    private void Start()
    {
        previousWindlassRotationZ = windlass.transform.localRotation.eulerAngles.z;
        totalRotationZ = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float currentWindlassRotationZ = windlass.transform.localRotation.eulerAngles.z;
        float rotationDifferenceTotal = Mathf.DeltaAngle(previousWindlassRotationZ, currentWindlassRotationZ);
        float rotationDifference = (previousWindlassRotationZ - currentWindlassRotationZ);

        // Accumulate the total rotation difference
        totalRotationZ += rotationDifferenceTotal;
        scaleRotationTracker += rotationDifference;

        // Check if the windlass rotation has changed by 90 degrees
        if (Mathf.Abs(rotationDifference) >= 35f)
        {
            Debug.Log("Windlass rotation changed: " + rotationDifference);
            tourniquet.transform.localScale *= (1f - scaleStep);
            AdjustParticleEffect();

            // Update the previous rotation to the current one
            //previousWindlassRotationZ = currentWindlassRotationZ;

            // Reset the scale rotation tracker
            scaleRotationTracker = 0f;
        }

        // Check if the total rotation has reached 720 degrees in either direction
        if (Mathf.Abs(totalRotationZ) >= 400)
        {
            EquipTourniquet();
            // Reset the total rotation to prevent multiple triggers
            totalRotationZ = 0f;
        }

        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            colliderIsraeli.enabled = true;
            EquipTourniquet();
        }

        // Update the previous rotation to the current one every frame
        previousWindlassRotationZ = currentWindlassRotationZ;
    }

    private void AdjustParticleEffect()
    {
        var emission = arterialBleeding.emission;
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(emission.rateOverTime.constant * (1f - scaleStep));
    }

    public void EquipTourniquet()
    {
        avatar.SetSlot(tourniquetRecipe);
        avatar.BuildCharacter();
        tourniquet.SetActive(false);
    }
}
