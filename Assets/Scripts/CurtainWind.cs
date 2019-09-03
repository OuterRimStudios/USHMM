using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class CurtainWind : MonoBehaviour
{
    public Cloth curtain;
    public CapsuleCollider[] colliders;
    public AudioSource source;
    public float minSpeed;
    public float maxSpeed;
    public float moveDist;
    float speed;
    Vector3 targetPos;

    void OnEnable()
    {
        CurtainEvent.OnGust += StartGust;
    }

    void OnDisable()
    {
        CurtainEvent.OnGust -= StartGust;
    }

    private void Start()
    {
        curtain.capsuleColliders = colliders;
        foreach (CapsuleCollider collider in colliders)
            collider.transform.rotation = Random.rotation;
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void StartGust()
    {

        StartCoroutine(Gust());
    }

    IEnumerator Gust()
    {
        targetPos = transform.position + (transform.forward * moveDist);
        source.Play();
        yield return new WaitUntil(MoveColliders);
        source.Stop();
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