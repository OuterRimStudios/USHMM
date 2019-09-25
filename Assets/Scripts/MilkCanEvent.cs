using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkCanEvent : Interaction
{
    public AudioInteraction sound;
    public Animator animator;
    public override void Interact()
    {
        if(!animator.GetBool("Open"))
        {
            animator.SetBool("Open", true);
            sound.Interact();
        }
    }
}
