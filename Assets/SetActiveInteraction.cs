using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveInteraction : Interaction
{
    public GameObject[] objectsToActivate;

    public override void Interact()
    {
        foreach (GameObject go in objectsToActivate)
            go.SetActive(!go.activeSelf);
    }

}
