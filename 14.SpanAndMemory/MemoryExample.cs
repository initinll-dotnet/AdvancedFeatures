namespace SpanAndMemory;

/*
Memory<T> is a struct in C# that provides a heap-allocated, memory-safe, 
and non-contiguous way to work with large blocks of memory. Unlike Span<T>, 
which is stack-allocated and cannot be used in asynchronous methods, Memory<T> 
is designed for scenarios where data needs to be manipulated across asynchronous 
boundaries. It is often used when dealing with large datasets, buffers, or streams 
where efficient memory management is essential.
*/

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString() => $"Id: {Id}, Name: {Name}";
}

public class MemoryExample
{
    public static async void Execute()
    {
        // Creating a Memory from an array
        int[] numbers = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];
        Memory<int> memoryNumbers = new Memory<int>(numbers);

        // Slicing memory without copying data
        Memory<int> slicedMemory = memoryNumbers.Slice(3, 4);
        Console.WriteLine("Sliced Memory: " + string.Join(", ", slicedMemory.ToArray())); // Output: 40, 50, 60, 70

        // Working with strings via Memory<T>
        string text = "Hello, Memory!";
        ReadOnlyMemory<char> memoryText = text.AsMemory();
        ReadOnlyMemory<char> slicedTextMemory = memoryText.Slice(7, 6);
        Console.WriteLine("Sliced Text: " + slicedTextMemory.ToString()); // Output: Memory

        // Asynchronous example
        await ProcessMemoryAsync(memoryNumbers);

        // Create an array of Products
        Product[] products = new Product[]
        {
                new Product { Id = 1, Name = "Laptop" },
                new Product { Id = 2, Name = "Tablet" },
                new Product { Id = 3, Name = "Smartphone" },
                new Product { Id = 4, Name = "Monitor" },
                new Product { Id = 5, Name = "Keyboard" }
        };

        // Create a Memory<Product> over the array
        Memory<Product> productMemory = new Memory<Product>(products);

        // Slice to get a subset without copying
        Memory<Product> electronicsMemory = productMemory.Slice(1, 3);
        Console.WriteLine("Electronics Subset:");
        foreach (var product in electronicsMemory.Span)
        {
            Console.WriteLine(product);
        }

        // Passing Memory<Product> to an asynchronous method
        await ProcessProductsAsync(productMemory);

        // Passing ReadOnlyMemory<Product> to an asynchronous method
        ReadOnlyMemory<Product> readOnlyProducts = products;
        await ProcessProductsAsync(readOnlyProducts);
    }

    public static async Task ProcessMemoryAsync(Memory<int> data)
    {
        // Simulate async work with Memory<T>
        await Task.Delay(500);
        Console.WriteLine("Processed Memory: " + string.Join(", ", data.ToArray())); // Output: 10, 20, 30, ...
    }

    public static async Task ProcessProductsAsync(Memory<Product> products)
    {
        await Task.Delay(500); // Simulate async work
        Console.WriteLine("\nProcessed Products:");
        foreach (var product in products.Span)
        {
            Console.WriteLine(product);
        }
    }

    public static async Task ProcessProductsAsync(ReadOnlyMemory<Product> products)
    {
        await Task.Delay(500);  // Simulating async work
        foreach (var product in products.Span)
        {
            Console.WriteLine(product);
        }
    }
}
