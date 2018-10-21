namespace Practice.Collections {
    public class MyNode<T> {
        public T value;
        public MyNode<T> next;

        public MyNode(T value) {
            this.value = value;
            next = null;
        }
    }
}
