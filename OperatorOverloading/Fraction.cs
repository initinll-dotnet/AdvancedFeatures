namespace OperatorOverloading;

internal class Fraction
{
    public int Numerator { get; }
    public int Denominator { get; }

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    // Overloading the > operator
    public static bool operator >(Fraction f1, Fraction f2)
    {
        return f1.Numerator * f2.Denominator > f2.Numerator * f1.Denominator;
    }

    // Overloading the < operator
    public static bool operator <(Fraction f1, Fraction f2)
    {
        return f1.Numerator * f2.Denominator < f2.Numerator * f1.Denominator;
    }

    // Overriding the ToString method
    public override string ToString() => $"{Numerator}/{Denominator}";
}

public class FractionDemo
{
    public static void Execute()
    {
        Fraction f1 = new(3, 4);
        Fraction f2 = new(2, 5);
        // Overloading the > and < operators
        Console.WriteLine(f1 > f2);  // Output: True
        Console.WriteLine(f1 < f2);  // Output: False
    }
}
