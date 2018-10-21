using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Threading.Tasks.Task;
using static System.Console;

class TaskTest {
    public static int i { get; } = 1;
    public static void Funciton() {
        WriteLine(i);
    }
}
