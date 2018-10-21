using System;
using System.Collections.Generic;
using System.Linq;
public class ShuElement
{
    public int a;
    public int b;
    public int add;
    public int mult;
    public bool isGood;

    public ShuElement(int a, int b)
    {
        this.a = a;
        this.b = b;
        this.add = a + b;
        this.mult = a * b;
        isGood = true;
    }
    public override string ToString()
    {
        string str = $"{a} --\t-- {b}";
        return str;
    }
}
public class Shuxue
{
    static int ii = 99;
    public static List<ShuElement> shuList;
    public static void InitList()
    {
        shuList = new List<ShuElement>();
        for (int i = 2; i <= ii; i++)
        {
            for (int j = ii; j > i; j--)
            {
                shuList.Add(new ShuElement(i, j));
            }
        }
    }
    public static bool Compare(ShuElement a, ShuElement b)
    {
        if (a.add == b.add || a.mult == b.mult)
        {
            a.isGood = false;
            b.isGood = false;
            return false;
        }
        return true;
    }
    public static void Function()
    {
        InitList();

        foreach (var a in shuList)
        {
            foreach (var b in shuList)
            {
                // Console.WriteLine("a");
                if (a.a == b.a && a.b == b.b) continue;
                // Console.WriteLine("b");
                var res = Compare(a, b);
                if (res == false)
                {
                    break;
                }
            }
        }
        //
        var collection = shuList.Where(x => x.isGood == true);
        foreach (var ele in collection)
        {
            Console.WriteLine(ele.ToString());
        }
    }
}
