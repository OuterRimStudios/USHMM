using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogEvent : Event
{
    public FogVolume fogVolume;
    public List<FogValues> fogStages;
    int eventCounter;
    float velocity;
    public override void StartEvent()
    {
        base.StartEvent();
        StartCoroutine(StartFogUpdate());
    }

    public override void StopEvent()
    {
        base.StopEvent();
    }

    IEnumerator StartFogUpdate()
    {
        yield return new WaitUntil(UpdateFog);
        eventCounter++;
    }

    bool UpdateFog()
    {
        if(Mathf.Abs(fogVolume.Visibility - fogStages[eventCounter].visibility) <= 0.1f)
            return true;
        else
        {
            fogVolume.Visibility = Mathf.MoveTowards(fogVolume.Visibility, fogStages[eventCounter].visibility, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
            fogVolume.Coverage = Mathf.MoveTowards(fogVolume.Coverage, fogStages[eventCounter].coverage, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
            fogVolume.NoiseDensity = Mathf.MoveTowards(fogVolume.NoiseDensity, fogStages[eventCounter].density, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
            return false;
        }
    }
}

[System.Serializable]
public struct FogValues
{
    [Range(1, 60)]
    public float visibility;
    [Range(0, 5)]
    public float coverage;
    [Range(0, 20)]
    public float density;
    public float transitionSpeed;
}