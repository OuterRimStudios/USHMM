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

    private void Awake()
    {
        Instance = this;
    }

    public void AudioEventStarted(AudioSource source)
    {
        StartCoroutine(Transition(loweredVolume, source, 1));
    }

    public void AudioEventEnded(AudioSource source)
    {
        StartCoroutine(Transition(originalVolume, source, 0));
    }

    IEnumerator Transition(float musicVolume, AudioSource source, float sourceVolume)
    {
        yield return new WaitUntil(() => Transitioned(musicVolume, source, sourceVolume));
    }

    bool Transitioned(float musicVolume, AudioSource source, float sourceVolume)
    {
        source.volume = Mathf.MoveTowards(source.volume, sourceVolume, musicTransitionSpeed * Time.deltaTime);
        musicSource.volume = Mathf.MoveTowards(musicSource.volume, musicVolume, musicTransitionSpeed * Time.deltaTime);   
        return musicSource.volume == musicVolume;
    }

}
