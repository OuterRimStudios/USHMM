using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioInteraction : Interaction
{
    public AudioClip[] clips;

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.tag.Equals("Controller"))
            source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}
