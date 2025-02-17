namespace ActionAndFunc;

public delegate int SomeDelegate(int x, int y);

internal class ProcessData
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

public class ActionFuncDemo
{
    public static void Execute()
    {
        ProcessData processData = new();

        var del = new SomeDelegate((x, y) => x * y);
        // with delegate 
        processData.Process(2, 3, del);
        // with lambda
        processData.Process(2, 3, (x, y) => x + y);
        // using Action
        processData.ProcessAction(2, 3, (x, y) => Console.WriteLine($"Action: {x + y}"));
        // using Func
        processData.ProcessFunc(2, 3, (x, y) => x - y);
    }
}