using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : Interaction
{
    public AudioSource audioSource;

    public override void Interact()
    {
        base.Interact();
        audioSource.Play();
    }

    public override void StopInteraction()
    {
        if(!dontInterupt)
            audioSource.Stop();
    }
}
