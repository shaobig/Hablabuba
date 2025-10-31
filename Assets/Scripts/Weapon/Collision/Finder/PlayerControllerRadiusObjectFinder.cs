using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerControllerRadiusObjectFinder : ObjectFinder<ExplosionCollisionContext, PlayerController>
{
    private ObjectFinder<ExplosionCollisionContext, GameObject> gameObjectFinder;
    private GameObjectConverter<PlayerController> gameObjectConverter;

    public PlayerControllerRadiusObjectFinder(ObjectFinder<ExplosionCollisionContext, GameObject> gameObjectFinder, GameObjectConverter<PlayerController> gameObjectConverter)
    {
        this.gameObjectFinder = gameObjectFinder;
        this.gameObjectConverter = gameObjectConverter;
    }

    public List<PlayerController> Find(ExplosionCollisionContext context)
    {
        return gameObjectFinder.Find(context)
            .Select(gameObject => gameObjectConverter.Convert(gameObject))
            .Where(player => player != null)
            .ToList();
    }
    
}
