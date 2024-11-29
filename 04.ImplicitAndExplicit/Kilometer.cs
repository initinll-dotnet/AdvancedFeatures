namespace ImplicitAndExplicit;

internal class Kilometer
{
    public double Value { get; }

    public Kilometer(double value)
    {
        Value = value;
    }

    // Explicit conversion from Kilometer to double
    public static explicit operator double(Kilometer km)
    {
        return km.Value;
    }
}

public class ExplicitConversionDemo
{
    public static void Execute()
    {
        Kilometer km = new Kilometer(10.5);
        double value = (double)km;  // Explicit conversion with a cast
        Console.WriteLine($"Kilometer in double: {value}");  // Output: Kilometer in double: 10.5
    }
}