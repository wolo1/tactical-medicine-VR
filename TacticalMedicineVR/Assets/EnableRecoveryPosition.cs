using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRecoveryPosition : MonoBehaviour
{

    [SerializeField]
    private GameObject blanket;

    [SerializeField]
    private Animator animator;


    public GameObject avatar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void LateUpdate()
    {
        //TODO: if the sphere was pulled towards negative X or positive y, then start animation


    }

    void startAnimation()
    {
        animator.SetTrigger("Lying");

    }
}
