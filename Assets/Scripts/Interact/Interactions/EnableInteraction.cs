using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableInteraction : Interaction
{
    public Behaviour[] behaviours;
    public bool toggled;

    public override void Interact()
    {
        if(toggled)
        {
            foreach (Behaviour behaviour in behaviours)
                behaviour.enabled = !behaviour.isActiveAndEnabled;
        }
        else
        {
            foreach (Behaviour behaviour in behaviours)
                behaviour.enabled = true;
        }
    }

    public override void StopInteraction()
    {
        if (toggled) return;
        foreach (Behaviour behaviour in behaviours)
            behaviour.enabled = false;
    }
}
