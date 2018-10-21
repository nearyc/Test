namespace Practice.Collections {
    public class MySequenceStack<T> : IStack<T> {
        /// <summary>
        /// 栈
        /// </summary>
        private T[] _container;
        private readonly bool _isInfinite;
        private int _pointerIndex;
        public int Count => _pointerIndex;
        public MySequenceStack(int count) {
            _container = new T[count];
            _isInfinite = false;
            _pointerIndex = -1;
        }
        public MySequenceStack() {
            _container = new T[4];
            _isInfinite = true;
            _pointerIndex = -1;
        }
        private void ExpandContainer(ref T[] container) {
            var tempArr = container;
            container = new T[container.Length * 2];
            tempArr.CopyTo(container, 0);
        }

        public bool Push(T t) {
            if (_isInfinite) {
                if (_pointerIndex >= _container.Length - 1) {
                    ExpandContainer(ref _container);
                }
                _pointerIndex++;
                _container[_pointerIndex] = t;
                return true;
            }
            else {
                if (_pointerIndex < _container.Length - 1) {
                    _pointerIndex++;
                    _container[_pointerIndex] = t;
                    return true;
                }
                return false;
            }
        }
        public T Pop() {
            var temp = _container[_pointerIndex];
            _pointerIndex--;
            return temp;
        }

        public T Peak() {
            return _container[_pointerIndex];
        }
    }
}
