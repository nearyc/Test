interface IQueue<T> {
    void Enqueue(T t);
    T Dequeue();
    T Peek();
    void Clear();

}
