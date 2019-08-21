using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public float minSpeed = 1;
    public float maxSpeed = 3;
    public Transform target;

    int direction;
    float speed;

    private void Start()
    {
        direction = Random.Range(0, 2) == 0 ? -1 : 1;
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.LookAt(target);
        transform.RotateAround(target.position, Vector3.up, direction * speed * Time.deltaTime);
    }
}
