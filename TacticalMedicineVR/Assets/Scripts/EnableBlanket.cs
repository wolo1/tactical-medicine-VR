using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBlanket : MonoBehaviour
{
    [SerializeField]
    private GameObject blanket;

    [SerializeField]
    private Animator animator;


    public GameObject avatar;

    // Start is called before the first frame update
    void Start()
    {
        animator = avatar.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED ENABLEBLANKET");
        if (other.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = other.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Blanket")
                {
                    Debug.Log("TRIGGER BLANKET ENTER DETECTED");
                    blanket.SetActive(true);
                    animator.SetTrigger("LyingIdle");
                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }
}
