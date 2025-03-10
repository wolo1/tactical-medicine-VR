using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class UseNasofarengia : MonoBehaviour
{
    [SerializeField]
    private DynamicCharacterAvatar avatar;

    [SerializeField]
    private UMATextRecipe nasofarengiaRecipe;

    [SerializeField]
    private PainExpressionAnimatorGirl painExpressionAnimatorGirl;

    [SerializeField]
    private AudioSource audioSourceGirl;

    [SerializeField]
    private AudioClip audioClipBreathe;

    [SerializeField]
    private AudioClip audioClipBreatheCalm;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER DETECTED");
        if (other.gameObject.CompareTag("MedicalEquipment"))
        {
            var medicalEquipment = other.gameObject.GetComponent<MedicalEquipment>();
            if (medicalEquipment != null)
            {
                if (medicalEquipment.type == "Nasofarengia")
                {
                    Debug.Log("TRIGGER NASOFARENGIA ENTER DETECTED");
                    medicalEquipment.applied = true;

                    // Start Coroutine to delay execution
                    StartCoroutine(DelayedEffects());

                    EquipNasofarengia();
                }
            }
            else
            {
                Debug.Log("The triggered object is not a MedicalEquipment");
            }
        }
    }

    public void EquipNasofarengia()
    {
        avatar.SetSlot(nasofarengiaRecipe);
        avatar.BuildCharacter();
    }

    IEnumerator DelayedEffects()
    {
        yield return new WaitForSeconds(0.5f); // Delay for 0.5 seconds

        ChangeAudio();
        painExpressionAnimatorGirl.activateBreathe();

        StartCoroutine(DelayedEffect1());
    }


    IEnumerator DelayedEffect1()
    {
        yield return new WaitForSeconds(20.0f);
        ChangeAudioBreatheCalm();
        painExpressionAnimatorGirl.activateBreatheCalm();
    }
    //add another delayed call after 10 seconds
    // change the audio again to more calm breathing
    //activate more calm expression with almost close mouth



    void ChangeAudio()
    {
        audioSourceGirl.Stop();
        audioSourceGirl.clip = audioClipBreathe;
        audioSourceGirl.Play();
    }


    void ChangeAudioBreatheCalm()
    {
        audioSourceGirl.Stop();
        audioSourceGirl.clip = audioClipBreatheCalm;
        audioSourceGirl.Play();
    }
}
