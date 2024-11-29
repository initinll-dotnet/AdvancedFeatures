namespace PatternMatching;

public class PositionalPattern
{
    Order order = new Order(
            orderId: 1,
            productName: "Laptop",
            subOrderDetails: new SubOrder(101, "Mouse"));

    public void PositionalPatternExecute()
    {
        // Using 'is' operator with deconstruction
        if (order is (int id1, string productName1, _) && id1 > 0)
        {
            Console.WriteLine($"Order ID: {id1}, Product: {productName1}");
        }

        // Using 'switch' statement
        switch (order)
        {
            case (int id2, string productName2, _) when id2 > 0:
                Console.WriteLine($"Switch: Order ID: {id2}, Product: {productName2}");
                break;
            default:
                Console.WriteLine("Invalid Order.");
                break;
        }

        // Using 'switch' expression
        var result = order switch
        {
            (int id3, string productName3, _) when id3 > 0 => $"Switch Expression: Order ID: {id3}, Product: {productName3}",
            _ => "Invalid Order."
        };
        Console.WriteLine(result);
    }
}
