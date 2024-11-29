namespace PatternMatching;

public class LogicalPattern
{
    public void LogicalPatternExecute()
    {
        int quantity = 0;

        // Using 'is' operator with logical pattern
        if (quantity is <= 0 or > 1000)
        {
            Console.WriteLine("Invalid Quantity.");
        }

        // Using 'switch' statement with logical pattern
        switch (quantity)
        {
            case <= 0 or > 1000:
                Console.WriteLine("Switch: Invalid Quantity.");
                break;
            default:
                Console.WriteLine("Valid Quantity.");
                break;
        }

        // Using 'switch' expression
        var result = quantity switch
        {
            <= 0 or > 1000 => "Switch Expression: Invalid Quantity.",
            _ => "Valid Quantity."
        };
        Console.WriteLine(result);
    }
}
