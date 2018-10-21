using System;

namespace Practice.Collections {
    public class HeapNode<T> where T : IComparable {
        public int index;
        public T value;
        public HeapNode<T> left;
        public HeapNode<T> right;
        public HeapNode<T> parent;

        public HeapNode(T value) {
            this.value = value;
        }
    }
}
