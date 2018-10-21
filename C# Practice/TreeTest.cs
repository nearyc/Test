using System;
using static System.Console;

interface ITree<T>
{
    void Add(T t);
    void InitTree();
    T Root();
    T Parent(T t);
    int Depth();
    void PreOrder();
    void MidOrder();
    void PostOrder();
    T LeftChild(T t);

}
class TreeNode<T> where T : IComparable
{
    public T data;
    public TreeNode<T> leftC;
    public TreeNode<T> rightC;
    public TreeNode<T> parent;
    // public bool leftP = false;
    // public bool rightP = false;
    public TreeNode(T t)
    {
        this.data = t;
    }
}
class MTree<T> : ITree<T> where T : IComparable
{
    TreeNode<T> rootNode;
    TreeNode<T> lastNode;
    // TreeNode<T> preSerchNode;
    int count;

    public void Add(T t)
    {
        TreeNode<T> newNode = new TreeNode<T>(t);
        count++;
        if (rootNode == null)
        {
            rootNode = newNode;
            lastNode = newNode;
            // preSerchNode = newNode;
        }
        else
        {
            if (lastNode.leftC == null)
            {
                lastNode.leftC = newNode;
                newNode.parent = lastNode;
                // lastNode.leftP = true;

            }
            else
            {
                lastNode.rightC = newNode;
                // lastNode.rightP = true;
                newNode.parent = lastNode;
                lastNode = SearchLastNode(lastNode);
            }
            Sort(newNode);
        }
    }
    private TreeNode<T> SearchLastNode(TreeNode<T> t)
    {
        if (t.parent == rootNode || t == rootNode)
        {
            lastNode = rootNode;
            while (true)
            {
                lastNode = lastNode.leftC;
                if (lastNode.leftC == null)
                {
                    break;
                }
            }
            return lastNode;
        }
        if (t.parent.rightC.leftC == null || t.parent.rightC.leftC == null)
        {
            return t.rightC;
        }
        else
        {
            return SearchLastNode(t.parent);
        }
    }
    private void Sort(TreeNode<T> t)
    {
        if (t.parent == null) return;
        if (t.parent.data.CompareTo(t.data) < 0)
        {
            var temp = t.parent.data;
            t.parent.data = t.data;
            t.data = temp;
            Sort(t.parent);
        }
        return;

    }
    public T Max()
    {
        return rootNode.data;
    }
    public int Depth()
    {
        throw new NotImplementedException();
    }

    public void InitTree()
    {
        throw new NotImplementedException();
    }

    public T LeftChild(T t)
    {
        throw new NotImplementedException();
    }

    public T Parent(T t)
    {
        throw new NotImplementedException();
    }

    public void PreOrder()
    {
        Pre(rootNode);
    }
    private void Pre(TreeNode<T> t)
    {
        if (t == null) return;
        Pre(t.leftC);
        WriteLine(t.data);
        Pre(t.rightC);
    }
    public void MidOrder()
    {
        mid(rootNode);
    }
    private void mid(TreeNode<T> t)
    {
        if (t == null) return;
        WriteLine(t.data);
        mid(t.leftC);
        mid(t.rightC);
        // preSerchNode = t;
    }
    public void PostOrder()
    {
        Post(rootNode);
    }
    private void Post(TreeNode<T> t)
    {
        if (t == null) return;
        mid(t.leftC);
        mid(t.rightC);
        WriteLine(t.data);
    }
    public T Root()
    {
        throw new NotImplementedException();
    }

}
class TreeTest
{
    public static void Function()
    {
        MTree<int> mTree = new MTree<int>();
        mTree.Add(123);
        mTree.Add(324);
        mTree.Add(45);
        mTree.Add(78);
        mTree.Add(126653);
        mTree.Add(144523);
        mTree.Add(1624444443);
        mTree.Add(12 + 73);
        mTree.MidOrder();
        WriteLine("--------------------------------------------------");
        mTree.PreOrder();
        WriteLine("--------------------------------------------------");
        mTree.PostOrder();
        WriteLine("--------------------------------------------------");
        WriteLine(mTree.Max());

    }
}