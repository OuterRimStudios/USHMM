using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainEvent : OuterRimStudios.Event {
    public ADSGlobalMotion globalMotion;
    public Material curtainMat;
    public float normalAmplitude;
    public float normalSpeed;
    public float normalScale;
    public float gustAmplitude;
    public float gustSpeed;
    public float gustScale;
    public float transitionSpeed;

    bool gustActive;
    float targetAmplitude, targetSpeed, targetScale;
    float matAmplitude, matSpeed, matScale;

    public delegate void CurtainEvents();
    public static event CurtainEvents OnGust;
    public override void StartEvent() {
        base.StartEvent();
        OnGust?.Invoke();
        gustActive = true;
        StartCoroutine(MotionTransition());
    }

    public override void StopEvent() {
        base.StopEvent();
        gustActive = false;
        StartCoroutine(MotionTransition());
    }

    IEnumerator MotionTransition() {
        targetAmplitude = gustActive == true ? gustAmplitude : normalAmplitude;
        targetSpeed = gustActive == true ? gustSpeed : normalSpeed;
        targetScale = gustActive == true ? gustScale : normalScale;
        yield return new WaitUntil(Transition);
    }

    bool Transition() {
        //&& Mathf.Abs(globalMotion.motionSpeed - targetSpeed) <= 0.01f
        if (Mathf.Abs(globalMotion.motionAmplitude - targetAmplitude) <= 0.01f  && Mathf.Abs(globalMotion.motionScale - targetScale) <= 0.01f)
            return true;
        else {
            globalMotion.motionAmplitude = Mathf.MoveTowards(globalMotion.motionAmplitude, targetAmplitude, transitionSpeed * Time.deltaTime);
            //globalMotion.motionSpeed = Mathf.MoveTowards(globalMotion.motionSpeed, targetSpeed, transitionSpeed * Time.deltaTime);
            globalMotion.motionScale = Mathf.MoveTowards(globalMotion.motionScale, targetScale, transitionSpeed * Time.deltaTime);
            return false;
        }
        /*
        if (Mathf.Abs(curtainMat.GetFloat("_MotionAmplitude") - targetAmplitude) <= 0.01f && Mathf.Abs(curtainMat.GetFloat("_MotionSpeed") - targetSpeed) <= 0.01f && Mathf.Abs(curtainMat.GetFloat("_MotionScale") - targetScale) <= 0.01f)
            return true;
        else {
            matAmplitude = Mathf.MoveTowards(matAmplitude, targetAmplitude, transitionSpeed * Time.deltaTime);
            matSpeed = Mathf.MoveTowards(matSpeed, targetSpeed, transitionSpeed * Time.deltaTime);
            matScale = Mathf.MoveTowards(matScale, targetScale, transitionSpeed * Time.deltaTime);
            curtainMat.SetFloat("_MotionAmplitude", matAmplitude);
            curtainMat.SetFloat("_MotionSpeed", matSpeed);
            curtainMat.SetFloat("_MotionScale", matScale);
            return false;
        }
        */
    }
}