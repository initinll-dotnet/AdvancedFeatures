namespace MethodOverloading;

internal class Calculator
{
    // Overloaded method with two int parameters
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Overloaded method with three int parameters
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    // Overloaded method with double parameters
    public double Add(double a, double b)
    {
        return a + b;
    }
}


public class MethodOverloadingDemo
{
    public static void Execute()
    {
        Calculator calc = new Calculator();
        Console.WriteLine(calc.Add(2, 3));              // Output: 5
        Console.WriteLine(calc.Add(2, 3, 4));           // Output: 9
        Console.WriteLine(calc.Add(2.5, 3.5));          // Output: 6.0
    }
}