namespace Practice.Collections {
    public interface IDictionary<TKey, TValue> {
        void Add(TKey k, TValue v);
        void RemoveKey(TKey k);
        void RemoveValue(TValue v);
        bool ContainsKey(TKey k);
        bool ContainsValue(TValue value);
        // TValue GetElement(TKey k);
        //TValue this[TKey k] { get; set; }
    }

}
