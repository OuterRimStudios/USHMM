using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogEvent : Event
{
    public FogVolume groundFogVolume;
    public FogVolume uniformFogVolume;
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
        if(Mathf.Abs(groundFogVolume.Visibility - fogStages[eventCounter].visibility) <= 0.1f)
            return true;
        else
        {
            groundFogVolume.Visibility = Mathf.MoveTowards(groundFogVolume.Visibility, fogStages[eventCounter].visibility, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
            uniformFogVolume.Visibility = Mathf.MoveTowards(uniformFogVolume.Visibility, fogStages[eventCounter].visibility, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
            if(groundFogVolume.EnableNoise)
            {
                groundFogVolume.Coverage = Mathf.MoveTowards(groundFogVolume.Coverage, fogStages[eventCounter].coverage, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
                groundFogVolume.NoiseDensity = Mathf.MoveTowards(groundFogVolume.NoiseDensity, fogStages[eventCounter].density, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
            }
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