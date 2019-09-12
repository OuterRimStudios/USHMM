using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolAnimationInteraction : Interaction
{
    public string boolName;
    public Animator animator;

    public override void Interact()
    {
        animator.SetBool(boolName, !animator.GetBool(boolName));
    }
}
