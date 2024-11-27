namespace PatternMatching;

public class NestedRecursivePattern
{
    public void NestedRecursivePatternExecute()
    {
        var nestedOrder = (1, (2, "Charger"));

        // Using 'is' operator
        if (nestedOrder is (1, (int subOrderId1, string subProduct1)) && subOrderId1 > 0)
        {
            Console.WriteLine($"SubOrder ID: {subOrderId1}, SubProduct: {subProduct1}");
        }

        // Using 'switch' statement
        switch (nestedOrder)
        {
            case (1, (int subOrderId2, string subProduct2)):
                Console.WriteLine($"Switch: SubOrder ID: {subOrderId2}, SubProduct: {subProduct2}");
                break;
            default:
                Console.WriteLine("No match.");
                break;
        }

        // Using 'switch' expression
        var result = nestedOrder switch
        {
            (1, (int subOrderId3, string subProduct3)) => $"Switch Expression: SubOrder ID: {subOrderId3}, SubProduct: {subProduct3}",
            _ => "No match."
        };
        Console.WriteLine(result);
    }
}
