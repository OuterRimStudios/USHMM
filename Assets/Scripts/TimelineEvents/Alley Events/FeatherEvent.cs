using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherEvent : OuterRimStudios.Event
{
    public GameObject feathers;

    public override void StartEvent()
    {
        feathers.SetActive(true);
    }

    public override void StopEvent()
    {
        base.StopEvent();
    }
}
