using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPuddleAnimation : MonoBehaviour
{
 

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().localScale.y >= 30)
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}
