using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float scaleSpeed;
    public float size = 1f;

    Vector3 targetSize;
    SpriteRenderer spriteRenderer;

    public IEnumerator Start()
    {
        var bounds = GetComponent<SpriteRenderer>().sprite.bounds;
        var factor = size / bounds.size.y;
        targetSize = new Vector3(factor, factor, factor);

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
