using System.Diagnostics.CodeAnalysis;

namespace NullableReferenceType;

public class User
{
    public string Name { get; init; }

    public User([AllowNull] string name)
    {
        Name = name ?? "Default Name";
    }
}

public class AllowNullExample
{
    /*
        Sometimes, you may want to accept null for a parameter even if the type is non-nullable. 
        For example, consider a constructor that initializes an object with a default value when null is passed
        The [AllowNull] attribute communicates to the compiler that null is acceptable as input, even though Name is non-nullable.
    */
    public static void Execute()
    {
        User user = new User(null);

        // Output: Default Name
        Console.WriteLine(user.Name);
    }
}


