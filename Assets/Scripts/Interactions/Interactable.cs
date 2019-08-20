using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class Interactable : MonoBehaviour
{
    [Header("Proximity")]
    public bool useProximity;
    public float proximityDistance;

    [Space, Header("Repeatable")]
    public bool isRepeatable;

    public bool InProximity { get; set; }
    public bool Triggered { get; set; }
    public Transform Player { get; protected set; }

    public virtual void Start()
    {
        if(useProximity)
            Player = GameObject.Find("Player").transform;
    }

    public virtual void Interact()
    {
        Triggered = true;
    }

    public virtual void Update()
    {
        if (!useProximity) return;
        CheckProximity();
        print(InProximity);
    }

    public virtual void CheckProximity()
    {
        InProximity = MathUtilities.CheckDistance(Player.position, transform.position) < proximityDistance;
    }

    public virtual void Reset()
    {
        if (isRepeatable)
            Triggered = false;
    }

    private void OnDrawGizmos()
    {
        if(useProximity)
            Gizmos.DrawWireSphere(transform.position, proximityDistance);
    }
}
