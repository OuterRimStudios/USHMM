using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LoadSceneInteraction : Interaction
{
    public SteamVR_LoadLevel sceneLoader;
    public int sceneIndex;
    public override void Interact()
    {
        sceneLoader.Trigger(sceneIndex);
    }
}
