using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Texture2D maleJeansCut;
    public Texture2D maleJeansTourniquet;
    public GameObject maleClothes;
    private bool clothesRemoved = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = collision.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Scissors")
                {
                    maleClothes.GetComponent<Renderer>().material.SetTexture("_BaseMap", maleJeansCut);
                    medicalEquipment.audioSource.Play();
                    clothesRemoved = true;
                }
                else if (medicalEquipment.type == "Tourniquet" && clothesRemoved)
                {
                    maleClothes.GetComponent<Renderer>().material.SetTexture("_BaseMap", maleJeansTourniquet);
                }

            }
            else
            {
                Debug.Log("The collided object is not a MedicalEqupment");
            }
        }
    }
}
