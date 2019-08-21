using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class DocumentsEvent : Event
{
    public float minSpawnTime;
    public float maxSpawnTime;

    public List<Sprite> images;
    public List<Frame> frames;
    public List<Transform> endPoints;

    private void Start()
    {
        CollectionUtilities.Shuffle(images);
        for (int i = 0; i < frames.Count; i++)
        {
            frames[i].spriteRenderer.sprite = images[i];
            frames[i].curvedMovement.endPosition = endPoints[i];
            frames[i].transform.SetParent(endPoints[i]);
        }
    }

    public override void StartEvent()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        foreach(Frame frame in frames)
        {
            frame.curvedMovement.enabled = true;
            frame.grow.enabled = true;
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }

    public override void StopEvent()
    {
        base.StopEvent();
    }
}
