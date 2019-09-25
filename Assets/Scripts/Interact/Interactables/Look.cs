
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
    float storedTime;
    bool begun;
    public override void Start()
    {
        useProximity = true;
        base.Start();
        ResetTime();
    }
    public override void Interact()
    {
        base.Interact();
    }

    void OnEnable()
    {
        if (isRepeatable)
            Reset();
    }

    public override void CheckProximity()
    {
        base.CheckProximity();

        if (InProximity)  //If the player is within proximity
        {
            Ray ray = new Ray(Player.position, Player.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, lookRadius, out hit, 30f, interactionLayer) && !Triggered)    //if the player is looking at the interactable and the interactable has not already been triggered, then trigger the interactable.
            {
                if(hit.transform == transform)
                {
                
                    if (Pointer.Instance && !Pointer.Instance.stopFill)
                    {
                        if(!begun)
                        {
                            ResetTime();
                            begun = true;
                        }

                        MathUtilities.Timer(ref time);
                        float pointerTime = MathUtilities.MapValue(0, lookTime, 1, 0, time);
                        Pointer.Instance.Fill(pointerTime);


                        if (!Triggered && time <= 0)
                        {
                            begun = false;
                            Interact();
                        }
                    }
                    else
                    {
                        MathUtilities.Timer(ref time);

                        if (!Triggered && time <= 0)
                            Interact();
                    }
                }
            }
            else
            {
                if (Pointer.Instance)
                {
                    begun = false;
                    Pointer.Instance.StopFill();
                }

                ResetTime();
            }
        }
        else if (Triggered && isRepeatable) //If the player is not within proximity and the interable has already been triggered and the interactable is repeatable, then reset the interable.
        {
            if (Pointer.Instance)
                Pointer.Instance.StopFill();

            Reset();
            ResetTime();
        }
    }

    void ResetTime()
    {
        time = lookTime;
    }
}
