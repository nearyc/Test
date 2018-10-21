using System;

public enum ERequest : byte
{
    One,
    Two,
    Three
}
public abstract class RequestTag
{
    public abstract ERequest Tag { get; }
}
public class OneRqTag : RequestTag
{
    public override ERequest Tag => ERequest.One;
}
public class TwoRqTag : RequestTag
{
    public override ERequest Tag => ERequest.Two;
}

public abstract class Request<T> where T : RequestTag, new()
{
    public Request()
    {
        this.tag = new T().Tag;

    }

    public ERequest tag;

    public abstract void RequestFunc();
}

public abstract class Responce<T> where T : RequestTag, new()
{
    public Responce()
    {
        this.tag = new T().Tag;
    }
    public ERequest tag;
    public abstract void ResponceFunc();
}
public class OneRequst : Request<OneRqTag>
{
    // public override ERequest tag => throw new NotImplementedException();

    public override void RequestFunc()
    {
        Console.WriteLine(this.tag);
    }

}
