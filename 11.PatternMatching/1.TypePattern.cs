namespace PatternMatching;

public class TypePattern
{
    public void TypePatternExecute()
    {
        object input = "Sample Order";

        // Using 'is' operator with variable assignment
        if (input is string orderName1)
        {
            Console.WriteLine($"Order Name: {orderName1}");
        }

        // Using 'switch' statement with variable
        switch (input)
        {
            case string orderName2:
                Console.WriteLine($"Switch: Order Name: {orderName2}");
                break;
            default:
                Console.WriteLine("Not a valid order.");
                break;
        }

        // Using 'switch' expression with variable
        var result = input switch
        {
            string orderName3 => $"Switch Expression: Order Name: {orderName3}",
            _ => "Not a valid order."
        };
        Console.WriteLine(result);
    }
}
