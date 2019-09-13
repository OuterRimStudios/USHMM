using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour
{
    public static GrabManager Instance;

    public bool LeftHandBusy { get; private set; }
    public bool RightHandBusy { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Grab(Handedness handedness)
    {
        if (handedness == Handedness.Left)
            LeftHandBusy = true;
        else
            RightHandBusy = true;
    }

    public void Drop(Handedness handedness)
    {
        if (handedness == Handedness.Left)
            LeftHandBusy = false;
        else
            RightHandBusy = false;
    }

    public bool IsBusy(Handedness handedness)
    {
        return handedness == Handedness.Left ? LeftHandBusy : RightHandBusy;
    }
}
