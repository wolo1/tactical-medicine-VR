using UnityEngine;
using Oculus.Interaction.HandGrab;
using System.Linq;
using Oculus.Interaction;

public class GlovesJoysticks : MonoBehaviour
{
    private HandGrabInteractable _interactable;

    [SerializeField] private Material latex;
    [SerializeField] private GameObject l_ovrHandPrefab;
    [SerializeField] private GameObject r_ovrHandPrefab;

    void Start()
    {
        _interactable = GetComponent<HandGrabInteractable>();
    }

    void Update()
    {
        var hand = _interactable.Interactors.FirstOrDefault<HandGrabInteractor>();

        if (hand != null && _interactable.State == InteractableState.Select)
        {
           /* // Check if the grab is from controllers (joysticks) and NOT from hand tracking
            bool isJoystickGrab = hand.Handedness == OVRPlugin.Handedness.LeftHand ||
                                  hand.Handedness == OVRPlugin.Handedness.RightHand;*/

           // if (isJoystickGrab)
            {
                //Debug.Log("Gloves grabbed using controllers: " + hand.Handedness);

                // Apply material to gloves
                l_ovrHandPrefab.GetComponent<Renderer>().material = latex;
                r_ovrHandPrefab.GetComponent<Renderer>().material = latex;

                // Mark the equipment as applied
                MedicalEquipment medicalEquipment = GetComponentInParent<MedicalEquipment>();
                if (medicalEquipment != null)
                {
                    medicalEquipment.applied = true;
                    medicalEquipment.audioSource.Play();
                }
            }
        }
    }
}
