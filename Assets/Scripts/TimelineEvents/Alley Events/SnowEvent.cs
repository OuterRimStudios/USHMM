using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEvent : OuterRimStudios.Event
{
    public ParticleSystem snow;

    public override void StartEvent()
    {
        snow.gameObject.SetActive(true);
    }

    public override void StopEvent()
    {
        snow.loop = false;
    }
}
