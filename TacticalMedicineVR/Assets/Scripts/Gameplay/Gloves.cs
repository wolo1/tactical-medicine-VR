using UnityEngine;

using Oculus.Interaction.HandGrab;
using System.Linq;
using Oculus.Interaction;

public class Gloves : MonoBehaviour
{
 
        private HandGrabInteractable _interactable;
        [SerializeField]

        private Material latex;
        [SerializeField]

        private GameObject l_handMeshNode;
        [SerializeField]

        private GameObject r_handMeshNode;
        [SerializeField]



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


            l_handMeshNode.GetComponent<Renderer>().material = latex;
            r_handMeshNode.GetComponent<Renderer>().material = latex;

            }

        }


}
