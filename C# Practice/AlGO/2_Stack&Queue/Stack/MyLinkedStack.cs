namespace Practice.Collections {
    /// <summary>
    /// 链式栈
    /// </summary>
    public class MyLinkedStack<T> : IStack<T> {
        //TODo isInfinite??
        private MyNode<T> _tail;
        private readonly bool _isInfinite;
        private int _pointerIndex;
        public int Count => _pointerIndex;
        public MyLinkedStack() {
            _tail = null;
            _isInfinite = true;
            _pointerIndex = 0;
        }
        protected virtual MyNode<T> CreateNewNode(T value) {
            return new MyNode<T>(value);
        }
        public bool Push(T value) {
            var newNode = CreateNewNode(value);
            newNode.next = _tail;
            _tail = newNode;
            _pointerIndex++;
            return true;
        }
        public T Pop() {
            var temp = _tail;
            if (temp != null) {
                _pointerIndex--;
                _tail = _tail.next;
            }
            //TODO if temp ==null then ____
            return temp.value;
        }

        public T Peak() {
            //TODO if tail ==null then ____
            return _tail.value;
        }
    }
}
