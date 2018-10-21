using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;
class ThreadTest {
    static void Test1(int i, string str) {
        Console.WriteLine("test1\t" + i + "\t" + str);
        Thread.Sleep(100);
        Console.WriteLine("test1\t" + i + "\t" + str);
        return;
        // Thread.Sleep(TimeSpan.FromSeconds(0.5f));
        // return 100;
    }
    static void PrintSome() {
        Console.WriteLine("start.");
        for (int i = 0; i < 10; i++) {
            Console.Write(i);
            Thread.Sleep(200);
        }

    }
    public static void Function() {
        Thread t = new Thread(PrintSome);
        t.Start();
        Sleep(TimeSpan.FromSeconds(1));
        t.Abort();

        PrintSome();

        // Action<int, string> act = Test1;
        // // Action<int, string, int> a = Test1;
        // act.BeginInvoke(12, "sttt", null, null);
        // Console.WriteLine("begin");
        // while (ar.IsCompleted == false) {
        // Console.Write(".");
        // Thread.Sleep(50);
        // }
        // act.EndInvoke();
        // Console.WriteLine(res);

    }
}