using System;

namespace Practice.Collections {
    public class BinTreeNode<T> {
        public int height;
        public T value;
        public bool isVisited;
        public BinTreeNode<T> parent;
        public BinTreeNode<T> left;
        public BinTreeNode<T> right;
        public bool IsLeafNode => this.parent != null && this.left == null && this.right == null; //叶子节点
        public BinTreeNode(T value) {
            this.value = value;
            this.parent = null;
            this.left = null;
            this.right = null;
            this.height = -1;
        }
        /// <summary>
        ///? 清楚自身以及父节点中关于自身的信息
        /// </summary>
        public void ClearSelf() {
            if (this.parent.left == this) this.parent.left = null;
            if (this.parent.right == this) this.parent.right = null;
            this.parent = null;
        }
        /// <summary>
        ///? 如果目标有空子节点，则设置为父亲
        /// </summary>
        public bool SetNewParent(BinTreeNode<T> parent) {
            if (parent == null && this.parent == null) {
                return false;
            }
            if (parent == null && this.parent != null) {
                ClearSelf();
                return false;
            }
            //插入到左
            if (parent.left == null) {
                parent.left = this;
                this.parent = parent;
                return true;
            }
            //插入到右
            if (parent.right == null) {
                parent.right = this;
                this.parent = parent;
                return true;
            }
            //节点已满，插入失败
            return false;
        }
        /// <summary>
        ///? 得到兄弟
        /// </summary>
        public BinTreeNode<T> GetSibling() {
            if (this.parent == null) return null;
            if (this.parent.left == this) return this.parent.right;
            if (this.parent.right == this) return this.parent.left;
            return null;
        }
        /// <summary>
        ///? 更新高度
        /// </summary>
        public void UpdateHeight() {
            var newHeight = Math.Max(
                this.left == null? 0 : this.left.height + 1,
                this.right == null? 0 : this.right.height + 1);
            this.height = newHeight;
        }

    }

}
