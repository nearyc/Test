using System;
namespace Practice.Collections {
    /// <summary>
    /// 循环队列
    /// </summary>
    public class MyCircularQueue<T> : IQueue<T> {
        private MyNode<T> _head;
        private MyNode<T> _tail;
        private int _count;
        public readonly int maxCount;
        public int Count => _count;
        public MyCircularQueue(int maxCount) {
            this.maxCount = maxCount;
        }
        protected virtual MyNode<T> CreateNewNode(T value) {
            return new MyNode<T>(value);
        }
        public bool Enqueue(T value) {
            var newNode = CreateNewNode(value);
            if (_head == null) {
                _head = _tail = newNode;
            }
            if (_count < maxCount) {
                _tail.next = newNode;
                _tail = newNode;
                _count++;
            }
            else {
                _tail.next = newNode;
                _tail = newNode;

                _tail.next = _head.next;
                _head = _head.next;
            }
            PrintInfo();
            return true;
        }
        private void PrintInfo() {
            Console.WriteLine($" count: " + Count);
        }
        public T Dequeue() {
            var temp = _head;
            _tail.next = null;
            //todo if _head ==null then ...
            _head = temp.next;
            _count--;
            PrintInfo();
            return temp.value;
        }

        public T Front() {
            //todo if _head ==null then ...
            return _head.value;
        }
    }
}
