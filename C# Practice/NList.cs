namespace Csharp_Practice {
    public class NList<T> {
        private T[] array;
        private int count;
        public int Count {
            get { return count; }
        }
        public NList(int size) {
            array = new T[size];
            count = size;
        }
        public NList() {
            array = new T[0];
            count = 0;
        }
        private void HandleArraySpace(int index) {
            if (index <= array.Length - 1) {
                return;
            } else {
                int len = array.Length * 2;
                T[] array2 = new T[len];
                array.CopyTo(array2, 0);
                array = array2;
                HandleArraySpace(index);
            }
        }
        public T this [int index] {
            get { return array[index]; }
            set { Insert(value, index); }
        }
        public bool Contains(T t) {
            foreach (T obj in array) {
                if (obj.Equals(t)) {
                    return true;
                }
            }
            return false;
        }
        public void Add(T t) {
            if (count == 0) array = new T[4];
            HandleArraySpace(count);
            array[count] = t;
            count++;
        }
        public void Insert(T t, int index) {
            HandleArraySpace(index);
            for (int i = count; i <= index + 1; i--) {
                array[i] = array[i - 1];
            }
            array[index] = t;
            count++;
        }
        public void RemoveAt(int index) {
            if (count - 1 < index || index < 0) throw new System.Exception("Out of Index !");
            for (int i = index; i <= count - 2; i++) {
                array[i] = array[i + 1];
            }
            array[count - 1] = default(T);
            count--;
        }
        public void Remove(T t) {
            bool isContainsValue = false;
            int a = count;
            for (int i = a - 1; i >= 0; i--) {
                if (array[i].Equals(t)) {
                    System.Console.WriteLine("remove    " + i + "    " + count);
                    RemoveAt(i);
                    isContainsValue = true;
                    // count--;
                }
            }
            if (!isContainsValue) {
                throw new System.Exception("Not Contains!");
            }
        }
        public void Clear() {
            array = new T[0];
            count = 0;
        }
    }
}