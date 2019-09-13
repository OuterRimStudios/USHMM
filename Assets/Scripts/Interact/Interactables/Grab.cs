using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class Grab : Interactable
{
    [Space, Header("Grab Interactions")]
    public bool HasInteraction;
    public float resetTime;

    public bool ControllerNear { get; protected set; }
    public bool IsGrabbed { get; protected set; }

    float time;
    bool wasGrabbed;
    Vector3 startingPosition;
    Quaternion startingRotation;

    Rigidbody rb;
    Controller controller;

    List<Collider> controllers = new List<Collider>();

    int currentIndex = 0;

    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();

        time = resetTime;                               //Set the time it takes for the objects position to reset
        startingPosition = transform.position;          //Store the initial position of the object
        startingRotation = transform.rotation;          //Store the inital rotation of the object
    }

    public override void Interact()
    {
        base.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Controller"))
        {
            if (!controllers.Contains(other))
                controllers.Add(other);

            ControllerNear = true;
        }
        else
            LetGo();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Controller"))
            print("Controller gone");

        if (other.tag.Equals("Controller") && controllers.Contains(other))
            controllers.Remove(other);

        if (controllers.Count <= 0)
            ControllerNear = false;
    }

    public override void Update()
    {
        base.Update();

        if(ControllerNear && !IsGrabbed)    //If there is a controller within the radius and this object is not currently being grabbed
        {
            if (ControllerNear && controllers.Count > 1)
            {
                if (currentIndex == 0)
                    currentIndex = 1;
                else
                    currentIndex = 0;
            }
            else
                currentIndex = 0;

            controller = controllers[currentIndex].GetComponent<Controller>(); //Store the controller that grabbed this object
            GrabObject(controller);
        }

        if(controller && IsGrabbed) //If the object is currently being grabbed and the controller that is grabbing it exsists
        {
            if ((controller.handedness == Handedness.Left ? InputManager.Instance.LeftGrip : InputManager.Instance.RightGrip) == false) //Check the handedness of this controller to determine when the player lets go of grip button
            {
                LetGo();
            }
        }

        if(wasGrabbed && !IsGrabbed)    //If this object was recently grabbed but is no longer being grabbed 
        {
            MathUtilities.Timer(ref time);  //then start a count down timer

            if(time <= 0)   //If this timer hits 0, then reset the object's values
                Reset();
        }
    }

    void LetGo()
    {
        if(controller)
            GrabManager.Instance.Drop(controller.handedness);
        transform.SetParent(null);  //unchild this object from the controller

        if(rb)
        {
            rb.useGravity = true;   //re enable the gravity of the object and set isKinematic back to false
            rb.isKinematic = false;
        }

        if(controller && rb)
        {
            rb.velocity = (controller.handedness == Handedness.Left ? InputManager.Instance.LeftVelocity : InputManager.Instance.RightVelocity) / 2;
            rb.angularVelocity = controller.handedness == Handedness.Left ? InputManager.Instance.LeftAngularVelocity : InputManager.Instance.RightAngularVelocity;
        }

        IsGrabbed = false;  //the object is no longer being grabbed
        controller = null;  //clear the cached controller
    }

    void GrabObject(Controller controller)
    {
        if (GrabManager.Instance.IsBusy(controller.handedness)) return;
        if ((controller.handedness == Handedness.Left ? InputManager.Instance.LeftGrip : InputManager.Instance.RightGrip) == true) //Check the controllers handedness in order to see if the grip button on that controller has been pressed
        {
            GrabManager.Instance.Grab(controller.handedness);

                wasGrabbed = true; //Store the fact that this object has been grabbed recently
            if (HasInteraction && !Triggered)   //If this is a grabble object that triggers an event and the event has not been triggered already, then trigger the event
                Interact();

            transform.parent = (controller.transform);  //Child this object to the controller that grabbed it

            rb.useGravity = false;  //Disable the gravity of the object and set it to kinematic
            rb.isKinematic = true;

            time = resetTime;   //Reset timer
            IsGrabbed = true;   //The object is now currently being grabbed
        }
    }

    public override void Reset()
    {
        rb.velocity = Vector3.zero;
        transform.position = startingPosition;  //Set the position of this object back to it's starting position
        transform.rotation = startingRotation;  //Set the rotation of this object back to it's starting rotation
        wasGrabbed = false;                     //This object has no longer been recently grabbed
        time = resetTime;                       //Reset the timer for the next time the object is grabbed
            
        if(HasInteraction && isRepeatable)      //If this object did have an interaction and that interaction can be repeated, then reset the Triggered value                  
            base.Reset();
    }
}
