using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRecoveryPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject blanket;

    private Animator animator;
    private Vector3 initialPosition;
    private bool animationStarted = false;

    public GameObject avatar;

    // Start is called before the first frame update
    void Start()
    {
        animator = avatar.GetComponent<Animator>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        // Check if the distance from the initial position is at least 10 cm in any direction
        if (!animationStarted && (Vector3.Distance(transform.position, initialPosition) >= 0.1f))
        {
            startAnimation();
            blanket.SetActive(true);
        }
    }

    void startAnimation()
    {
        animator.SetTrigger("Recovery Position");
        animationStarted = true;
    }
}
