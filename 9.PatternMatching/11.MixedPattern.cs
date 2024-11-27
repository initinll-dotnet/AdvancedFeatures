namespace PatternMatching3;

public record Order(int OrderId, Customer Customer, double TotalAmount);
public record Customer(string Name, Address Address, bool IsVip);
public record Address(string City, string ZipCode);

public class ComplexPatternWithLogicalAndGrouping
{
    public void ComplexPatternExecute()
    {
        var order = new Order(
            OrderId: 105,
            Customer: new Customer(
                Name: "John Doe",
                Address: new Address(City: "Seattle", ZipCode: "98101"),
                IsVip: true
            ),
            TotalAmount: 1500.00
        );

        // **1. Using 'is' Operator with AND, OR, NOT and Parentheses**

        // AND condition: Multiple patterns combined
        if (order is
            {
                OrderId: > 100,
                Customer: { IsVip: true, Address: { City: "Seattle" } },
                TotalAmount: >= 1000
            })
        {
            Console.WriteLine("VIP Order from Seattle with high value (AND logic).");
        }

        // OR condition: Alternative possibilities
        if (order is { Customer: { IsVip: true } } or { TotalAmount: < 500, OrderId: > 0 })
        {
            Console.WriteLine("VIP Order or a small order under 500 (OR logic).");
        }

        // NOT condition: Negating a pattern
        if (order is not { Customer: { Address: { City: "Seattle" } } })
        {
            Console.WriteLine("Order is NOT from Seattle (NOT logic).");
        }

        // **2. Using 'switch' Statement with AND, OR, NOT and Parentheses**

        switch (order)
        {
            case { TotalAmount: >= 1000, Customer: { IsVip: true, Address: { City: "Seattle" } } }:
                Console.WriteLine("Switch: VIP order from Seattle with a large amount (AND logic).");
                break;

            // Grouping OR condition
            case { Customer: { IsVip: true }, TotalAmount: >= 1000 } or { OrderId: < 100, Customer: null }:
                Console.WriteLine("Switch: Either VIP with large amount or guest order (OR logic).");
                break;

            // Using NOT negation
            case { Customer: { Address: { City: var city } } } when city != "Seattle":
                Console.WriteLine($"Switch: Order from {city}, not Seattle (NOT logic).");
                break;

            default:
                Console.WriteLine("Switch: Default case (No match).");
                break;
        }

        // **3. Using 'switch' Expression with AND, OR, NOT and Parentheses**

        var message = order switch
        {
            // AND condition combined with property pattern
            { TotalAmount: >= 1000, Customer: { IsVip: true, Address: { City: "Seattle" } } } =>
                "Switch Expression: VIP order from Seattle with a large amount (AND logic).",

            // OR condition
            { Customer: { IsVip: true }, TotalAmount: >= 1000 } or { OrderId: < 100, Customer: null } =>
                "Switch Expression: Either VIP or a guest order (OR logic).",

            // NOT condition negating city
            { Customer: { Address: { City: var city } } } when city != "Seattle" =>
                $"Switch Expression: Order from {city}, not Seattle (NOT logic).",

            _ => "Switch Expression: Generic order."
        };

        Console.WriteLine(message);
    }
}
