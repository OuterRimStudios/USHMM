using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LoadLevelEvent : OuterRimStudios.Event
{
    public string sceneName;

    public override void StartEvent()
    {
        print("should load: " + sceneName);
        SteamVR_LoadLevel.Begin(sceneName);
    }
}
