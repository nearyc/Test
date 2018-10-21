using System;
using System.Collections;
using System.Collections.Generic;
namespace Practice.Collections {
    /// <summary>
    /// 哈希表/散列表
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class MyHashtable<TKey, TValue> : IEnumerable<MyHashtableNode<TKey, TValue>>, IDictionary<TKey, TValue>, IHashtable<TKey, TValue> {
        private readonly Func<TKey, int> _hashFunction;
        private readonly MyHashtableNode<TKey, TValue>[] _heads;

        /// <param name="hashFunction">哈希函数</param>
        /// <param name="range">哈希函数得取值范围</param>
        public MyHashtable(Func<TKey, int> hashFunction, int range) {
            this._hashFunction = hashFunction;
            _heads = new MyHashtableNode<TKey, TValue>[range];
        }
        /// <summary>
        /// 默认的哈希函数为余13
        /// </summary>
        public MyHashtable() : this((k) => System.Convert.ToInt32(k) % 13, 13) {

        }
        public IEnumerable<TValue> this[TKey k] => GetElement(k);
        /// <summary>
        /// 添加键值对
        /// </summary>
        /// <param name="k"></param>
        /// <param name="v"></param>
        public void Add(TKey k, TValue v) {
            var newNode = new MyHashtableNode<TKey, TValue>(k, v);
            newNode.SethashCode(_hashFunction);
            if (_heads[newNode.hashCode.Value] == null) {
                _heads[newNode.hashCode.Value] = newNode;
            }
            else {
                var nodePointer = _heads[newNode.hashCode.Value];
                while (nodePointer.next != null) {
                    nodePointer = nodePointer.next;
                }
                nodePointer.next = newNode;
            }
        }
        /// <summary>
        /// 判断是否存在key
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey k) {
            var hashCode = _hashFunction(k);
            if (_heads[hashCode] == null) {
                return false;
            }
            else {
                return true;
            }
        }
        /// <summary>
        /// 判断是否存在value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue(TValue value) {
            foreach (var head in _heads) {
                var serchResult = Search(head, value);
                if (serchResult) {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 根据Value寻找是否存在等值node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool Search(MyHashtableNode<TKey, TValue> node, TValue value) {
            var nodePointer = node;
            while (nodePointer != null) {
                if (nodePointer.value.Equals(value)) {
                    return true;
                }
                else {
                    nodePointer = nodePointer.next;
                }
            }
            return false;
        }
        /// <summary>
        /// 根据Key得到Value组
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public IEnumerable<TValue> GetElement(TKey k) {
            var head = _heads[_hashFunction(k)];
            if (head == null) {
                return null;
            }
            else {
                var newlist = new List<TValue>();
                var nodePointer = head;
                do {
                    newlist.Add(nodePointer.value);
                    nodePointer = nodePointer.next;
                } while (head.next != null);
                return newlist;
            }
        }
        /// <summary>
        /// 移除Key对应的所有Value
        /// </summary>
        /// <param name="k"></param>
        public void RemoveKey(TKey k) {
            var head = _heads[_hashFunction(k)];
            if (head != null) {
                _heads[_hashFunction(k)] = null;
            }
        }
        /// <summary>
        /// 移除Value
        /// </summary>
        /// <param name="v"></param>
        public void RemoveValue(TValue v) {
            foreach (var head in _heads) {
                var nodePointer = head;
                var prePointer = default(MyHashtableNode<TKey, TValue>);
                prePointer.next = nodePointer;

                while (nodePointer != null) {
                    if (nodePointer.value.Equals(v)) {
                        prePointer.next = nodePointer.next;
                        nodePointer = null;
                    }
                    else {
                        prePointer = prePointer.next;
                        nodePointer = nodePointer.next;
                    }
                }
            }
        }
        #region IEnumerable

        public IEnumerator<MyHashtableNode<TKey, TValue>> GetEnumerator() {
            foreach (var head in _heads) {
                var node = head;
                while (node != null) {
                    yield return node;
                    node = node.next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            foreach (var head in _heads) {
                var node = head;
                while (node != null) {
                    yield return node;
                    node = node.next;
                }
            }
        }
        #endregion
    }
}
