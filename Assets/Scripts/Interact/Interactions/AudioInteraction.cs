using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : Interaction
{
    public AudioSource audioSource;

    public override void Interact()
    {
        audioSource.Play();
    }
}
