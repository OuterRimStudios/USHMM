using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : Interactable
{
    public override void Start()
    {
        base.Start();
    }
    public override void Interact()
    {
        base.Interact();
        print("Triggered");
    }

    public override void CheckProximity()
    {
        base.CheckProximity();

        if(!Triggered && InProximity)                               //If this Interactable has not been triggered and the Player is within proximity distance, Trigger the event.
            Interact();
        else if(Triggered && isRepeatable && !InProximity)          //If this Interactable has already beed triggered and your no longer within proximity and this event can be repeated, Reset the event.
            Reset();
    }
}
