using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class Interactable : MonoBehaviour
{
    public List<Interaction> interactions;

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

        foreach (Interaction interaction in interactions)
            interaction.Interact();
    }

    public virtual void Update()
    {
        if (!useProximity) return;
        CheckProximity();
    }

    public virtual void CheckProximity()
    {
        InProximity = MathUtilities.CheckDistance(Player.position, transform.position) < proximityDistance;
    }

    public virtual void Reset()
    {
        if (isRepeatable)
        {
            Triggered = false;

            foreach (Interaction interaction in interactions)
                interaction.Reset();
        }
    }

    private void OnDrawGizmos()
    {
        if(useProximity)
            Gizmos.DrawWireSphere(transform.position, proximityDistance);
    }
}
