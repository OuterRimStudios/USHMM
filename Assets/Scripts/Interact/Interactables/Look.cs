using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class Look : Interactable
{
    [Space, Header("Look Interaction")]
    public float lookTime;
    public float lookRadius;
    public LayerMask interactionLayer;

    float time;

    public override void Start()
    {
        useProximity = true;
        base.Start();
        ResetTime();
    }
    public override void Interact()
    {
        base.Interact();
        print("Looking");
    }

    public override void CheckProximity()
    {
        base.CheckProximity();

        if (InProximity)  //If the player is within proximity
        {
            Ray ray = new Ray(Player.position, Player.forward);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 30f);

            if (Physics.SphereCast(ray, lookRadius, 30f, interactionLayer) && !Triggered)    //if the player is looking at the interactable and the interactable has not already been triggered, then trigger the interactable.
            {
                MathUtilities.Timer(ref time);
                if (!Triggered && time <= 0)
                    Interact();
            }
            else
                ResetTime();
        }
        else if (Triggered && isRepeatable) //If the player is not within proximity and the interable has already been triggered and the interactable is repeatable, then reset the interable.
        {
            Reset();
            ResetTime();
        }
    }

    void ResetTime()
    {
        time = lookTime;
    }
}
