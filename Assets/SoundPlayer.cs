using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSource1;

    private int currentClipIndex = 0;

    void Start()
    {
        StartCoroutine(PlayAudioSourcesWithDelays());
    }

    IEnumerator PlayAudioSourcesWithDelays()
    {
        yield return new WaitForSeconds(30f);
        audioSource1.Play();
    }
}
