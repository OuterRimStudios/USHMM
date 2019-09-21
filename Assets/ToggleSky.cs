using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSky : MonoBehaviour
{
    public Camera cam;
    public void Toggle()
    {
        cam.clearFlags = CameraClearFlags.Skybox;
    }
}
