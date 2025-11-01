using System.Collections.Generic;
using UnityEngine;

public class TagGameObjectFinder : ObjectFinder<RifleCollisionContext, GameObject>
{
    private string tag;

    public TagGameObjectFinder(string tag)
    {
        this.tag = tag;
    }

    public List<GameObject> Find(RifleCollisionContext context)
    {
        return context.HitObject.CompareTag(tag) ? new() { context.HitObject } : new();
    }
    
}
