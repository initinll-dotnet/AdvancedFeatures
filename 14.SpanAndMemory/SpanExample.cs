namespace SpanAndMemory;

/*
Using Span<T> helps in avoiding additional memory allocation when slicing collections 
like arrays and strings.

Span<T> is a struct in C# that provides a memory-safe way to access slices of 
arrays, strings, or memory buffers. It allows for efficient manipulation of contiguous
memory without causing allocations, which makes it ideal for high-performance scenarios. 
Span<T> provides a window into a segment of memory and can be used with arrays, strings, and Memory<T>. 
It is stack-allocated, meaning it doesn't heap-allocate memory like arrays, reducing the overhead associated 
with traditional array slicing or copying. Span<T> is often used for working with large datasets or buffers.

readonly Span<T> is a read-only version of Span<T> that prevents modifications to the underlying memory.
it only makes array read-only, not the elements of the array. The elements can still be modified.
*/
public class SpanExample
{
    public static void Execute()
    {
        string text = "Hello, World!";

        // Using Span to slice the string without allocation
        ReadOnlySpan<char> span = text.AsSpan();
        var substring1 = span[7..12];  // Extracts from index 7 to index 11
        Console.WriteLine(substring1.ToString());  // Output: World

        int[] numbers = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];
        Span<int> spanNumbers = numbers.AsSpan();

        // Slice with start and end index (e.g., index 2 to 5) using Span            
        Span<int> slice1 = spanNumbers[2..6];
        Console.WriteLine(string.Join(", ", slice1.ToArray())); // Output: 30, 40, 50, 60

        // Slice from the start to a specific index
        Span<int> slice2 = spanNumbers[..4];
        Console.WriteLine(string.Join(", ", slice2.ToArray())); // Output: 10, 20, 30, 40

        // Slice from a specific index to the end
        Span<int> slice3 = spanNumbers[5..];
        Console.WriteLine(string.Join(", ", slice3.ToArray())); // Output: 60, 70, 80, 90, 100

        // Slice with a range that includes the whole array
        Span<int> slice4 = spanNumbers[..];
        Console.WriteLine(string.Join(", ", slice4.ToArray())); // Output: 10, 20, 30, 40, 50, 60, 70, 80, 90, 100

        // Using the reverse range with negative indexes (count from the end)
        Span<int> slice5 = spanNumbers[^4..^1];
        Console.WriteLine(string.Join(", ", slice5.ToArray())); // Output: 70, 80, 90

        string text2 = "Hello, ReadOnlySpan!";

        // Convert string to ReadOnlySpan<char>
        ReadOnlySpan<char> span2 = text2.AsSpan();
        Console.WriteLine(span.Slice(7, 12).ToString());  // Output: ReadOnly

        // Demonstrating immutability
        ProcessSpan(span2);
    }

    static void ProcessSpan(ReadOnlySpan<char> span)
    {
        foreach (var ch in span)
        {
            Console.Write(ch + " ");  // Output: H e l l o ,   R e a d O n l y S p a n !
        }
    }
}
