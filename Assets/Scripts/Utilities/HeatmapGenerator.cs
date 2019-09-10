using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAnalyticsHeatmap;

public class HeatmapGenerator : MonoBehaviour
{
    WaitForSeconds delay = new WaitForSeconds(3f);
    IEnumerator Start()
    {
        for (; ; )
        {
            yield return delay;
            HeatmapEvent.Send("UserPosition", transform);
        }
    }
}