namespace ExtensionMethod;


internal static class IEnumerableExtensions
{
    public static IEnumerable<T> CustomFind<T>(this IEnumerable<T> source, Func<T, bool> isMatch)
    {
        foreach (var item in source)
        {
            if (isMatch(item))
            {
                yield return item;
            }
        }
    }
}

public class IEnumerableExtensionsDemo
{
    public static void Execute()
    {
        List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        // Find all even numbers
        var evenNumbers = numbers.CustomFind(n => n % 2 == 0);

        Console.WriteLine("Even Numbers:");
        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number);
        }

        // Find all numbers greater than 5
        var greaterThanFive = numbers.CustomFind(n => n > 5);

        Console.WriteLine("Numbers Greater Than 5:");
        foreach (var number in greaterThanFive)
        {
            Console.WriteLine(number);
        }
    }
}