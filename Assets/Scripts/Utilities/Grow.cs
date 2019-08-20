using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float scaleSpeed;
    public Vector3 targetSize;

    public IEnumerator Start()
    {

        yield return new WaitForSeconds(.5f);
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        yield return new WaitUntil(() => IsScaled());
    }

    bool IsScaled()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, scaleSpeed * Time.deltaTime);
        return transform.localScale == targetSize;
    }
}
