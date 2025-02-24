using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodHands : MonoBehaviour
{

    public GameObject l_handMeshNode;
    [SerializeField]

    public GameObject r_handMeshNode;
    [SerializeField]

    private Material latexBloodLeft;
    [SerializeField]


    private Material latexBloodRight;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        //ChangeTextureHands();
    }


    public void ChangeTextureHands()
    {

        l_handMeshNode.GetComponent<Renderer>().material = latexBloodLeft;
        r_handMeshNode.GetComponent<Renderer>().material = latexBloodRight;
    }

}
