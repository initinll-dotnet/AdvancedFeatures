using System.Diagnostics.CodeAnalysis;

namespace NullableReferenceType1;

public class Order
{
    public string Id { get; init; }

    public Order([AllowNull] string id)
    {
        Id = id ?? "Default Order ID";
    }
}

public static class Guard
{
    public static void ValidateOrder([DoesNotReturnIf(true)] bool isNull, [NotNullWhen(false)] Order? order)
    {
        if (isNull)
        {
            throw new ArgumentNullException(nameof(order), "Order cannot be null.");
        }
    }
}

public static class CombinedExample
{
    /*
    This example demonstrates how:
    - [AllowNull]: Allows null for the Order constructor and handles it safely.
    - [DoesNotReturnIf]: Validates the order and stops execution if the condition is true.
    - [NotNullWhen]: Ensures the compiler knows the order is non-null if the validation passes.
    */
    public static void Execute()
    {
        Order? order = null;

        try
        {
            Guard.ValidateOrder(order == null, order);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }

        order = new Order(null);

        // Compiler knows 'order' is not null here.
        Console.WriteLine($"Order ID: {order.Id}");
    }
}

/*
Benefits of Null-State Static Analysis Attributes
- Improved Compiler Assistance: Attributes like NotNullWhen and DoesNotReturnIf make the compiler smarter about null-state analysis, reducing unnecessary warnings.
- Clearer Intent: Your code explicitly communicates how nullability is handled, improving readability and maintainability.
- Safer Code: By eliminating runtime null reference issues, these attributes make your code more robust.

Conclusion
    Null-state static analysis attributes like NotNullWhen, AllowNull, and DoesNotReturnIf are 
    indispensable tools for working with nullable reference types in C#. They allow you to write safer, 
    cleaner, and more maintainable code by bridging the gaps in the compiler's nullability analysis.
*/