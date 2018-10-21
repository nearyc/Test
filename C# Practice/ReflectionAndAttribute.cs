using System;
using System.Reflection;
using System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
class TestAttribute : Attribute {
    string str = "this is a test att";
    public float version;
    public TestAttribute(string str) {
        this.str = str;
        version = 1.0f;
    }
}

[Test("MySuitClass", version = 1.3f)]
class MySuitClass {
    public string str = "this is my suit class";
    public int i = 123;
    public int p {
        get { return 1; }
        set { }
    }
    public int pp {
        get { return 2; }
        set { }
    }
}
class ReflectionAndAttribute {
    public static void TestFuc(string str, [CallerFilePath] string fileName = "file", [CallerLineNumber] int lineNumber = 1, [CallerMemberName] string methodName = "fuc") {
        Console.WriteLine("test");
        Console.WriteLine(fileName);
        Console.WriteLine(lineNumber);
        Console.WriteLine(methodName);
    }
    public static void Function() {
        // foreach (var t in Assembly.GetExecutingAssembly().GetTypes()) {
        //     // Console.WriteLine(t.Name);
        //     foreach (var att in t.GetCustomAttributes(typeof(TestAttribute), false)) {
        //         if (att is TestAttribute)
        //             Console.WriteLine(t.Name + " is this one!");
        //     }
        // }
        // Type t = typeof(MySuitClass);
        // MySuitClass a = new MySuitClass();
        // Type tt = a.GetType();
        // Console.WriteLine(t + "\t" + a);
        // foreach (var item in t.GetFields()) {
        //     Console.WriteLine(item.Name);
        // }
        // foreach (var item in t.GetProperties()) {
        //     Console.WriteLine(item.Name);
        // }
        // MySuitClass my = new MySuitClass();
        // var ass = my.GetType().Assembly;
        // string str = ass.FullName;
        // Console.WriteLine(str);
        // TestFuc("sdf");
        var ass = Assembly.GetExecutingAssembly().GetTypes();
        foreach (var t in ass) {
            var att = t.GetCustomAttributes(typeof(TestAttribute), false);
            // Console.WriteLine(t.GetType().Name);
            foreach (var item in att) {
                var attr = item as TestAttribute;
                if (null != attr) {
                    Console.WriteLine(attr.version);
                }
            }
        }

    }

}