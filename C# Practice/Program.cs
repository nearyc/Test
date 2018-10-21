using System;
using System.Collections.Generic;
using System.Linq;

using Csharp_Practice;

using Practice.Collections;

namespace Csharp_Practice {
    class Program {
        static void Main(string[] args) {
            // NList<int> myList = new NList<int>(2);
            // myList.Add(1);
            // myList.Add(3);
            // myList.Add(5);
            // myList.Add(6);
            // myList.Add(2);
            // myList.Add(2);
            // myList.Remove(0);
            // myList.RemoveAt(3);
            // for (int i = 0; i < myList.Count; i++) {
            //     Console.WriteLine(myList[i]);
            // }
            // Console.WriteLine(myList.Count);
            // c2 c2 = new c2();
            // c2.Function();
            // var newList = new Practice.LinkedList.LinkedList<int>();
            // dynamic str = "";
            // newList.Add(1);
            // newList.ShowAll();

            // newList.Add(2);
            // newList.ShowAll();

            // newList.Add(3); //1 2 3
            // newList.ShowAll();

            // newList.Insert(1, 4); //1 1 2 3 
            // newList.ShowAll();

            // newList.Insert(0, 5); //1 1 1 2 3 
            // newList.ShowAll();

            // newList.Remove(3); //1 1 2 3 ;
            // newList.ShowAll();

            // newList.RemoveAt(0); //1 1 3.....
            // newList.ShowAll();

            // str = newList.GetElement(2);
            // Console.WriteLine(str);
            // str = newList.FindIndexFirstMatch(1);
            // Console.WriteLine(str);
            // newList[1] = 6; //1 2 3......
            // newList.ShowAll();

            // str = newList[1];
            // Console.WriteLine(str);

            //! Sorting
            var sortList = new List<int>() { 145, 42, 63, 7, -32, -7, -82, 9, -15, -124, 6, -78, 97, -100, 155 };
            // var sortWay = new Practice.Sorting.QuickSort();
            // var sorted = sortWay.Sorting(sortList);
            var sortArr = sortList.ToArray();
            Sort.QuickSorting(ref sortArr, 0, sortArr.Length - 1);
            foreach (var item in sortArr) {
                Console.Write($"{item.ToString()} ,");
            }

            //! Hashtable
            // var tb = new MyHashtable<int, string>();
            // tb.Add(1, "a");
            // tb.Add(111, "aa");
            // tb.Add(12, "b");
            // tb.Add(23, "c");
            // tb.Add(444, "d");
            // tb.Add(55, "e");
            // tb.Add(665, "ee");
            // tb.RemoveKey(444);
            // tb.ShowAll();
            // var a = tb.ContainsKey(1);
            // Console.WriteLine(a);
            // var b = tb.ContainsValue("cd");
            // Console.WriteLine(b);

            //! List
            // var newlist = new List<int?>() { 1, 2, 3, 4, 5, 6, 7 };
            // Console.Write(newlist.Count);
            // newlist[3] = null;
            // newlist[2] = null;
            // Console.Write(newlist.Count);
            //! Stack
            //! Queue
            // var newStack = new MyCircularQueue<int>(4);
            // newStack.Enqueue(1);
            // newStack.Enqueue(2);
            // newStack.Enqueue(133);
            // newStack.Enqueue(3);
            // newStack.Enqueue(144);
            // newStack.Dequeue();
            // Console.WriteLine(newStack.Dequeue());
            // Console.WriteLine("---------" + newStack.Front());
            // Console.WriteLine(newStack.Dequeue());
            // Console.WriteLine(newStack.Dequeue());
            // Console.WriteLine(newStack.Dequeue());
            // Console.WriteLine(newStack.Dequeue());
            //!BinaryHeap
            // var newHeap = new MybinaryHeap<int>();
            // newHeap.Add(66);
            // newHeap.Add(2);
            // newHeap.Add(77);
            // newHeap.Add(33);
            // newHeap.Add(55);
            // newHeap.Add(44);

            // newHeap.ShowAll();

            // var a = newHeap.Pop();
            // Console.WriteLine(a);

            // a = newHeap.Pop();
            // Console.WriteLine(a);

            // a = newHeap.Pop();
            // Console.WriteLine(a);

            // a = newHeap.Pop();
            // Console.WriteLine(a);

            // a = newHeap.Pop();
            // Console.WriteLine(a);

            // a = newHeap.Pop();
            // Console.WriteLine(a);
            //! BinarySearchTree
            // var newBST = new AVLTree<int>();
            // newBST.Add(2);
            // Console.Write(newBST.GetRoot());
            // newBST.Add(66);
            // newBST.Add(77);
            // Console.Write(newBST.GetRoot());
            // newBST.Add(88);
            // newBST.Add(99);
            // Console.Write(newBST.GetRoot());
            // newBST.Remove(66);
            // Console.Write(newBST.GetRoot());
            // newBST.Add(33);
            // newBST.Add(55);
            // newBST.Add(44);
            // newBST.Add(40);

            // //! linkedBinTree
            // var newBST = new BinSearchTree<int>();
            // newBST.Add(4);
            // newBST.Add(5);
            // newBST.Add(7);
            // newBST.Add(2);
            // newBST.Add(9);
            // newBST.Add(1);
            // newBST.Add(6);
            // newBST.Add(10);
            // newBST.Add(3);
            // newBST.Add(8);
            // newBST.Add(5);
            // newBST.Add(2);
            // newBST.Add(8);
            // newBST.Add(1);
            // newBST.Add(3);
            // foreach (var item in newBST) {
            //     Console.WriteLine(item);
            // }
            // // Console.WriteLine(newBST.InTraversal(newBST.Root).Count());
            // foreach (var item in newBST.LevelTravesal(newBST.Root)) {
            //     Console.WriteLine($"{item} , ");
            // }
            // newBST.RemoveAndGetValue(4);
            // Console.WriteLine($"--------------------------");
            // foreach (var item in newBST.LevelTravesal(newBST.Root)) {
            //     Console.WriteLine($"{item} , ");
            // }

            //  var a = newBST.Remove(2);
            // Console.WriteLine(a);

            //! PriorityQueue
            // var newPQ = new PriorityQueue<int, string>();
            // newPQ.Enqueue(3, "a");
            // newPQ.Enqueue(3, "aa");
            // newPQ.Enqueue(3, "aaa");
            // newPQ.Enqueue(2, "b");
            // newPQ.Enqueue(2, "b");
            // newPQ.Enqueue(5, "5");
            // newPQ.Enqueue(0, "0");

            // // foreach (var node in newPQ.SHowAllNodes()) {
            // //     Console.WriteLine(node.priority + " - " + node.value);
            // // }
            // foreach (var item in newPQ) {
            //     Console.WriteLine(item.priority + " : " + item.value);
            // }
            Console.ReadKey();
        }
    }
}
