using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class Interactable : MonoBehaviour
{
    public bool useProximity;
    public float proximityDistance;

    public bool InProximity { get; set; }
    Transform player;

    public virtual void Start()
    {
        if(useProximity)
            player = GameObject.Find("Player").transform;
    }

    public virtual void Interact() { }

    public virtual void Update()
    {
        if (!useProximity) return;
        Proximity();
        print(InProximity);
    }

    void Proximity()
    {
        InProximity = MathUtilities.CheckDistance(player.position, transform.position) < proximityDistance;
    }

    private void OnDrawGizmos()
    {
        if(useProximity)
            Gizmos.DrawWireSphere(transform.position, proximityDistance);
    }
}
