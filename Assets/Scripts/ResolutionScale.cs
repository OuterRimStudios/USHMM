using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ResolutionScale : MonoBehaviour
{
    public bool enableInEditor;
    public float resolutionScale = 1;

    void Start()
    {
        Application.targetFrameRate = 90;
#if UNITY_EDITOR
        if (!enableInEditor)
            XRSettings.eyeTextureResolutionScale = 1;
        else
            XRSettings.eyeTextureResolutionScale = resolutionScale;
#elif UNITY_STANDALONE
        XRSettings.eyeTextureResolutionScale = resolutionScale;
#endif
    }
}
