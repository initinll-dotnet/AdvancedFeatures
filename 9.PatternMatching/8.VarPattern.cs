namespace PatternMatching;

public class VarPattern
{
    public void VarPatternExecute()
    {
        object order = new { OrderId = 1, ProductName = "Laptop" };

        // Using 'is' operator with var pattern
        if (order is var orderInfo1)
        {
            Console.WriteLine($"Order Info: {orderInfo1}");
        }

        // Using 'switch' statement
        switch (order)
        {
            case var orderInfo2:
                Console.WriteLine($"Switch: Order Info: {orderInfo2}");
                break;
        }

        // Using 'switch' expression
        var result = order switch
        {
            var orderInfo3 => $"Switch Expression: Order Info: {orderInfo3}"
        };
        Console.WriteLine(result);
    }
}
