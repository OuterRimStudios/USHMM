﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    Controls controls;

    public float LeftGrip { get; private set; }
    public float RightGrip { get; private set; }

    public Vector3 LeftPosition { get; private set; }
    public Vector3 RightPosition { get; private set; }

    public Quaternion LeftRotation { get; private set; }
    public Quaternion RightRotation { get; private set; }

    public Vector3 LeftVelocity { get; private set; }
    public Vector3 RightVelocity { get; private set; }

    public Vector3 LeftAngularVelocity { get; private set; }
    public Vector3 RightAngularVelocity { get; private set; }

    void Awake()
    {
        Instance = this;
        controls = new Controls();
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        LeftGrip = controls.Input.LeftGrip.ReadValue<float>();
        RightGrip = controls.Input.RightGrip.ReadValue<float>();

        LeftPosition = controls.Input.LeftPosition.ReadValue<Vector3>();
        RightPosition = controls.Input.RightPosition.ReadValue<Vector3>();

        LeftRotation = controls.Input.LeftRotation.ReadValue<Quaternion>();
        RightRotation = controls.Input.RightRotation.ReadValue<Quaternion>();

        LeftVelocity = controls.Input.LeftVelocity.ReadValue<Vector3>();
        RightVelocity = controls.Input.RightVelocity.ReadValue<Vector3>();

        LeftAngularVelocity = controls.Input.LeftAngularVelocity.ReadValue<Vector3>();
        RightAngularVelocity = controls.Input.RightAngularVelocity.ReadValue<Vector3>();
    }
}
