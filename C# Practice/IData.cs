interface IData<T> {
    void Add(T t);
    T this[int index] { get; set; }
    void Insert(int index, T t);
    T GetElement(int index);
    void Locate(T t);
    void RemoveAt(int index);
    void Clear();
}
