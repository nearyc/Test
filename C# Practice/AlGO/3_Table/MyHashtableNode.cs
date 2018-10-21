using System;
namespace Practice.Collections {
    public class MyHashtableNode<TKey, TValue> {
        public int? hashCode;
        public TKey key;
        public TValue value;
        public MyHashtableNode<TKey, TValue> next;
        public MyHashtableNode(TKey key, TValue value) : this(key, value, null) {

        }
        public MyHashtableNode(TKey key, TValue value, MyHashtableNode<TKey, TValue> next) {
            this.key = key;
            this.value = value;
            this.next = next;
        }
        public void SethashCode(Func<TKey, int> hashFunction) {
            hashCode = hashFunction(this.key);
        }
    }
}
