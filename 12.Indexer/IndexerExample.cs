namespace Indexer;

public class IndexerExample
{
    private string[] names = new string[5];

    // Define an indexer
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= names.Length)
                throw new IndexOutOfRangeException("Invalid index");
            return names[index];
        }
        set
        {
            if (index < 0 || index >= names.Length)
                throw new IndexOutOfRangeException("Invalid index");
            names[index] = value;
        }
    }

    public static void Execute()
    {
        IndexerExample example = new IndexerExample();
        example[0] = "Alice";
        example[1] = "Bob";

        Console.WriteLine(example[0]); // Output: Alice
        Console.WriteLine(example[1]); // Output: Bob
    }
}
