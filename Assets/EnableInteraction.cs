using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableInteraction : Interaction
{
    public Behaviour[] behaviours;

    public override void Interact()
    {
        foreach (Behaviour behaviour in behaviours)
            behaviour.enabled = true;
    }

    public override void StopInteraction()
    {
        foreach (Behaviour behaviour in behaviours)
            behaviour.enabled = false;
    }
}
