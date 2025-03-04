using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPuddleAnimation : MonoBehaviour
{

    [SerializeField]
    private float localScaleToStop; 



    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().localScale.y >= localScaleToStop)
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}
