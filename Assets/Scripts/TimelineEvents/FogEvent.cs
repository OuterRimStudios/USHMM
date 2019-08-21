﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogEvent : Event
{
    public List<FogVolume> fogVolumes;
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
        if (Mathf.Abs(fogVolumes[0].Visibility - fogStages[eventCounter].visibility) <= 0.1f)
            return true;
        else
        {
            foreach (FogVolume volume in fogVolumes)
            {
                volume.Visibility = Mathf.MoveTowards(volume.Visibility, fogStages[eventCounter].visibility, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
                if (volume.EnableNoise)
                {
                    volume.Coverage = Mathf.MoveTowards(volume.Coverage, fogStages[eventCounter].coverage, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
                    volume.NoiseDensity = Mathf.MoveTowards(volume.NoiseDensity, fogStages[eventCounter].density, fogStages[eventCounter].transitionSpeed * Time.deltaTime);
                }
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