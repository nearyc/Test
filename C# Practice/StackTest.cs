using System;
using static System.Console;
using System.Collections;
class Myco : CollectionBase { }

interface IStack<T> {
    void Push(T t);
    T Pop();
    T Peek();
    void Clear();
}
class MSequenceStack<T> : IStack<T> {
    private T[] data;
    private int top;

    public int Count => top;
    public MSequenceStack(int? size) {
        int s = size.HasValue?size.Value : 10;
        data = new T[10];
        top = -1;
    }

    public void Clear() {
        top = -1;
        data = null;
    }

    public void Push(T t) {
        if (top >= data.Length) return;
        top++;
        data[top] = t;

    }

    public T Peek() {
        if (top < 0) return default(T);
        return data[top];
    }

    public T Pop() {
        if (top < 0) return default(T);
        top--;
        return data[top + 1];
    }
}
class MLinkStack<T> : IStack<T> {
    private Node<T> head;
    // private Node<T> tail;
    private int top;
    public int Count => top;
    public MLinkStack() {
        top = -1;
    }
    public void Push(T t) {
        var newNode = new Node<T>(t);
        if (top == -1) {
            head = newNode;
        } else {
            var preHead = head;
            head = newNode;
            newNode.next = preHead;
        }
        top++;
    }

    public T Peek() {
        return head.data;
    }
    public T Pop() {
        var popNode = head;
        top--;
        head = head.next;
        return popNode.data;
    }

    public void Clear() {
        head = null;
        top = -1;
    }
}
class StackTest {
    public static void Function() {
        MSequenceStack<int> mLinkStack = new MSequenceStack<int>(10);
        mLinkStack.Push(1);
        mLinkStack.Push(3);
        mLinkStack.Push(2);
        mLinkStack.Push(5);

        WriteLine(mLinkStack.Pop());
        WriteLine(mLinkStack.Pop());
        WriteLine(mLinkStack.Pop());
        WriteLine(mLinkStack.Pop());

    }
}