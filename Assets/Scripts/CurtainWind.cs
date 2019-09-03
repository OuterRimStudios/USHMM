using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class CurtainWind : MonoBehaviour
{
    public Cloth curtain;
    public CapsuleCollider[] colliders;
    public float minSpeed;
    public float maxSpeed;
    public float moveDist;
    float speed;
    Vector3 targetPos;

    private void Start()
    {
        curtain.capsuleColliders = colliders;
        speed = Random.Range(minSpeed, maxSpeed);
        StartCoroutine(Gust());
    }

    IEnumerator Gust()
    {
        targetPos = transform.position + (transform.forward * moveDist);
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(MoveColliders);
    }

    bool MoveColliders()
    {
        if (MathUtilities.CheckDistance(transform.position, targetPos) < 0.1f)
            return true;
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            return false;
        }
    }
}