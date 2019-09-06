using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class CurvedMovement : MonoBehaviour
{
    public Transform startingPosition;
    public float curveHeightMultiplier = 1.0f;
    public float speed;
    public Transform endPosition;

    public AnimationCurve curve; // = new AnimationCurve()
    float time;

    bool arrived;
    float originalDistance;

    private void Start()
    {
        float distance = MathUtilities.CheckDistance(startingPosition.position, endPosition.position);

        //curve.AddKey(new Keyframe(0, 0));
        //curve.AddKey(new Keyframe(distance / 2, (distance / 2) * curveHeightMultiplier));
        //curve.AddKey(new Keyframe(distance, 0));

        //curve.SmoothTangents(0, 1);
        //curve.SmoothTangents(2, 1);
    }

    void Update()
    {
        if (arrived) return;
        time += Time.deltaTime * speed;
        Vector3 position = Vector3.MoveTowards(startingPosition.position, endPosition.position, time);

        position.y = curve.Evaluate(time);
        transform.position = position;

        if (MathUtilities.CheckDistance(transform.position, endPosition.position) < 1f)
            arrived = true;
    }
}
