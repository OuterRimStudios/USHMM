using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float hoverOffset;
    public float hoverSpeed;

    public float rotationSpeed;

    float hover;
    Vector3 velocity;
    Vector3 initialOffset;

    private void Start()
    {
        initialOffset = transform.position;
    }

    private void Update()
    {
        hover = Mathf.PingPong(Time.time * hoverSpeed, hoverOffset);

        Vector3 hoverPosition = new Vector3(transform.position.x, hover + initialOffset.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, hoverPosition, ref velocity, 1);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Mathf.Sin(Time.time * rotationSpeed), 0f, Mathf.Cos(Time.time * rotationSpeed)), 1);
    }
}
