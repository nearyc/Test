using System;

class ValueTupleTest {
    //todo NUGET system.valuetuple
    public static void Function() {
        (string a, int b, float c) TestFunc(string a, int b, float c) =>(a, b, c);
        var someTuple = TestFunc("abs", 2, 3);
        Console.WriteLine(someTuple.a + $"\t{someTuple.b}{someTuple.c}");
    }
    public static void TestFunc2() {
        // Function().TestFunc("a", 1, 2);
    }

}
