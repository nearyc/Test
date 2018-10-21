using System.Collections.Generic;
namespace Practice.Collections {
    public interface IHashtable<TKey, TValue> {
        // void RemoveKeyValue(TKey k, TValue v);
        IEnumerable<TValue> GetElement(TKey k);
        IEnumerable<TValue> this[TKey k] { get; }
    }

}
