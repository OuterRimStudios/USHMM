using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionInteraction : Interaction
{
    public MeshRenderer[] emissives;
    public bool active;

    public override void Interact()
    {
        if(active)
        {
            foreach(MeshRenderer mesh in emissives)
                mesh.material.DisableKeyword("_EMISSION");
        }
        else
        {
            foreach (MeshRenderer mat in emissives)
                mat.material.EnableKeyword("_EMISSION");
        }
        active = !active;
    }
}
