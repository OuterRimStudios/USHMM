using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public class BGMove : MonoBehaviour
{
    public float speed;
    public BGCcCursor curve;

    private void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitUntil(() => InPosition());
        curve.DistanceRatio = 1;
    }

    bool InPosition()
    {
        curve.DistanceRatio = Time.time * speed;
        return curve.DistanceRatio >= 1;
    }
}
