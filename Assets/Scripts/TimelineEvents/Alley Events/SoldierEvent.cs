using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class SoldierEvent : Interaction
{
    public float speed;
    public Transform targetToMove;
    public Transform targetLocation;

    public override void Interact()
    {
        Debug.Log("Soldier Event Started");
        targetToMove.gameObject.SetActive(true);
        StartCoroutine(MoveToPosition());
    }

    IEnumerator MoveToPosition()
    {
        yield return new WaitUntil(() => InPosition());
        targetToMove.gameObject.SetActive(false);
    }

    bool InPosition()
    {
        targetToMove.localPosition = Vector3.MoveTowards(targetToMove.localPosition, targetLocation.localPosition, speed * Time.deltaTime);
        return MathUtilities.CheckDistance(targetToMove.localPosition, targetLocation.localPosition) <= .5f;
    }
}
