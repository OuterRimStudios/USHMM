using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAnalyticsHeatmap;

public class HeatmapGenerator : MonoBehaviour
{
    public Transform mainCam;
    WaitForSeconds delay = new WaitForSeconds(3f);
    IEnumerator Start()
    {
        for (; ; )
        {
            yield return delay;
            HeatmapEvent.Send("UserPosition", transform);

            RaycastHit hit;
            Ray ray = new Ray(mainCam.position, mainCam.forward);
            if (Physics.Raycast(ray, out hit, 150))
                HeatmapEvent.Send("LookPosition", hit.point);
        }
    }
}