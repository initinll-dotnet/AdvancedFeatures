namespace ImplicitAndExplicit;

internal class Meter
{
    public double Value { get; }

    public Meter(double value)
    {
        Value = value;
    }

    // Implicit conversion from double to Meter
    public static implicit operator Meter(double value)
    {
        return new Meter(value);
    }
}

public class ImplicitConversionDemo
{
    public static void Execute()
    {
        Meter m = 5.5;  // Implicit conversion from double to Meter
        Console.WriteLine($"Meter: {m.Value}m");  // Output: Meter: 5.5m
    }
}
