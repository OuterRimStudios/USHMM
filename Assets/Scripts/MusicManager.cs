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

    public void AudioEventStarted()
    {
        StartCoroutine(Transition(loweredVolume));
    }

    public void AudioEventEnded()
    {
        StartCoroutine(Transition(originalVolume));
    }

    IEnumerator Transition(float musicVolume)
    {
        yield return new WaitUntil(() => Transitioned(musicVolume));
    }

    bool Transitioned(float musicVolume)
    {
        musicSource.volume = Mathf.MoveTowards(musicSource.volume, musicVolume, musicTransitionSpeed * Time.deltaTime);   
        return musicSource.volume == musicVolume;
    }

    public void CheckSource(AudioSource source)
    {
        Debug.Log("Checking Source");
        if (oldSource == source)
            oldSource = null;
    }

    public void VoiceOverStarted(AudioSource source)
    {
        Debug.Log("New Source: " + source.transform.parent.name);
        if (oldSource)
            Debug.Log("Old Source: " + oldSource.transform.parent.name);

        if (oldSource)
        {
            oldSource.volume = 0;
            oldSource.Stop();
            oldSource.volume = 1;
        }

        oldSource = source;
    }

}
