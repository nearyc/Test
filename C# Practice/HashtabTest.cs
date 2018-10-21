using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class HashtableTest {
    public static void Function() {
        int count = 1000000;
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        Hashtable hashtable = new Hashtable();
        HashSet<string> hashSet = new HashSet<string>();
        List<string> list = new List<string>();
        for (int i = 0; i < count; i++) {
            dictionary.Add(i, i);
            hashtable.Add(i, i);
            hashSet.Add($"aaa+{i}");
            list.Add($"aaa+{i}");
        }

        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < count; i++) {
            int value = dictionary[i];
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);

        stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < count; i++) {
            object value = hashtable[i.ToString()];
        }
        stopwatch.Stop();

        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        stopwatch = Stopwatch.StartNew();
        foreach (var item in hashSet) {

            object value = item;
            // Console.WriteLine(value.ToString());
        }
        // for (int i = 0; i < count; i++) {
        // }
        stopwatch.Stop();

        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        stopwatch = Stopwatch.StartNew();
        foreach (var item in list) {

            object value = item;
            // Console.WriteLine(value.ToString());
        }
        // for (int i = 0; i < count; i++) {
        // }
        stopwatch.Stop();

        Console.WriteLine(stopwatch.ElapsedMilliseconds);

    }
}