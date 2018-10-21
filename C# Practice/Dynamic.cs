using System;
using System.Collections.Generic;
using System.Reflection;
class DynamicTest {
    public class ExampleClass {
        public ExampleClass() { }
        public ExampleClass(int v) { }

        public void exampleMethod1(int i) { }

        public void exampleMethod2(string str) { }

    }
    public static void Function() {

        dynamic obj1 = new System.Dynamic.ExpandoObject();
        obj1.id = 2;
        obj1.name = "张无忌";
        obj1.some = 22.2f;
        Console.WriteLine(obj1.some); //输出：System.Dynamic.ExpandoObject

        obj1.list = new List<string>();
        obj1.list.Add("令狐冲");
        foreach (var item in obj1.list) {
            Console.WriteLine(item); //输出：令狐冲

        }
    }
}