using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using Valve.VR;

public class RestartEvent : MonoBehaviour
{
    public SteamVR_LoadLevel levelLoader;
    bool isDone;
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Survey"))
        {
            if (!isDone && XRDevice.userPresence == UserPresenceState.NotPresent)
                isDone = true;

            if (isDone && XRDevice.userPresence == UserPresenceState.Present)
                levelLoader.Trigger(0);
        }
    }
}
