namespace PatternMatching;

public class PropertyPattern
{
    public void PropertyPatternExecute()
    {
        var order = new Order(
            orderId: 1,
            productName: "Laptop",
            subOrderDetails: new SubOrder(101, "Mouse"));

        // Using 'is' operator with property pattern
        if (order is { OrderId: > 0, ProductName: "Laptop" })
        {
            Console.WriteLine($"Order is laptop.");
        }

        // Using 'switch' statement
        switch (order)
        {
            case { OrderId: > 0, ProductName: var productName2 }:
                Console.WriteLine($"Switch: Product: {productName2}");
                break;
            default:
                Console.WriteLine("Invalid Order.");
                break;
        }

        // Using 'switch' expression
        var result = order switch
        {
            { OrderId: > 0, ProductName: var productName3 } => $"Switch Expression: Product: {productName3}",
            // discard pattern
            _ => "Invalid Order."
        };
        Console.WriteLine(result);
    }
}
