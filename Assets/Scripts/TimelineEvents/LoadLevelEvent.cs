using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LoadLevelEvent : OuterRimStudios.Event
{
    public string sceneName;

    public override void StartEvent()
    {
        SteamVR_LoadLevel.Begin(sceneName);
    }
}
