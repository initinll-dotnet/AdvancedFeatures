namespace ArraySlicing;

public class ArraySlicingExample
{
    /*
    This only works with Array, Span<T> and Memory<T> types.
    list need to be converted to array before using this feature.
    this will cause extra memory allocation.
    */
    public static void Execute()
    {
        string text = "Hello, World!";

        // Slice using range syntax
        var substring1 = text[7..12];  // Extracts from index 7 to index 11
        Console.WriteLine(substring1);  // Output: World


        int[] numbers = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];

        // Slice with start and end index (e.g., index 2 to 5)
        var slice1 = numbers[2..6];
        Console.WriteLine(string.Join(", ", slice1)); // Output: 30, 40, 50, 60

        // Slice from the start to a specific index
        var slice2 = numbers[..4];
        Console.WriteLine(string.Join(", ", slice2)); // Output: 10, 20, 30, 40

        // Slice from a specific index to the end
        var slice3 = numbers[5..];
        Console.WriteLine(string.Join(", ", slice3)); // Output: 60, 70, 80, 90, 100

        // Slice with a range that includes the whole array
        var slice4 = numbers[..];
        Console.WriteLine(string.Join(", ", slice4)); // Output: 10, 20, 30, 40, 50, 60, 70, 80, 90, 100

        // Using the reverse range with negative indexes (count from the end)
        var slice5 = numbers[^4..^1];
        Console.WriteLine(string.Join(", ", slice5)); // Output: 70, 80, 90
    }
}
