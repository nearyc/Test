using System;

namespace Practice.Collections {
    public interface IBinaryTree<T> where T : IComparable {
        void Add(T value);
        T Pop();
        T Top();

    }
}
