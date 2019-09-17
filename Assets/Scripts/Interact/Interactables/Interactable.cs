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

    public float TotalTimeInProximity { get; protected set; }
    float timeOfEnterProximity;

    public virtual void Start()
    {
        if (useProximity)
            Player = Camera.main.transform;
    }

    public virtual void Interact()
    {
        if(!isRepeatable)
            Triggered = true;

        foreach (Interaction interaction in interactions)
            interaction.Interact();
    }

    public virtual void StopInteract()
    {
        foreach (Interaction interaction in interactions)
            interaction.StopInteraction();
    }

    public virtual void Update()
    {
        if (!useProximity) return;
        CheckProximity();
    }

    public virtual void CheckProximity()
    {
        InProximity = MathUtilities.CheckDistance(Player.position, transform.position) < proximityDistance;
        if (InProximity && timeOfEnterProximity == 0)
        {
            timeOfEnterProximity = Time.timeSinceLevelLoad;
        }
        if (!InProximity && timeOfEnterProximity > 0)
        {
            timeOfEnterProximity = 0;
            InteractionManager.inProximityCount++;
        }

        if (InProximity)
            InteractionManager.totalTimeInProximity += Time.deltaTime;
    }

    public virtual float GetTotalTimeInProximity()
    {
        return TotalTimeInProximity;
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
        if (useProximity)
            Gizmos.DrawWireSphere(transform.position, proximityDistance);
    }
}
