using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ApplyInstructions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("PatientInstruction"))
        {
            DestroyAllInstructions();

        }
    }


    void WalkAway()
    {

    }

    void HoldHand()
    {

    }


    void DestroyAllInstructions()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("PatientInstruction"))
            {
                Destroy(child.gameObject);
            }
        }
    }
}
