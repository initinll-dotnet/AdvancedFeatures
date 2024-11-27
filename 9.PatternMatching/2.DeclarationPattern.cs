namespace PatternMatching;

public class DeclarationPattern
{
    public void DeclarationPatternExecute()
    {
        object input = 50;

        // Using 'is' operator with variable
        if (input is int quantity)
        {
            Console.WriteLine($"Order Quantity: {quantity}");
        }

        // Using 'switch' statement with variable
        switch (input)
        {
            case int quantity1:
                Console.WriteLine($"Switch: Order Quantity: {quantity1}");
                break;
            default:
                Console.WriteLine("Quantity not provided.");
                break;
        }

        // Using 'switch' expression with variable
        var result = input switch
        {
            int quantity2 => $"Switch Expression: Order Quantity: {quantity2}",
            _ => "Quantity not provided."
        };
        Console.WriteLine(result);
    }
}
