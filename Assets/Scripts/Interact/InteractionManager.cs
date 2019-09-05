using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    Interaction currentInteraction;

    private void OnEnable()
    {
        Interaction.OnInteracted += Interact;
    }

    private void OnDisable()
    {
        Interaction.OnInteracted -= Interact;
    }

    public void Interact(Interaction newInteraction)
    {
        currentInteraction?.StopInteraction();
        currentInteraction = newInteraction;
    }
}
