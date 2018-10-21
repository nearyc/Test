using System;

namespace Practice.Collections {
    /// <summary>
    ///? 禁止重复的元素的二叉搜索树
    /// </summary>
    public class BinSearchTree<T> : BinTree<T> where T : IComparable {
        public BinSearchTree() {
            _root = null;
        }
        /// <summary>
        /// 添加值
        /// </summary>
        public override void Add(T value) {
            var newNode = new BinTreeNode<T>(value);
            var isAdded = false;
            if (_root == null) {
                _root = newNode;
                isAdded = true;
            }
            else {
                isAdded = CompareAndAdd(newNode, _root, false);
            }
            //元素不重复，添加成功
            if (isAdded) {
                ++_count; // 数量增加
                UpdateHeight(newNode); // 更新高度
            }
        }
        /// <summary>
        /// 得到对应值的节点
        /// </summary>
        public BinTreeNode<T> Get(T value) {
            //TODO Check Null
            return CompareAndRemove(value, ref _root, false);
        }
        /// <summary>
        /// 移除值及其节点
        /// </summary>
        public T RemoveAndGetValue(T value) {
            //TODO Check Null
            return CompareAndRemove(value, ref _root, true).value;
        }
        #region CompareAndDoSomething

        private bool CompareAndAdd(
            BinTreeNode<T> newNode, BinTreeNode<T> originNode, bool isLeft) {
            if (originNode == null) {
                //! 如果节点为空，则为新节点的父亲的子节点赋值
                if (isLeft)
                    newNode.parent.left = newNode;
                else
                    newNode.parent.right = newNode;
                return true;
            }
            else {
                //! 如果节点非空，节点为新节点的父亲
                newNode.parent = originNode;
                //! 比较大小，决定向左还是向右
                var compareResult = newNode.value.CompareTo(originNode.value);
                if (compareResult == 1) {
                    // 如果大于，放右边
                    return CompareAndAdd(newNode, originNode.right, false);
                }
                else if (compareResult == 0) {
                    newNode.ClearSelf();
                    // 如果等于，不添加
                    return false;
                }
                else {
                    // 如果小于，放左边
                    return CompareAndAdd(newNode, originNode.left, true);
                }
            }

        }
        private BinTreeNode<T> CompareAndRemove(T value, ref BinTreeNode<T> node, bool isRemoving) {
            // 遇到空节点，结束 查询/移除 循环
            if (node == null) return null;
            // 遇到等值节点，返回结果
            if (node.value.Equals(value)) {
                // 是否是移除操作
                if (isRemoving) {
                    var temp = new BinTreeNode<T>(node.value);
                    if (node.IsLeafNode) {
                        node.ClearSelf(); //如果为叶子节点，直接移除
                    }
                    else {
                        var replace = SearchClosestBigger(node); //得到最近的点，优先选择较大的
                        if (replace == null) replace = SearchClosestSmaller(node); //次选较小的
                        node.value = replace.value; //替换值
                        // 如果是叶子节点，则移除并且从父节点开始更新高度；
                        if (replace.IsLeafNode) {
                            var tempParent = replace.parent;
                            replace.ClearSelf(); //移除替换点
                            UpdateHeight(tempParent);
                        }
                        //如果不是叶子节点，则替换节点必定只有唯一子节点
                        //将其昨晚父节点的子节点，并更新高度
                        else {
                            if (replace.left != null) {
                                replace.parent.left = replace.left;
                                replace.left.parent = replace.parent.left;
                                UpdateHeight(replace.parent);
                                replace.ClearSelf();
                            }
                            else if (replace.right != null) {
                                replace.parent.right = replace.right;
                                replace.right.parent = replace.parent.right;
                                UpdateHeight(replace.parent);
                                replace.ClearSelf();
                            }
                        }
                    }
                    return temp;
                }
            }
            //! 比较大小，决定向左还是向右递归
            var compareResult = value.CompareTo(node.value);
            if (compareResult == 1) {
                // 如果大于，放右边
                return CompareAndRemove(value, ref node.right, isRemoving);
            }
            else {
                // 如果小于等于，放左边
                return CompareAndRemove(value, ref node.left, isRemoving);
            }

        }
        #endregion
        #region Seach
        protected BinTreeNode<T> SearchClosestBigger(BinTreeNode<T> node) {
            var bigger = node;
            if (bigger.right != null)
                bigger = bigger.right;
            //一直向左
            while (bigger.left != null) {
                bigger = bigger.left;
            }
            return bigger;
        }
        protected BinTreeNode<T> SearchClosestSmaller(BinTreeNode<T> node) {
            var smaller = node;
            if (smaller.left != null)
                smaller = smaller.left;
            //一直向左
            while (smaller.right != null) {
                smaller = smaller.right;
            }
            return smaller;
        }
        #endregion
    }
}
