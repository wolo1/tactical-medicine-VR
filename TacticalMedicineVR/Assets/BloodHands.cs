using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodHands : MonoBehaviour
{
    [Header("Hand Tracking")]

    [SerializeField]
    private GameObject l_handMeshNode;

    [SerializeField]
    private GameObject r_handMeshNode;


    [Header("JoySticks")]

    [SerializeField]
    private GameObject l_ovrHandPrefab;

    [SerializeField]
    private GameObject r_ovrHandPrefab;


    [Header("Materials")]

    [SerializeField]
    private Material latexBloodLeft;

    [SerializeField]
    private Material latexBloodRight;

    

    public void ChangeTextureHands()
    {
        if (l_handMeshNode.activeSelf == false)
        {
            ChangeTextureJoySticks();
        }
        else
        {
            ChangeTextureActualHands();
        }

    }

    public void ChangeTextureActualHands()
    {

        l_handMeshNode.GetComponent<Renderer>().material = latexBloodLeft;
        r_handMeshNode.GetComponent<Renderer>().material = latexBloodRight;
    }


    public void ChangeTextureJoySticks()
    {

        l_ovrHandPrefab.GetComponent<Renderer>().material = latexBloodLeft;
        r_ovrHandPrefab.GetComponent<Renderer>().material = latexBloodRight;
    }

}
