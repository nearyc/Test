using System;
using System.Collections;
using System.Collections.Generic;
namespace Practice.Collections {
    /// <summary>
    /// 优先队列,无限
    /// </summary>
    /// <typeparam name="P">优先级别</typeparam>
    /// <typeparam name="V">值</typeparam>
    public class PriorityQueue<P, V> : IEnumerable<PQNode<P, V>> where P : IComparable {
        private int _count;
        private PQNode<P, V> _head; //队首
        public int Count => _count; //node数量

        public void Enqueue(P priority, V value) {
            var newNode = new PQNode<P, V>(priority, value);
            //队列为空
            if (_head == null) {
                _head = newNode;
                ++_count;
            }
            //队列不为空
            else {
                var temp = _head; //默认head的优先级最高
                var preTemp = _head; //待比较的前一位
                preTemp = null;
                //! 比较优先级大小，如果没有大于待比较的节点，则后移继续比较
                //! 直到找到优先级较小的，插入到前一位 例如 2-2-2-0,插入1后为2-2-2-(1)-0
                while (!ComparePriority(newNode, temp)) {
                    preTemp = temp;
                    temp = temp.next;
                }
                newNode.next = temp;
                //! 判断是否在队头插入
                if (preTemp != null) {
                    preTemp.next = newNode;
                }
                else {
                    _head = newNode;
                }
                ++_count;
            }
        }
        /// <summary>
        /// 比较两个节点的优先级
        /// </summary>
        /// <param name="first">第一个</param>
        /// <param name="second">第二个</param>
        /// <returns>第一个的优先级是否比第二个大</returns>
        private bool ComparePriority(PQNode<P, V> first, PQNode<P, V> second) {
            if (first == null && second == null) throw new Exception("....");
            if (second == null) return true;
            if (first == null) return false;

            var compareValue = first.priority.CompareTo(second.priority);
            if (compareValue == 1) return true;
            return false;
        }
        public V Dequeue() {
            //Todo Check Null
            var temp = _head;
            _head = _head.next;
            --_count;
            return temp.value;
        }

        public V Front() {
            //Todo Check Null
            return _head.value;
        }
        public IEnumerable<V> SHow() {
            var returnList = new List<V>();
            var temp = _head;
            while (temp != null) {
                returnList.Add(temp.value);
            }
            return returnList;
        }
        public IEnumerable<PQNode<P, V>> SHowAllNodes() {
            var returnList = new List<PQNode<P, V>>();
            var temp = _head;
            while (temp != null) {
                returnList.Add(temp);
                temp = temp.next;
            }
            return returnList;
        }

        public IEnumerator<PQNode<P, V>> GetEnumerator() {
            var temp = _head;
            while (temp != null) {
                yield return temp;
                temp = temp.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            var temp = _head;
            while (temp != null) {
                yield return temp;
                temp = temp.next;
            }
        }
    }
}
