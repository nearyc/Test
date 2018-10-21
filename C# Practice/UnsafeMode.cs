using System;
using static System.Console;

class UnsafeMode {
    class PointerDemo {　　
        public int x, y;
    }
    // unsafe { }
    public unsafe static void Function() {
        var obj = new PointerDemo();　　　　
        Console.WriteLine("原始值: {0}, {1}", obj.x, obj.y);　　　　
        fixed(int * n = & obj.x)　　　　 {　　　　　　 fixed(int * p = & obj.y)　　　　　　 {　　　　　　　　 ChangeValue(n, p); //取data地址并传递
                　　　　　　 }　　　　 }　　　　 Console.WriteLine("改变地址后: {0}, {1}", obj.x, obj.y);　　　　
        // Console.ReadLine();

    }
    public unsafe static void Add(int * res) {
        * res = 1 + 2 + 3;
    }
    unsafe static void ChangeValue(int * x, int * y) {
        //修改所在地址值
        * x = 200;
        * y = 300;　
    }

}
