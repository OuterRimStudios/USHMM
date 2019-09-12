using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSEmissionInteraction : Interaction
{
    public GameObject[] objects;

    public override void Interact()
    {
        foreach (GameObject go in objects)
            go.SetActive(!go.activeInHierarchy);
    }

}
