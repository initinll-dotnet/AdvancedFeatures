namespace NullableReferenceType;

public class Example
{
    public static void Execute()
    {
        // Nullable Types Example
        int? nullableInt = null;
        bool? nullableBool = true;
        double? nullableDouble = 45.67;

        Console.WriteLine("Nullable Types:");
        Console.WriteLine($"nullableInt: {nullableInt?.ToString() ?? "null"}");
        Console.WriteLine($"nullableBool: {nullableBool?.ToString() ?? "null"}");
        Console.WriteLine($"nullableDouble: {nullableDouble?.ToString() ?? "null"}");
        Console.WriteLine();

        // Null-Coalescing Operator (??) Example
        string? name = null;
        string greeting = name ?? "Guest";  // If name is null, default to "Guest"
        Console.WriteLine("Null-Coalescing Operator:");
        Console.WriteLine($"Greeting: {greeting}");
        Console.WriteLine();

        // Null-Conditional Operator (?.) Example
        Person? person = null;
        Console.WriteLine("Null-Conditional Operator:");
        string? personName = person?.Name; // Safe navigation
        Console.WriteLine($"Person's name: {personName ?? "No Name"}");
        Console.WriteLine();

        // If Statement for Null Check Example
        Person? anotherPerson = new Person { Name = "John", Age = 30 };
        Console.WriteLine("If Statement for Null Check:");
        if (anotherPerson != null)
        {
            Console.WriteLine($"Person: {anotherPerson.Name}, Age: {anotherPerson.Age}");
        }
        else
        {
            Console.WriteLine("Person is null.");
        }
        Console.WriteLine();

        // Pattern Matching with is null
        Person? nullPerson = null;
        Console.WriteLine("Pattern Matching with is null:");
        if (nullPerson is null)
        {
            Console.WriteLine("nullPerson is null.");
        }
        else
        {
            Console.WriteLine("nullPerson has a value.");
        }
        Console.WriteLine();

        // GetValueOrDefault Example
        int? nullableAge = null;
        int age = nullableAge.GetValueOrDefault(18); // Default to 18 if null
        Console.WriteLine("GetValueOrDefault:");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine();

        // Guard Clause Example
        Console.WriteLine("Guard Clause Example:");
        ProcessOrder(null);  // Passing null to demonstrate guard clause behavior
        ProcessOrder(new Order { OrderId = 123, ProductName = "Laptop" });  // Passing non-null object
    }

    // Guard Clause method
    public static void ProcessOrder(Order? order)
    {
        if (order == null)
        {
            Console.WriteLine("Invalid order");
            return;
        }

        Console.WriteLine($"Processing order: {order.OrderId}, Product: {order.ProductName}");
    }
}

public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public string ProductName { get; set; } = string.Empty;
}
