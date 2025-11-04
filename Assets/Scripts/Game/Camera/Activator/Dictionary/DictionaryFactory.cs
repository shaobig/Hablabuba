using System.Collections.Generic;

public interface DictionaryFactory<k, V>
{
    Dictionary<k, V> Create();
}
