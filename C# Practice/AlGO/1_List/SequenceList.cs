namespace Practice.Collections {
    public class SequenceList<T> : IList<T> {
        private T[] _container;
        private int _count;

        public int Count => _count;
        public T this[int index] {
            get =>
                throw new System.NotImplementedException();
            set =>
                throw new System.NotImplementedException();
        }

        public void Add(T t) {
            throw new System.NotImplementedException();
        }

        public int FindIndexFirstMatch(T t) {
            throw new System.NotImplementedException();
        }

        public T GetElement(int index) {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, T t) {
            throw new System.NotImplementedException();
        }

        public void Remove(T t) {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index) {
            throw new System.NotImplementedException();
        }
    }
}
