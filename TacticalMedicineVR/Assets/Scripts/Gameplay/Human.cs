using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Texture2D maleJeansCut;
    public Texture2D maleJeansTourniquet;
    public GameObject maleClothes;
    private bool clothesRemoved = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MedicalEquipment"))
        {
            var equipmentType = collision.gameObject.GetComponent<MedicalEquipmentType>();
            if (equipmentType != null)
            {
                if (equipmentType.type == "Scissors")
                {
                    maleClothes.GetComponent<Renderer>().material.SetTexture("_BaseMap", maleJeansCut);
                    clothesRemoved = true;
                }
                else if (equipmentType.type == "Tourniquet" && clothesRemoved)
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
