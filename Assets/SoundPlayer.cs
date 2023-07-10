using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;

    private int currentClipIndex = 0;

    void Start()
    {
        StartCoroutine(PlayAudioSourcesWithDelays());
    }

    IEnumerator PlayAudioSourcesWithDelays()
    {
        yield return new WaitForSeconds(20f);
        audioSource1.Play();
        yield return new WaitForSeconds(5f);
        audioSource2.Play();
        yield return new WaitForSeconds(10f);
        audioSource3.Play();
        yield return new WaitForSeconds(15f);
        audioSource4.Play();
    }
}
