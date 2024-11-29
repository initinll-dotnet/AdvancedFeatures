namespace Indexer;

//in .net dictionary is a good example of indexer, it is used to access the elements of a collection class using an index or a key value.
// example - dictionary[key] = value;
/*
In C#, an indexer is a special type of property that allows an object to be indexed
in a similar way to arrays. It enables an instance of a class or struct to be accessed 
using the array-like syntax, but instead of using an array, you can use an object.
*/
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
