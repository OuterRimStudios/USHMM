using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum FadeType { FadeIn, FadeOut }

public class FadeEvent : OuterRimStudios.Event
{
    public Image fadePanel;
    public float fadeSpeed = 1;

    public bool loadScene;
    public string sceneName;
    Color color;

    public void StartEvent(bool fadeIn)
    {
        color.a = fadeIn == true ? 0 : 1;
        StartCoroutine(Fade(fadeIn == true ? 1 : 0));
    }

    IEnumerator Fade(int value)
    {
        yield return new WaitUntil(() => Faded(value));

        if (loadScene)
            SceneManager.LoadScene(sceneName);
    }

    bool Faded(int value)
    {
        color.a = Mathf.MoveTowards(color.a, value, fadeSpeed * Time.deltaTime);
        fadePanel.color = color;
        return fadePanel.color.a == value;
    }
}
