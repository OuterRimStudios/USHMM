using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light flame;
    public float minIntensity = 0.2f;
    public float maxIntensity = 1f;
    public float flickerSpeed = 0.5f;

    IEnumerator Start()
    {
        for (; ; )
        {
            flame.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
