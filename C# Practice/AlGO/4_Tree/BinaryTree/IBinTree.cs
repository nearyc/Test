using System.Collections.Generic;
namespace Practice.Collections {
    public interface IBinTree<T> {
        int Count { get; }
        bool IsEmpty { get; }
        void Add(T value);
        BinTreeNode<T> Root { get; }
        IEnumerable<T> PreTraversal(BinTreeNode<T> node);
        IEnumerable<T> InTraversal(BinTreeNode<T> node);
        IEnumerable<T> PostTraversal(BinTreeNode<T> node);
        IEnumerable<T> LevelTravesal(BinTreeNode<T> node);
    }

}
