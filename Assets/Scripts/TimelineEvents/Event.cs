﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public virtual void StartEvent()
    {
        print("Event Started");
    }

    public virtual void StopEvent()
    {
        print("Event Ended");
    }
}
