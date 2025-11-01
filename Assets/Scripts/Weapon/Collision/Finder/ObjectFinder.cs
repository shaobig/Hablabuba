using System.Collections.Generic;

public interface ObjectFinder<C, E> where C: CollisionContext
{
    List<E> Find(C context);
}
