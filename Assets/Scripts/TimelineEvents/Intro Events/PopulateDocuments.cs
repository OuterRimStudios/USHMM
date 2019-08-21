using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OuterRimStudios.Utilities;

public class PopulateDocuments : MonoBehaviour
{
    public List<Sprite> images;
    public List<SpriteRenderer> renderers;
    public List<LookAt> lookAts;

    private void Start()
    {
        CollectionUtilities.Shuffle(images);
        for(int i = 0; i < renderers.Count; i++)
        {
            renderers[i].sprite = images[i];
        }
    }

    public void EnableLookAt()
    {
        foreach (LookAt look in lookAts)
            look.enabled = true;
    }
}
