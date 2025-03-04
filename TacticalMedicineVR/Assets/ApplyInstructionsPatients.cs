using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyInstructionsPatients : MonoBehaviour
{


    [SerializeField]
    private AudioSource playerAudioSource;

    [SerializeField]
    private AudioClip audioCorrect;

    [SerializeField]
    private AudioClip audioWrong;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("PatientInstruction"))
        {
            if (other.gameObject.name == "Correct")
            {
                playerAudioSource.PlayOneShot(audioCorrect);
            }
            else if (other.gameObject.name == "Wrong")
            {
                playerAudioSource.PlayOneShot(audioWrong);
            }

            gameObject.SetActive(false);

        }
    }
}
