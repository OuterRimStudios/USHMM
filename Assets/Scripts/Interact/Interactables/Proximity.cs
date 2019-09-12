using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : Interactable
{
    public bool stopInteractionOnExit;

    public override void Start()
    {
        base.Start();
    }
    public override void Interact()
    {
        base.Interact();
    }

    public override void CheckProximity()
    {
        base.CheckProximity();

        if (!Triggered && InProximity)                               //If this Interactable has not been triggered and the Player is within proximity distance, Trigger the event.
            Interact();
        else if (!InProximity && Triggered && stopInteractionOnExit)
            StopInteract();
        else if (Triggered && isRepeatable && !InProximity)          //If this Interactable has already beed triggered and your no longer within proximity and this event can be repeated, Reset the event.
            Reset();
    }
}
