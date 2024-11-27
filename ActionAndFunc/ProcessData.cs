namespace ActionAndFunc;

public delegate int SomeDelegate(int x, int y);

public class ProcessData
{
    public void Process(int x, int y, SomeDelegate del)
    {
        var result = del(x, y);
        Console.WriteLine($"Result: {result}");
    }

    public void ProcessAction(int x, int y, Action<int, int> action)
    {
        action(x, y);
        Console.WriteLine("Action has been processed");
    }

    public void ProcessFunc(int x, int y, Func<int, int, int> func)
    {
        var result = func(x, y);
        Console.WriteLine("Func has been processed with Result: " + result);
    }
}