using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private AudioSource audioSource;
    private NPCMover npcMover;
    public Animator animator;       


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        npcMover = GetComponent<NPCMover>();
    }

    void Update()
    {
        // Check if the audio is playing
        if (audioSource != null && !audioSource.isPlaying)
        {
            Debug.Log("Audio is not playing!");
            npcMover.enabled = true;
            animator.SetTrigger("Walking");
        }
       
    }
}
