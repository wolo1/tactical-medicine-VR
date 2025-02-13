using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodHands : MonoBehaviour
{

    public GameObject l_handMeshNode;
    [SerializeField]

    public GameObject r_handMeshNode;
    [SerializeField]

    private Material latexBlood;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        ChangeTextureHands();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }


    public void ChangeTextureHands()
    {

        l_handMeshNode.GetComponent<Renderer>().material = latexBlood;
        r_handMeshNode.GetComponent<Renderer>().material = latexBlood;
    }

}
