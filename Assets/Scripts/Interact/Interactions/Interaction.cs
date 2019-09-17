using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public delegate void InteractionEvent(Interaction interaction);
    public static event InteractionEvent OnInteracted;

    public bool dontInterupt;

    public virtual void Interact()
    {
        if (!dontInterupt)
            OnInteracted?.Invoke(this);
    }

    public virtual void StopInteraction()
    {
        Debug.Log("Stopping Interaction");
    }

    public virtual void Reset() { }
}
