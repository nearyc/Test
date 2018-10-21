using System;
namespace Practice.Collections {
    public class PQNode<P, V> where P : IComparable {
        public P priority;
        public V value;
        public PQNode<P, V> next;
        public PQNode(P priority, V value) {
            this.priority = priority;
            this.value = value;
            this.next = null;
        }
    }
}
