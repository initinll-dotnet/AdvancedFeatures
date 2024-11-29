namespace OperatorOverloading;

internal class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Overloading the == operator
    public static bool operator ==(Point p1, Point p2)
    {
        return p1.X == p2.X && p1.Y == p2.Y;
    }

    // Overloading the != operator
    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1 == p2);
    }

    public override bool Equals(object obj)
    {
        if (obj is Point other)
            return X == other.X && Y == other.Y;
        return false;
    }

    public override int GetHashCode() => (X, Y).GetHashCode();
}

public class PointDemo
{
    public static void Execute()
    {
        Point p1 = new(5, 10);
        Point p2 = new(5, 10);
        // Overloading the == and != operators
        Console.WriteLine(p1 == p2);  // Output: True
        Console.WriteLine(p1 != p2);  // Output: false
    }
}