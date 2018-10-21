using System;
using System.Collections;
using System.Collections.Generic;
namespace Practice.Collections {
    /// <summary>
    /// 链式二叉树
    /// </summary>

    public class BinTree<T> : IBinTree<T>, IEnumerable<T> {
        private BinTreeNode<T> _lastInsert;
        protected int _count;
        protected BinTreeNode<T> _root;
        public int Count => _count;
        public bool IsEmpty => _count > 0;
        public BinTreeNode<T> Root => _root;
        /// <summary>
        ///? 优先排满一层 的添加
        /// </summary>
        public virtual void Add(T value) {
            var newNode = new BinTreeNode<T>(value);
            if (_root == null) {
                _root = newNode;
            }
            else {
                InsertAtLastNearby(newNode);
            }
            ++_count; // 数量增加
            _lastInsert = newNode; // 记录为最后一次插入的节点
            UpdateHeight(newNode); // 更新高度
        }
        /// <summary>
        ///? 更新高度
        /// </summary>
        protected void UpdateHeight(BinTreeNode<T> node) {
            if (node == null) return;
            var orignHeight = node.height;
            node.UpdateHeight();
            if (node.height != orignHeight) {
                UpdateHeight(node.parent);
            }
        }
        #region OrderTraversal
        /// <summary>
        ///? 中序遍历 L-P-R
        /// </summary>
        public IEnumerable<T> InTraversal(BinTreeNode<T> node) {
            var nodeStack = new Stack<BinTreeNode<T>>();
            var nodeList = new List<BinTreeNode<T>>();
            var returnList = new List<T>();
            while (true) {
                // 沿着左路一直走到底，沿途添加node到stack中
                InTraverAlongLeft(node, ref nodeStack);
                // 如果stack中没有元素，跳出循环
                if (nodeStack.Count <= 0) break;
                node = nodeStack.Pop();
                // 如果左侧元素为空或者已经被访问，则访问该元素，否则将TraverAlongLeft
                if (node.left == null || node.left.isVisited) {
                    InTraverVisit(node, ref nodeStack, ref nodeList);
                }
            }
            foreach (var item in nodeList) {
                item.isVisited = false;
                returnList.Add(item.value);
            }
            return returnList;
        }
        private void InTraverAlongLeft(BinTreeNode<T> node, ref Stack<BinTreeNode<T>> nodeStack) {
            while (node.isVisited == false) {
                nodeStack.Push(node);
                if (node.left != null && !node.left.isVisited)
                    node = node.left;
                else break;
            }
        }
        private void InTraverVisit(
            BinTreeNode<T> node, ref Stack<BinTreeNode<T>> nodeStack, ref List<BinTreeNode<T>> nodeList) {
            if (node.right != null) {
                nodeStack.Push(node.right);
            }
            nodeList.Add(node);
            node.isVisited = true;
        }
        /// <summary>
        ///? 先序遍历 P-L-R
        /// </summary>
        public IEnumerable<T> PreTraversal(BinTreeNode<T> node) {
            var nodeStack = new Stack<BinTreeNode<T>>();
            var returnList = new List<T>();
            nodeStack.Push(node);
            while (nodeStack.Count > 0) {
                node = nodeStack.Pop();
                PreTraverVisit(node, ref nodeStack);
                returnList.Add(node.value);
            }
            return returnList;
        }
        private void PreTraverVisit(
            BinTreeNode<T> node, ref Stack<BinTreeNode<T>> nodeStack) {
            if (node.right != null) nodeStack.Push(node.right);
            if (node.left != null) nodeStack.Push(node.left);
        }
        /// <summary>
        ///? 后序遍历 L-R-P
        /// </summary>
        public IEnumerable<T> PostTraversal(BinTreeNode<T> node) {
            var nodeStack = new Stack<BinTreeNode<T>>();
            var nodeList = new List<BinTreeNode<T>>();
            var returnList = new List<T>();
            while (true) {
                // 沿着左路一直走到底，沿途添加node到stack中
                PostTraverAlongLeft(node, ref nodeStack);
                // 如果stack中没有元素，跳出循环
                if (nodeStack.Count <= 0) break;
                node = nodeStack.Pop();
                // 如果左侧元素为空或者已经被访问，则访问该元素，否则将TraverAlongLeft
                if (node.left == null || node.left.isVisited) {
                    PostTraverVisit(node, ref nodeStack, ref nodeList);
                }
            }
            foreach (var item in nodeList) {
                item.isVisited = false;
                returnList.Add(item.value);
            }
            return returnList;
        }
        private void PostTraverAlongLeft(BinTreeNode<T> node, ref Stack<BinTreeNode<T>> nodeStack) {
            while (node.isVisited == false) {
                nodeStack.Push(node);
                if (node.right != null && !node.right.isVisited)
                    nodeStack.Push(node.right);
                if (node.left != null && !node.left.isVisited)
                    node = node.left;
                else break;
            }
        }
        private void PostTraverVisit(
            BinTreeNode<T> node, ref Stack<BinTreeNode<T>> nodeStack, ref List<BinTreeNode<T>> nodeList) {
            nodeList.Add(node);
            node.isVisited = true;
        }
        /// <summary>
        ///? 层次遍历 
        /// </summary>
        public IEnumerable<T> LevelTravesal(BinTreeNode<T> node) {
            var nodeQueue = new Queue<BinTreeNode<T>>();
            var returnList = new List<T>();
            nodeQueue.Enqueue(node);
            while (nodeQueue.Count > 0) {
                node = nodeQueue.Dequeue();
                if (node != null) returnList.Add(node.value);
                if (node.left != null) nodeQueue.Enqueue(node.left);
                if (node.right != null) nodeQueue.Enqueue(node.right);
            }

            return returnList;
        }

