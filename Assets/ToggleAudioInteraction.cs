using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudioInteraction : Interaction
{
    public AudioClip[] initialSounds;
    public AudioClip[] secondarySounds;

    public AudioSource[] initialSources;
    public AudioSource[] secondarySources;

    AudioSource source;

    bool toggle;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (!toggle)
        {
            foreach(AudioSource source in initialSources)
            {
                source.clip = initialSounds[Random.Range(0, initialSounds.Length)];
                source.Play();
            }

            foreach(AudioSource source in secondarySources)
                source.Stop();
        }
        else
        {
            foreach(AudioSource source in secondarySources)
            {
                source.clip = secondarySounds[Random.Range(0, secondarySounds.Length)];
                source.Play();
            }

            foreach (AudioSource source in initialSources)
                source.Stop();
        }
    }
}
