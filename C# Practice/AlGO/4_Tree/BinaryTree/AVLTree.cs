using System;

namespace Practice.Collections {
    /// <summary>
    /// TODO 自平衡搜索二叉树
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AVLTree<T> : ITree<T> where T : IComparable {
        private BinTreeNode<T> _root;

        public AVLTree() {
            _root = null;
        }
        protected virtual BinTreeNode<T> CreateNewNode(T value) {
            return new BinTreeNode<T>(value);
        }
        /// <summary>
        /// 添加值
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value) {
            var newNode = CreateNewNode(value);
            if (_root == null) {
                _root = newNode;
            }
            else {
                CompareAndAdd(newNode, _root, false);
                AutoBalance(newNode);
            }
        }
        private void AutoBalance(BinTreeNode<T> node) {
            var grandPa = node.parent.parent;
            if (grandPa == null) {
                return;
            }
            else if (grandPa.left == null || grandPa.right == null) {
                //! 当grandpa有一个子节点为空
                //! 交换grandPa ,parent,node的值，node从parent的子节点变成grandpa的子节点 
                var temp = grandPa.value;
                grandPa.value = node.parent.value;

                node.parent.value = node.value;
                node.parent.left = null;
                node.parent.right = null;

                node.parent = grandPa;
                node.value = temp;
                if (grandPa.left == null)
                    grandPa.left = node;
                if (grandPa.right == null)
                    grandPa.right = node;
                return;
            }
            AutoBalance(node.parent);
        }
        private void CompareAndAdd(
            BinTreeNode<T> newNode, BinTreeNode<T> originNode, bool isLeft) {
            if (originNode == null) {
                //! 如果节点为空，则为新节点的父亲的子节点赋值
                if (isLeft)
                    newNode.parent.left = newNode;
                else
                    newNode.parent.right = newNode;
            }
            else {
                //! 如果节点非空，节点为新节点的父亲
                newNode.parent = originNode;
                //! 比较大小，决定向左还是向右
                var compareResult = newNode.value.CompareTo(originNode.value);
                if (compareResult == 1) {
                    // 如果大于，放右边
                    CompareAndAdd(newNode, originNode.right, false);
                }
                else if (compareResult == 0) {
                    newNode.ClearSelf();
                    // 如果等于，不添加
                    return;
                }
                else {
                    // 如果小于，放左边
                    CompareAndAdd(newNode, originNode.left, true);
                }
            }

        }
        public T GetRoot() {
            //Todo Check null
            return _root.value;
        }
        /// <summary>
        /// 得到值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Get(T value) {
            //TODO Check Null
            return CompareAndRemove(value, ref _root, false).value;
        }
        /// <summary>
        /// 移除值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Remove(T value) {
            //TODO Check Null
            return CompareAndRemove(value, ref _root, true).value;
        }
        private BinTreeNode<T> CompareAndRemove(T value, ref BinTreeNode<T> originNode, bool isRemoving) {
            if (originNode == null) return null; //! 遇到空节点，结束 查询/移除 循环
            if (originNode.value.Equals(value)) {
                //! 遇到等值节点，结束 查询/移除 循环
                if (isRemoving) {
                    var temp = new BinTreeNode<T>(originNode.value);
                    var tempp = originNode;
                    GetCloseNumber(ref originNode);

                    return temp;
                    //TODO ZIG 旋转 // ZAG旋转 // ZIG-ZAG // ZAG-ZIG
                    //TODO RotateAT
                    //左侧不位空,赋予左侧值，清除左节点
                    // if (originNode.left != null) {
                    //     originNode.value = originNode.left.value;
                    //     originNode.left.ClearSelf();
                    //     //若右侧也不为空，则进行自动平衡修正
                    //     if (originNode.right != null)
                    //         AutoBalance(originNode.right);
                    //     return temp;
                    // }
                    // //右侧不位空，赋予右侧值，清除右节点
                    // else if (originNode.right != null) {
                    //     originNode.value = originNode.right.value;
                    //     originNode.right.ClearSelf();
                    //     var toBalance = originNode.right == null?originNode : originNode.right;
                    //     // if (originNode.left != null)
                    //     //     AutoBalance(originNode.left);
                    //     return temp;
                    // }
                    // //左右都为空，清除节点
                    // else {
                    //     originNode.ClearSelf();
                    //     return temp;
                    // }
                }
                else {
                    return originNode;
                }
            }
            //! 比较大小，决定向左还是向右
            var compareResult = value.CompareTo(originNode.value);
            if (compareResult == 1) {
                // 如果大于，放右边
                return CompareAndRemove(value, ref originNode.right, isRemoving);
            }
            else {
                // 如果小于等于，放左边
                return CompareAndRemove(value, ref originNode.left, isRemoving);
            }

        }
        private void GetCloseNumber(ref BinTreeNode<T> originNode) {
            var temp = originNode;
            if (originNode.right != null) {
                temp = originNode.right;
                while (temp.left != null) {
                    temp = temp.left;
                }

            }
            else if (originNode.left != null) {
                temp = originNode.left;
                while (temp.left != null) {
                    temp = temp.right;
                }
            }
            originNode.value = temp.value;
            // if (temp.parent.left == temp) temp.parent.left
        }
    }
}
