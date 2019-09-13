using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aura2API;

public class FogEvent : OuterRimStudios.Event
{
    public List<AuraVolume> auraVolumes;
    public List<FogValues> fogStages;

    int eventCounter;
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
        if (Mathf.Abs(auraVolumes[0].densityInjection.strength - fogStages[eventCounter].density) <= 0.1f)
            return true;
        else
        {
            foreach (AuraVolume volume in auraVolumes)
                volume.densityInjection.strength = Mathf.MoveTowards(volume.densityInjection.strength, fogStages[eventCounter].density, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
            return false;
        }
    }
}

[System.Serializable]
public struct FogValues
{
    [Range(1, 60)]
    public float density;
    public float transitionSpeed;
}