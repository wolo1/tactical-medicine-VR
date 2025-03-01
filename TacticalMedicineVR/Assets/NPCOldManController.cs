using System.Collections;
using UnityEngine;

public class NPCOldManController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        StartCoroutine(SetLayerWeightAfterDelay(40f, 1, 1f)); // Wait 40 seconds, then set layer index 1 weight to 1
    }

    IEnumerator SetLayerWeightAfterDelay(float delay, int layerIndex, float weight)
    {
        yield return new WaitForSeconds(delay);
        if (animator != null)
        {
            animator.SetLayerWeight(layerIndex, weight);
            animator.SetTrigger("Gesture");
            Debug.Log($"Layer {layerIndex} weight set to {weight}");
        }
    }
}
