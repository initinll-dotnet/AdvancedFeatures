using System.Diagnostics.CodeAnalysis;

namespace NullableReferenceType;

public class NotNullWhenExample
{
    private static object? GetObject() => null;

    /*
        The NotNullWhen attribute informs the compiler about the nullability 
        of a parameter based on the method's return value.
    */
    private static bool ValidateObject([NotNullWhen(true)] object? obj)
    {
        return obj != null;
    }

    public static void Execute()
    {
        object? myObject = GetObject();

        if (ValidateObject(myObject))
        {
            // No warning: The compiler knows 'myObject' is not null.
            Console.WriteLine(myObject.ToString());
        }
    }
}


