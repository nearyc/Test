using System;
using System.Collections;
using System.Collections.Generic;

namespace Practice.Collections {
    /// <summary>
    /// 二叉堆，没有键值对对应（也可以做成Priority/Value对应的）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MybinaryHeap<T> : IEnumerable<T>, IBinaryTree<T> where T : IComparable {
        private HeapNode<T> _root; //根节点，默认为最大
        private List<HeapNode<T>> _container;
        public int Count { get; private set; }
        public MybinaryHeap() {
            _root = null;
            Count = 0;
            _container = new List<HeapNode<T>>();
        }
        /// <summary>
        /// 添加值
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value) {
            var newNode = new HeapNode<T>(value);
            Count++;
            newNode.index = Count - 1;
            _container.Add(newNode);
            // _container[newNode.index] = newNode;

            if (_root == null) {
                _root = newNode;
            }
            else {
                var parent = _container[(int) Math.Ceiling(System.Convert.ToDouble(Count) / 2) - 1];
                newNode.parent = parent;
                if (Count % 2 == 0) {
                    //偶数，则添加到左节点
                    parent.left = newNode;
                }
                else {
                    //奇数，则添加到右节点
                    parent.right = newNode;
                }
                CompareToParent(newNode);
            }
        }
        private void CompareToParent(HeapNode<T> child) {
            if (child == _root) return;
            var compareResult = child.value.CompareTo(child.parent.value);
            if (compareResult == 1) {
                SwitchValue(child, child.parent);
                CompareToParent(child.parent);
            }
        }
        private void SwitchValue(HeapNode<T> first, HeapNode<T> second) {
            var temp = first.value;
            first.value = second.value;
            second.value = temp;
        }
        /// <summary>
        /// 取出最大值
        /// </summary>
        /// <returns></returns>
        public T Pop() {
            var temp = _root.value;
            var lastNode = _container[Count - 1];
            _root.value = lastNode.value;
            var lastNodeParent = lastNode.parent; //最后一个节点的parent
            if (lastNodeParent == null) {
                //为根节点
                return temp;
            }
            else {
                if (lastNodeParent.left == lastNode) lastNodeParent.left = null;
                if (lastNodeParent.right == lastNode) lastNodeParent.right = null;
            }

            _container.Remove(lastNode);
            Count--;
            CompareToChildren(_root);

            return temp;
        }
        private void CompareToChildren(HeapNode<T> parent) {
            if (parent.left == null) return;

            HeapNode<T> toSwitchNode = parent.left;
            if (parent.right != null) {
                var compareResultForChildren = parent.left.value.CompareTo(parent.right.value);
                if (compareResultForChildren == -1) {
                    toSwitchNode = parent.right;
                }
            }
            var compareResult = parent.value.CompareTo(toSwitchNode.value);

            if (compareResult == 1) return;

            SwitchValue(parent, toSwitchNode);
            CompareToChildren(toSwitchNode);

        }
        /// <summary>
        /// 取得最大值
        /// </summary>
        /// <returns></returns>
        public T Top() {
            //TODO Check if root is null;
            return _root.value;
        }
        #region IEnumerable
        public IEnumerator<T> GetEnumerator() {
            for (int i = 0; i < _container.Count; i++) {
                yield return _container[i].value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            for (int i = 0; i < _container.Count; i++) {
                yield return _container[i].value;
            }
        }
        #endregion
    }
}
