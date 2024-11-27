namespace DeconstructMethod;

// Deconstructing a Custom Class
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Implementing the Deconstruct method
    public void Deconstruct(out string name, out int age)
    {
        name = Name;
        age = Age;
    }
}

public static class PersonExtensions
{
    // Extension method for deconstructing Person object
    public static void Deconstruct(this Person person, out string personName, out int personAge)
    {
        personName = person.Name;
        personAge = person.Age;
    }
}

//  Struct with a Deconstruct Method
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    // Implementing the Deconstruct method
    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }
}

public class DeconstructMethodDemo
{
    public static void Execute()
    {
        var person = new Person { Name = "John", Age = 25 };

        // Deconstructing the object into individual variables
        var (name, age) = person;  // Uses the Deconstruct method

        Console.WriteLine($"Name: {name}, Age: {age}");

        var point = new Point { X = 10, Y = 20 };

        // Deconstructing the struct into individual variables
        var (x, y) = point;  // Uses the Deconstruct method

        Console.WriteLine($"X: {x}, Y: {y}");
    }
}