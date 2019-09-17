using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : Interaction
{
    public AudioClip[] audioClips;
    public bool isRepeatable;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (!isRepeatable) return;

        base.Interact();
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
    }

    public override void StopInteraction()
    {
        if(!dontInterupt)
            audioSource.Stop();
    }
}
