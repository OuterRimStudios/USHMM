using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class InteractionManager : MonoBehaviour
{
    Interaction currentInteraction;
    float timeOfInteraction = 0f;
    float totalTimeBetweenInteractions = 0f;
    public static float totalTimeInProximity = 0f;
    bool initialTimeSent;
    int interactionCount;

    public static int inProximityCount;

    private void OnEnable()
    {
        Interaction.OnInteracted += Interact;
        SceneManager.sceneUnloaded += SendAnalytics;
    }

    private void OnDisable()
    {
        Interaction.OnInteracted -= Interact;
        SceneManager.sceneUnloaded -= SendAnalytics;
    }

    public void Interact(Interaction newInteraction)
    {
        if (newInteraction != currentInteraction)
        {
            currentInteraction?.StopInteraction();
        }
        currentInteraction = newInteraction;
        string sceneName = SceneManager.GetActiveScene().name;
        interactionCount++;
        Analytics.CustomEvent(sceneName, new Dictionary<string, object> { { "object", newInteraction.gameObject.name } });
        if (!initialTimeSent)
        {
            initialTimeSent = true;
            Analytics.CustomEvent(sceneName, new Dictionary<string, object> { { "initialInteractionTime", Time.timeSinceLevelLoad } });
        }
        else
            totalTimeBetweenInteractions += Time.timeSinceLevelLoad - timeOfInteraction;

        timeOfInteraction = Time.timeSinceLevelLoad;
    }

    //This function is only called when a new scene is loaded
    void SendAnalytics(Scene currentScene)
    {
        if (interactionCount == 0)
        {
            Analytics.CustomEvent(currentScene.name, new Dictionary<string, object> {
                { "averageTimeBetweenInteractions", 0 },
                { "totalTimeInProximity", 0 },
                { "averageTimeInProximity", 0 },
                { "numberOfInteractions", interactionCount }
            });
        }
        else
        {

            Analytics.CustomEvent(currentScene.name, new Dictionary<string, object> {
                { "averageTimeBetweenInteractions", totalTimeBetweenInteractions/interactionCount },
                { "totalTimeInProximity", totalTimeInProximity },
                { "averageTimeInProximity", totalTimeInProximity/inProximityCount },
                { "numberOfInteractions", interactionCount }
            });
            /*
                { "totalTimeInteracting", 0 },
                { "averageTimeInteracting", 0 },
                { "totalTimeInteracting", totalTimeInProximity },
                { "averageTimeInteracting", totalTimeInProximity/inProximityCount },
             */
        }
    }

    //this will send the analytics when the application is closed, or playmode is exited
    void OnApplicationQuit()
    {
        currentInteraction?.StopInteraction();
        SendAnalytics(SceneManager.GetActiveScene());
    }
}