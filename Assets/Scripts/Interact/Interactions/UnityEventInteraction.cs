using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventInteraction : Interaction
{
    public UnityEvent interactionEvent;

    public override void Interact()
    {
        interactionEvent?.Invoke();
    }
}
