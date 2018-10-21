namespace Practice.Collections {
    public interface IQueue<T> {
        int Count { get; }
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Enqueue(T value);
        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        T Dequeue();
        /// <summary>
        /// 取顶
        /// </summary>
        /// <returns></returns>
        T Front();
    }
}
