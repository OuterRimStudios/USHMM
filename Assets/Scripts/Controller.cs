using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Handedness { Left, Right }

public class Controller : MonoBehaviour
{
    public Handedness handedness;

    public float interactionRadius = .5f;
    public LayerMask interactionLayer;

    [Space]
    public Animator animator;
    public float animationSmoothTime;

    InputManager inputManager;

    void Start()
    {
        inputManager = InputManager.Instance;
    }

    void Update()
    {
        transform.position = (handedness == Handedness.Left ? inputManager.LeftPosition : inputManager.RightPosition);
        transform.rotation = handedness == Handedness.Left ? inputManager.LeftRotation : inputManager.RightRotation;

        Collider[] interactables = Physics.OverlapSphere(transform.position, interactionRadius, interactionLayer);

        float grip = (handedness == Handedness.Left ? inputManager.LeftGrip : inputManager.RightGrip);
        animator.SetFloat("Grip", grip,animationSmoothTime, Time.deltaTime);
    }
}

