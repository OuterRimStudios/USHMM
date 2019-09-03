using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainEvent : OuterRimStudios.Event
{
    public delegate void CurtainEvents();
    public static event CurtainEvents OnGust;
    public override void StartEvent()
    {
        base.StartEvent();
        OnGust?.Invoke();
    }

    public override void StopEvent()
    {
        base.StopEvent();
    }
}
