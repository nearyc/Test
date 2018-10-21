using System;
using static System.Console;

public class LList<T> : IData<T> {
    #region Node

    #endregion
    private Node<T> head;
    private Node<T> tail;
    public int Count { get; private set; } = 0;

    public T this[int index] {
        get =>
            GetElement(index);
        set =>
            GetEleNode(index).data = value;
    }
    public void ShowAll() {
        var temp = head;
        Console.Write($"--{temp.data}--");
        while (temp.next != null) {
            temp = temp.next;
            Console.Write($"--{temp.data}--");
        }
        Console.WriteLine("\\\\");
    }
    public void Add(T t) {
        if (Count == 0) {
            var node = new Node<T>(t);
            head = node;
            tail = node;
            Count++;
        }
        else {
            var node = new Node<T>(t);
            tail.next = node;
            tail = node;
            Count++;
        }
    }
    public void RemoveAt(int index) {
        if (index < 0 | index >= Count) throw new Exception(" out of index");

        var node = head;
        if (index == 0) {
            head = tail = null;
            Count--;
            return;
        }

        var preNode = head;
        for (int i = 1; i <= index; i++) {
            preNode = node;
            node = node.next;
        }
        preNode.next = node.next.next;
        Count--;
    }

    public void Insert(int index, T t) {
        if (index < 0 | index > Count) throw new Exception(" out of index");
        var newNode = new Node<T>(t);
        if (index == 0) {
            newNode.next = head;
            head = newNode;
            Count++;
            return;
        }

        var preNode = head;
        for (int i = 1; i <= index; i++) {
            preNode = preNode.next;
        }
        var forNode = preNode.next;
        preNode.next = newNode;
        newNode.next = forNode;
        Count++;

    }

    public T GetElement(int index) {
        return GetEleNode(index).data;
    }
    private Node<T> GetEleNode(int index) {
        if (index < 0 | index >= Count) throw new Exception(" out of index");
        var node = head;
        for (int i = 0; i <= index; i++) {
            if (i == 0) continue;
            node = node.next;
        }
        return node;
    }
    public void Locate(T t) {
        throw new NotImplementedException();
    }

    public void Clear() {
        head = null;
    }
    // public T this[int index]{
    //     get{return }
    // }

}
class LLiskTest {
    public static void Function() {
        LList<int> myLList = new LList<int>();
        myLList.Add(1);
        WriteLine("\t\t" + myLList.Count);
        WriteLine(myLList[0]);
        myLList.Add(2);
        WriteLine("\t\t" + myLList.Count);
        WriteLine(myLList[0]);
        myLList.Add(4);
        WriteLine("\t\t" + myLList.Count);
        myLList.Insert(11, 1);
        WriteLine("\t\t" + myLList.Count);
        // myLList.RemoveAt(3);
        WriteLine(myLList[0]);
        WriteLine(myLList[1]);
        WriteLine(myLList[2]);
        // WriteLine(myLList[-1]);
    }
}
