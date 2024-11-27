namespace PatternMatching;

public class ConstantPattern
{
    private const string Laptop = "Laptop";

    public void ConstantPatternExecute()
    {
        string product = "Laptop";

        // Using 'is' operator
        if (product is Laptop)
        {
            Console.WriteLine("Product is Laptop.");
        }

        // Using 'switch' statement
        switch (product)
        {
            case Laptop:
                Console.WriteLine("Switch: Product is Laptop.");
                break;
            default:
                Console.WriteLine("Different Product.");
                break;
        }

        // Using 'switch' expression
        var result = product switch
        {
            Laptop => "Switch Expression: Product is Laptop.",
            _ => "Different Product."
        };
        Console.WriteLine(result);
    }
}