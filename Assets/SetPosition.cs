using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    public float offset;

    private void Start()
    {
        float playerHeight = Camera.main.transform.position.y;
        transform.position = new Vector3(transform.position.x, playerHeight - offset, transform.position.z);
    }
}
