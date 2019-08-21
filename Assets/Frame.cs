using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public CurvedMovement curvedMovement { get; private set; }
    public Grow grow { get; private set; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        curvedMovement = GetComponent<CurvedMovement>();
        grow = GetComponent<Grow>();
        curvedMovement.enabled = false;
        grow.enabled = false;
    }
}