        #endregion
        #region GenericInsert
        /// <summary>
        ///? 从根节点开始的 先父 次左 后右 的链式的插入很麻烦
        /// </summary>
        private bool InsertPLR(BinTreeNode<T> parent, BinTreeNode<T> newNode, ref Queue<BinTreeNode<T>> nodeQueue) {
            var insertResult = false;

            nodeQueue.Enqueue(parent.left);
            nodeQueue.Enqueue(parent.right);

            //! 尝试插入
            insertResult = newNode.SetNewParent(parent); //尝试插入到parent，调用node中的SetParent
            if (insertResult == true) {
                return true;
            }
            //! 插入失败，则尝试插入其子节点
            else {
                while (!insertResult) {
                    var toInsertNode = nodeQueue.Dequeue();
                    //递归调用 尝试插入节点，调用node中的SetParent
                    insertResult = InsertPLR(toInsertNode, newNode, ref nodeQueue);
                }
                return insertResult;
            }
        }
        /// <summary>
        ///? 在最后一次插入节点的附近寻找空节点插入
        /// </summary>
        private void InsertAtLastNearby(BinTreeNode<T> newNode) {
            //! 上一次插入的节点可能被删除了
            var nodeQueue = new Queue<BinTreeNode<T>>();
            if (_lastInsert == null || _lastInsert == _root) {
                InsertPLR(_root, newNode, ref nodeQueue);
                return;
            }
            var toInsert = _lastInsert.GetSibling();
            //! toInsert 为空，可以插入
            if (toInsert == null) {
                InsertPLR(_lastInsert.parent, newNode, ref nodeQueue);
                return;
            }
            else {
                //! 上一次插入节点的父节点满了
                if (_lastInsert.parent.parent == null) {
                    InsertPLR(_root, newNode, ref nodeQueue);
                    return;
                }
                toInsert = _lastInsert.parent.GetSibling();
                if (toInsert == null) {
                    InsertPLR(_lastInsert.parent.parent, newNode, ref nodeQueue);
                    return;
                }
                else {
                    //! 上一次插入节点的兄弟节点也满了,不妨从根节点开始
                    InsertPLR(_root, newNode, ref nodeQueue);
                    return;
                }
            }
        }

        #endregion
        #region IEnumerator

        public IEnumerator<T> GetEnumerator() {
            var node = _root;
            var nodeStack = new Stack<BinTreeNode<T>>();
            var nodeList = new List<BinTreeNode<T>>();
            while (true) {
                // 沿着左路一直走到底，沿途添加node到stack中
                InTraverAlongLeft(node, ref nodeStack);
                // 如果stack中没有元素，跳出循环
                if (nodeStack.Count <= 0) break;
                node = nodeStack.Pop();
                // 如果左侧元素为空或者已经被访问，则访问该元素，否则将TraverAlongLeft
                if (node.left == null || node.left.isVisited) {
                    InTraverVisit(node, ref nodeStack, ref nodeList);
                }
            }
            foreach (var item in nodeList) {
                item.isVisited = false;
                yield return item.value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            var node = _root;
            var nodeStack = new Stack<BinTreeNode<T>>();
            var nodeList = new List<BinTreeNode<T>>();
            while (true) {
                // 沿着左路一直走到底，沿途添加node到stack中
                InTraverAlongLeft(node, ref nodeStack);
                // 如果stack中没有元素，跳出循环
                if (nodeStack.Count <= 0) break;
                node = nodeStack.Pop();
                // 如果左侧元素为空或者已经被访问，则访问该元素，否则将TraverAlongLeft
                if (node.left == null || node.left.isVisited) {
                    InTraverVisit(node, ref nodeStack, ref nodeList);
                }
            }
            foreach (var item in nodeList) {
                item.isVisited = false;
                yield return item.value;
            }
        }
        #endregion
    }
}
