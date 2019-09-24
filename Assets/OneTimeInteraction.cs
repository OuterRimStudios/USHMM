using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeInteraction : Interaction
{
    public AudioInteraction interaction;
    public override void Interact()
    {
        if (!interaction.HasPlayed)
            interaction.Interact();
    }
}
