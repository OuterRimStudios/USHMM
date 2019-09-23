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
    Coroutine audio;
    private void Start()
    {
        if(!audioSource)
            audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (hasPlayed && !isRepeatable) return;
        if (audioSource.isPlaying) return;

        base.Interact();

        if(!audioSource.isPlaying)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            if (lowersMusic)
            {
                MusicManager.Instance.VoiceOverStarted(audioSource);
                if (audio != null)
                    StopCoroutine(audio);

                MusicManager.Instance.AudioEventStarted();
                audio = StartCoroutine(AudioEvent());
            }
        }

        if (!hasPlayed) hasPlayed = true;
    }

    IEnumerator AudioEvent()
    {
        yield return new WaitUntil(() => AudioEnded());
        MusicManager.Instance.AudioEventEnded();
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
