public class c1 : Ic1
{
    public void func2()
    {
        System.Console.WriteLine("this is c1,func2");
    }
    void Ic1.func()
    {
        System.Console.WriteLine("this is c1,func1");
    }
}
public interface Ic1
{
    void func();
    void func2();
}
public class c2
{
    c1 c1 = new c1();

    public c1 C1 { get => c1; set => c1 = value; }

    public void Function()
    {
        Ic1 ic1 = C1 as Ic1;
        if (ic1 != null)
        {
            ic1.func();
            ic1.func2();
        }
        else
        {
            System.Console.WriteLine("??");
        }
    }
}
