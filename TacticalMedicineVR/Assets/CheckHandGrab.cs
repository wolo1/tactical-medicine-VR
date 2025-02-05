using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;
using System.Linq;
using Oculus.Interaction;


public class CheckHandGrab : MonoBehaviour
{
    private HandGrabInteractable _interactable;
  
    

    void Start()
    {
        _interactable = gameObject.GetComponent<HandGrabInteractable>();
    }

    void Update()
    {
        var hand = _interactable.Interactors.FirstOrDefault<HandGrabInteractor>();
        if (hand != null && _interactable.State == InteractableState.Select)
        {
            Debug.Log("Connected to hand " + hand.gameObject.tag);

            GetComponentInParent<RemoveFromAllParents>().DetachFromAllParents();




        }

    }


}
