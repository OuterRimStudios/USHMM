using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using OuterRimStudios.Utilities;

public enum FadeType { FadeIn, FadeOut }

public class FadeEvent : OuterRimStudios.Event
{
    public bool stopFade;
    public Image fadePanel;
    public float fadeSpeed = 1;

    public bool loadScene;
    public string sceneName;

    public bool timed;
    public float timer;

    Color color;
    float time;
    bool fading;

    private void Start()
    {
        if (timed)
            time = timer;
    }

    void Update()
    {
        if(timed)
        {
            MathUtilities.Timer(ref time);

            if (!fading && time <= 0)
            {
                fading = true;
                StartEvent(true);
            }
        }
    }

    public void StartEvent(bool fadeIn)
    {
        if(!stopFade)
        {
            color.a = fadeIn == true ? 0 : 1;
            StartCoroutine(Fade(fadeIn == true ? 1 : 0));
        }
        else
        {
            if (loadScene)
                SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator Fade(int value)
    {
        yield return new WaitUntil(() => Faded(value));

        if(!stopFade)
            color.a = value;
        if (loadScene)
            SceneManager.LoadScene(sceneName);
    }

    bool Faded(int value)
    {
        if(!stopFade)
        {
            color.a = Mathf.MoveTowards(color.a, value, fadeSpeed * Time.deltaTime);
            fadePanel.color = color;
        }
        return fadePanel.color.a == value;
    }
}
