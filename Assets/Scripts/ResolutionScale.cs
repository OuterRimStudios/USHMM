using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ResolutionScale : MonoBehaviour
{
    public float resolutionScale = 1;

    void Start()
    {
        Application.targetFrameRate = 90;
#if UNITY_EDITOR
        XRSettings.eyeTextureResolutionScale = 1;
#elif UNITY_STANDALONE
        XRSettings.eyeTextureResolutionScale = resolutionScale;
#endif
    }
}
