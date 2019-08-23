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
        XRSettings.eyeTextureResolutionScale = resolutionScale;
    }
}
