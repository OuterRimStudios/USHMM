using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using OuterRimStudios.Utilities;

public class InteractionManager : MonoBehaviour
{
    Interaction currentInteraction;
    float initialInteractionTime = 0f;
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

        //Adds each object the user interacts with to the analytics
        var objectData = new List<object> { new  { Interactable = newInteraction.gameObject.name } };
        AnalyticsUtilities.Event(sceneName + "_InteractedObjects", objectData);

        if (!initialTimeSent)
        {
            initialTimeSent = true;
            initialInteractionTime = Time.timeSinceLevelLoad;
        }
        else
            totalTimeBetweenInteractions += Time.timeSinceLevelLoad - timeOfInteraction;

        timeOfInteraction = Time.timeSinceLevelLoad;
    }

    //This function is only called when a new scene is loaded
    void SendAnalytics(Scene currentScene)
    {
        var data = new List<object>();
        if (interactionCount == 0)
        {
            data.Add(new { InitialInteractionTime = initialInteractionTime, AverageTimeBetweenInteractions = 0, NumberOfInteractions = 0});
        }
        else
        {
            data.Add
            (
                new {
                    InitialInteractionTime = initialInteractionTime,
                    AverageTimeBetweenInteractions = totalTimeBetweenInteractions/interactionCount,
                    NumberOfInteractions = interactionCount
                }
            );
            /*
                { "totalTimeInteracting", 0 },
                { "averageTimeInteracting", 0 },
                { "totalTimeInteracting", totalTimeInProximity },
                { "averageTimeInteracting", totalTimeInProximity/inProximityCount },
             */
        }

        //Adds all of the data to the analytics
        AnalyticsUtilities.Event(currentScene.name + "_InteractionData", data);
    }

    //this will send the analytics when the application is closed, or playmode is exited
    void OnApplicationQuit()
    {
        currentInteraction?.StopInteraction();
        SendAnalytics(SceneManager.GetActiveScene());
    }
}