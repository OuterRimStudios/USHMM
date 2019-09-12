using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSEmissionInteraction : Interaction
{
    public ParticleSystem ps;
    public bool beginStopped;

    private void Start()
    {
        if (beginStopped)
            ps.Stop();
    }

    public override void Interact()
    {
        if (ps.isStopped)
            ps.Play();
        else
            ps.Stop();
    }

}
