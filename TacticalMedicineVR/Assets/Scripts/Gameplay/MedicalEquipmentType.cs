using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MedicalEquipment : MonoBehaviour
{
    [SerializeField]
    public string type; // Assign this in the inspector for each medical object

    public AudioSource audioSource;

    public bool applied = false;
                         
}
