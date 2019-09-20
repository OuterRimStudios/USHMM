using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource musicSource;

    [Range(0, 1)]
    public float originalVolume;
    [Range(0, 1)]
    public float loweredVolume;

    public float musicTransitionSpeed = .5f;
    public float sourceTransitionSpeed = 1;

    AudioSource oldSource;

    private void Awake()
    {
        Instance = this;
    }

    public void AudioEventStarted(AudioSource source)
    {
        if (oldSource)
            oldSource.volume = 0;

        oldSource = source;
        source.volume = 1;
        StartCoroutine(Transition(loweredVolume, source));
    }

    public void AudioEventEnded(AudioSource source)
    {
        StartCoroutine(Transition(originalVolume, source));
        oldSource = null;
    }

    IEnumerator Transition(float musicVolume, AudioSource source)
    {
        yield return new WaitUntil(() => Transitioned(musicVolume, source));
    }

    bool Transitioned(float musicVolume, AudioSource sourcee)
    {
        musicSource.volume = Mathf.MoveTowards(musicSource.volume, musicVolume, musicTransitionSpeed * Time.deltaTime);   
        return musicSource.volume == musicVolume;
    }

}
