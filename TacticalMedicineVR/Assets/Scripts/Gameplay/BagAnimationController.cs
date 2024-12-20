using UnityEngine;

public class BagAnimationController : MonoBehaviour
{
    public Animator animator;
    public bool start = false;

    private void Start()
    {
        if (start)
        {
            animator.SetTrigger("OpenTrigger");

        }
    }

    public void OpenBag()
    {
        if (start)
        {
            animator.SetTrigger("OpenTrigger");

        }
    }

    public void CloseBag()
    {
        animator.SetTrigger("CloseTrigger");
    }
}
