namespace OperatorOverloading;

internal class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // Overloading the unary - operator
    public static ComplexNumber operator -(ComplexNumber c)
    {
        return new ComplexNumber(-c.Real, -c.Imaginary);
    }

    public override string ToString() => $"{Real} + {Imaginary}i";
}

public class ComplexNumberDemo
{
    public static void Execute()
    {
        // Overloading the - operator
        ComplexNumber c = new(5, -3);
        ComplexNumber negatedC = -c;
        Console.WriteLine(negatedC);  // Output: -5 + 3i
    }
}