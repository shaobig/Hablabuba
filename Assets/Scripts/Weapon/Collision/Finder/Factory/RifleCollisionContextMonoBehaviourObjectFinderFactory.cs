using UnityEngine;

public class RifleCollisionContextMonoBehaviourObjectFinderFactory<E> : ObjectFinderFactory<RifleCollisionContext, E> where E: MonoBehaviour
{
    private string tag;

    public RifleCollisionContextMonoBehaviourObjectFinderFactory(string tag)
    {
        this.tag = tag;
    }

    public ObjectFinder<RifleCollisionContext, E> Create()
    {
        return new MonoBehaviourObjectFinderFactory<RifleCollisionContext, E>(new TagGameObjectFinder(tag)).Create();
    }
    
}
