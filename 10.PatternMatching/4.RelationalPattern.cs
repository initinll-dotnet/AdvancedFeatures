namespace PatternMatching;

public class RelationalPattern
{
    public void RelationalPatternExecute()
    {
        int quantity = 100;

        // Using 'is' operator
        if (quantity is > 50 and < 200)
        {
            Console.WriteLine($"Quantity in range: {quantity}");
        }

        // Using 'switch' statement with variable
        switch (quantity)
        {
            case > 50 and < 200:
                Console.WriteLine($"Switch: Quantity in range: {quantity}");
                break;
            default:
                Console.WriteLine("Quantity out of range.");
                break;
        }

        // Using 'switch' expression with variable
        var result = quantity switch
        {
            > 50 and < 200 => $"Switch Expression: Quantity in range: {quantity}",
            _ => "Quantity out of range."
        };
        Console.WriteLine(result);
    }
}
