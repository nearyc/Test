using System;

class RefTest {
    static ref int TestFunc(int[] arry, int index) => ref arry[index];
    static int i = 20;
    public static void Function() {
        int[] arry = new int[] { 1, 5, 8, 999 };
        // ref int x1 ;
        // Console.WriteLine(x1);
        ref int x1 = ref TestFunc(arry, 3);
        // x1 = i;
        Console.WriteLine(x1);
        arry[3] = 122;
        Console.WriteLine(arry[3]);
        Console.WriteLine(x1);
    }
}