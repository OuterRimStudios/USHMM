using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;
public class ResetInteractable : MonoBehaviour
{
    public float resetTime = 2.5f;
    float time;

    Vector3 startingPosition;
    Quaternion startingRotation;
    Rigidbody rb;

    bool wasGrabbed;
    bool isGrabbed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        time = resetTime;                               
        startingPosition = transform.position;          
        startingRotation = transform.rotation;          
    }

    private void Update()
    {
        if(wasGrabbed && !isGrabbed)
        {
            MathUtilities.Timer(ref time);

            if (time <= 0)
                Reset();
        }
    }

    public void GrabObject()
    {
        if (!wasGrabbed) wasGrabbed = true;
        isGrabbed = true;
    }

    public void LetGo()
    {
        isGrabbed = false;
    }

    private void Reset()
    {
        rb.velocity = Vector3.zero;
        transform.position = startingPosition;  //Set the position of this object back to it's starting position
        transform.rotation = startingRotation;  //Set the rotation of this object back to it's starting rotation
        time = resetTime;                       //Reset the timer for the next time the object is grabbed
    }
}
