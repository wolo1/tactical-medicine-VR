using System.Collections;
using UnityEngine;

public class AudioOldMan : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSourceOldMan;

    [Header("Old Man")]
    [SerializeField]
    private AudioClip audioOldMan1;

    [SerializeField]
    private AudioClip audioOldMan2;

    [SerializeField]
    private AudioClip audioOldMan3;

    [SerializeField]
    private GameObject instructions;

    

    [SerializeField]
    public bool talkRare = false; 
    private void Start()
    {
        audioSourceOldMan = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomAudio());
    }

    private IEnumerator PlayRandomAudio()
    {
        yield return new WaitForSeconds(40f); // Wait 40 seconds before first play

        instructions.SetActive(true);

        while (true)
        {
            float waitTime = talkRare ? Random.Range(20f, 25f) : Random.Range(5f, 8f);
            yield return new WaitForSeconds(waitTime);

            PlayRandomClip();
        }
    }

    private void PlayRandomClip()
    {
        if (audioSourceOldMan != null)
        {
            AudioClip clipToPlay = GetRandomClip();
            if (clipToPlay != null)
            {
                audioSourceOldMan.PlayOneShot(clipToPlay);
            }
        }
    }

    private AudioClip GetRandomClip()
    {
        AudioClip[] clips = { audioOldMan1, audioOldMan2, audioOldMan3 };
        return clips[Random.Range(0, clips.Length)];
    }
}
