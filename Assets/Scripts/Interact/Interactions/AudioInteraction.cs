using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : Interaction
{
    public AudioClip[] audioClips;
    public bool isRepeatable;

    public AudioSource audioSource;
    public bool lowersMusic;

    bool hasPlayed;
    private void Start()
    {
        if(!audioSource)
            audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (hasPlayed && !isRepeatable) return;
        else
            audioSource.Stop();
        base.Interact();

        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);

        if (!hasPlayed) hasPlayed = true;

        if (lowersMusic)
        {
            MusicManager.Instance.AudioEventStarted(audioSource);
            StartCoroutine(AudioEvent());
        }
    }

    IEnumerator AudioEvent()
    {
        yield return new WaitUntil(() => AudioEnded());
        MusicManager.Instance.AudioEventEnded(audioSource);
    }

    bool AudioEnded()
    {
        return !audioSource.isPlaying;
    }

    public override void StopInteraction()
    {
        if(!dontInterupt)
            audioSource.Stop();
    }
}
