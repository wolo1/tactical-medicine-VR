using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBlanket : MonoBehaviour
{
    [SerializeField]
    private GameObject blanket;



    // Start is called before the first frame update


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
                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }
}
