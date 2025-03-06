using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class UseTourniquet : MonoBehaviour
{
    [SerializeField] private DynamicCharacterAvatar avatar;
    [SerializeField] private UMATextRecipe tourniquetUma;
    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject windglass; // Ensure this is assigned in the Inspector
    [SerializeField] private GameObject tourniquetGameObject;
    [SerializeField] private ParticleSystem bloodStream;
    [SerializeField] private GameObject Instructions;


    [SerializeField]
    private GameObject bloodPuddle;

    public bool TourniquetJeansApplied { get; private set; } = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("MedicalEquipment") && TourniquetJeansApplied == false)
        {
            var medicalEquipment = other.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Tourniquet")
                {
                    Debug.Log("TRIGGER Tourniquet ENTER DETECTED");
                    Tourniquet();
                    sphere.SetActive(true);
                    medicalEquipment.applied = true;
                    medicalEquipment.audioSource.Play();
                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

    void Tourniquet()
    {
        // Activate the tourniquet
        tourniquetGameObject.SetActive(true);

        // Start rotating the windlass
        StartCoroutine(RotateWindlass());

        // Equip tourniquet to the avatar
        EquipTourniquet();
    }

    public void EquipTourniquet()
    {
        avatar.SetSlot(tourniquetUma);
        avatar.BuildCharacter();


        Instructions.SetActive(true);
        TourniquetJeansApplied = true;
        bloodPuddle.GetComponent<Animator>().enabled = false;
        bloodStream.Stop();

    }

    IEnumerator RotateWindlass()
    {
        float duration = 2f; // Time to complete 2 full rotations (1 second)
        float rotationSpeed = 360f; // Degrees per second (360 * 2)
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            windglass.transform.Rotate(0, rotationAmount, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure it stops at exactly 720 degrees (2 full turns)
        windglass.transform.rotation = Quaternion.Euler(
            windglass.transform.rotation.eulerAngles.x,
            windglass.transform.rotation.eulerAngles.y + 720f,
            windglass.transform.rotation.eulerAngles.z
        );

        EquipTourniquet();
        tourniquetGameObject.SetActive(false);

    }
}
