public class PlayerControllerRadiusObjectFinderFactory : ObjectFinderFactory<ExplosionCollisionContext, PlayerController>
{
    public ObjectFinder<ExplosionCollisionContext, PlayerController> Create()
    {
        return new PlayerControllerRadiusObjectFinder(new RadiusObjectFinder(), new ComponentGameObjectConverter<PlayerController>());
    }
}
