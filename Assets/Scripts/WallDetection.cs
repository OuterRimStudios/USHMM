using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class WallDetection : MonoBehaviour
{
    public float minDistance;
    public float fadeSpeed;
    public float opacity;
    Transform player;
    MeshRenderer rend;
    Color newColor;
    private void Start()
    {
        player = Camera.main.transform;
        rend = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        float distance = MathUtilities.CheckDistance(player.position, transform.position);

        Debug.Log("Distance = " + distance);

        newColor = rend.material.color;
        if (distance <= minDistance)
            newColor.a = Mathf.MoveTowards(newColor.a, opacity, fadeSpeed * Time.deltaTime);
        else
            newColor.a = Mathf.MoveTowards(newColor.a, 0, fadeSpeed * Time.deltaTime);

        rend.material.color = newColor;
    }
}
