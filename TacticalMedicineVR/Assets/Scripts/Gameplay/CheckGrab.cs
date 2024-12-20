
using UnityEngine;

using Oculus.Interaction.HandGrab;
using System.Linq;
using Oculus.Interaction;

public class CheckGrab : MonoBehaviour
{
    private HandGrabInteractable _interactable;
    [SerializeField]
    private GameObject backPackClosed;
    [SerializeField]
    private GameObject backPackOpen;

    [SerializeField]
    private Collider colliderBackpackClosed;

    [SerializeField]
    private Collider colliderBackpackOpen;

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


            backPackClosed.SetActive(false);
            backPackOpen.SetActive(true);
            switchCollider();

        }

    }


    void switchCollider() 
    {
        colliderBackpackClosed.enabled = false;
        colliderBackpackOpen.enabled = true;
    }
}
