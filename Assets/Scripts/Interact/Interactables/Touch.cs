using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : Interactable
{
    public override void Interact()
    {
        base.Interact();
        print("Touched");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Controller"))
        {
            if(!Triggered)
                Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Controller"))
        {
            if(Triggered && isRepeatable)
                Reset();
        }
    }
}
