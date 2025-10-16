using System.Collections.Generic;
using UnityEngine;

public interface DatabaseReader<E> where E : ScriptableObject
{
    List<E> ReadDatabase();
}
