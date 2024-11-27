namespace OperatorOverloading;

internal class Vector
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Overloading the + operator
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y);
    }

    public override string ToString() => $"({X}, {Y})";
}

public class VectorDemo
{
    public static void Execute()
    {
        Vector v1 = new(2, 3);
        Vector v2 = new(4, 5);
        // Overloading the + operator
        Vector v3 = v1 + v2;
        Console.WriteLine(v3);  // Output: (6, 8)
    }
}