using System;
namespace Practice.Collections {
    /// <summary>
    /// 链式队列，无限/有限
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class MyLinkedQueue<T> : IQueue<T> {
        private MyNode<T> _head;
        private MyNode<T> _tail;
        private int _headPointer; //可以不需要
        private int _tailPointer; //可以不需要
        private readonly int _maxCount;
        public int MaxCount => _isInfinite? - 1 : _maxCount;
        private bool _isInfinite;
        public MyLinkedQueue() {
            _isInfinite = true;
            _headPointer = -1;
            _tailPointer = -1;
            _maxCount = 0;
            _head = null;
            _tail = null;
        }
        public MyLinkedQueue(int maxCount) {
            _isInfinite = false;
            _maxCount = maxCount;
            _headPointer = -1;
            _tailPointer = -1;
            _head = null;
            _tail = null;
        }
        public int Count => _tailPointer - _headPointer + _maxCount;
        protected virtual MyNode<T> CreateNewNode(T value) {
            return new MyNode<T>(value);
        }
        public bool Enqueue(T value) {
            var newNode = CreateNewNode(value);
            if (_head == null) {
                _head = _tail = newNode;
                _tailPointer++;
                PrintInfo();
                return true;
            }
            else {
                //无限队列
                if (_isInfinite) {
                    _tail.next = newNode;
                    _tail = newNode;
                    _tailPointer++;
                    PrintInfo();
                    return true;
                }
                //有限队列
                else {
                    // 不循环队列
                    // // TODO 循环队列
                    if (Count < MaxCount) {
                        _tail.next = newNode;
                        _tail = newNode;
                        _tailPointer++;
                        PrintInfo();
                        return true;
                    }
                    else {
                        // queue is full doNothing
                        return false;
                    }
                }
            }
        }
        private void PrintInfo() {
            Console.WriteLine($"tail: {_tailPointer }, head: {_headPointer}, count: " + Count);
        }
        public T Dequeue() {
            var temp = _head;
            //todo if _head ==null then ...
            _head = _head.next;
            if (_head == null) {
                //队列中没有元素了重置队列,也可以用_headP==_tailP判断
                _headPointer = -1;
                _tailPointer = -1;
            }
            else {
                _headPointer++;
            }
            PrintInfo();
            return temp.value;
        }

        public T Front() {
            //todo if _head ==null then ...
            return _head.value;
        }
    }
}
