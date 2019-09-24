using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPosition : MonoBehaviour
{
    void Start()
    {
        Transform cam = Camera.main.transform;
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        transform.position = (Vector3.zero + forward) * 10;

        Vector3 lookPos = transform.position - cam.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.LookRotation(lookPos);
    }
}
