using System.Collections.Generic;

public interface ObjectFinder<C, O> where C: CollisionContext
{
    List<O> Find(C context);
}
