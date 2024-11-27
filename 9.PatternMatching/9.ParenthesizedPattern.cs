namespace PatternMatching;

public class ParenthesizedPattern
{
    public void ParenthesizedPatternExecute()
    {
        int quantity = 100;

        // Using 'is' operator
        if (quantity is ((> 50) and (< 200)))
        {
            Console.WriteLine($"Valid Quantity: {quantity}");
        }

        // Using 'switch' statement
        switch (quantity)
        {
            case (> 50) and (< 200):
                Console.WriteLine($"Switch: Valid Quantity: {quantity}");
                break;
            default:
                Console.WriteLine("Invalid Quantity.");
                break;
        }

        // Using 'switch' expression
        var result = quantity switch
        {
            (> 50) and (< 200) => $"Switch Expression: Valid Quantity: {quantity}",
            _ => "Invalid Quantity."
        };
        Console.WriteLine(result);
    }
}