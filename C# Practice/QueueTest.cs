using System;
using static System.Console;

class MSeQueue<T> : IQueue<T> {
    private T[] data;
    private int head;
    private int tail;
    public MSeQueue(int? size) {
        int i = size.HasValue?size.Value : 10;
        data = new T[i];
        head = -1;
        tail = -1;
    }
    public void Enqueue(T t) {
        if (CursorTop >= data.Length) return;
        head++;
        if (head == 0) tail = 0;
        data[head] = t;

    }

    public T Dequeue() {
        var temp = data[tail];
        if (tail == head) Clear();
        else tail++;
        return temp;

    }

    public T Peek() {
        return data[tail];
    }
    public void Clear() {
        data = null;
        head = -1;
        tail = -1;
    }
}
class MLinkQueue<T> : IQueue<T> {
    private Node<T> head;

    public MLinkQueue() {
        head = null;;
    }

    public void Enqueue(T t) {
        var newNode = new Node<T>(t);
        var tail = head;
        if (head == null) head = newNode;
        else {
            while (true) {
                if (tail.next == null) break;
                tail = tail.next;
            }
            tail.next = newNode;
        }
    }

    public T Dequeue() {
        var temp = head;
        head = head.next;
        return temp.data;
    }

    public T Peek() {
        return head.data;
    }
    public void Clear() {
        head = null;
    }
}
class QueueTest {
    public static void Function() {
        MLinkQueue<int> mSeQueue = new MLinkQueue<int>();
        mSeQueue.Enqueue(12);
        mSeQueue.Enqueue(1223);
        mSeQueue.Enqueue(1432);
        mSeQueue.Enqueue(152);
        mSeQueue.Enqueue(162);
        mSeQueue.Enqueue(172);
        mSeQueue.Enqueue(128);

        WriteLine(mSeQueue.Dequeue());
        WriteLine(mSeQueue.Dequeue());
        WriteLine(mSeQueue.Dequeue());
        WriteLine(mSeQueue.Dequeue());
        WriteLine(mSeQueue.Dequeue());
        WriteLine(mSeQueue.Dequeue());

    }
}
