using System.Collections.Generic;
using System.Linq;

namespace Practice.Collections {
    public interface ITree<T> {
        void Add(T value);
        T Get(T value);
        T Remove(T value);
        //  void RemoveAt(int index);
        // void Insert(int parentIndex, T value);
    }

    /// <summary>
    /// 树节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T> {
        public int Height { get; set; }
        public T value;
        public TreeNode<T> parent;
        private readonly List<TreeNode<T>> _nodes;

        public virtual List<TreeNode<T>> Nodes => _nodes;
        public TreeNode(T value) {
            this.value = value;
            this.parent = null;
            this._nodes = new List<TreeNode<T>>();
        }
        public TreeNode() : this(default(T)) {

        }
    }

}
