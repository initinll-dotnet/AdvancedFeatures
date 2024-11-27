using System.Diagnostics.CodeAnalysis;

namespace NullableReferenceType;

public static class Guard
{
    public static void ThrowIfNull([DoesNotReturnIf(true)] bool isNull, object? obj)
    {
        if (isNull)
        {
            throw new ArgumentNullException(nameof(obj), "Object cannot be null.");
        }
    }
}

public class DoesNotReturnIfExample
{
    /*
        The DoesNotReturnIf attribute is used for methods that terminate the application 
        or throw exceptions based on a condition. It informs the compiler that if a 
        specific condition is true, the method will not return.
        
        How It Works:
        - The [DoesNotReturnIf(true)] attribute on the isNull parameter tells the 
          compiler that the method will not return if isNull is true.
        - After the method call, the compiler assumes myObject is not null, eliminating warnings.
    */
    public static void Execute()
    {
        object? myObject = null;

        // Validate the object
        Guard.ThrowIfNull(isNull: myObject == null, obj: myObject);

        // Compiler knows 'myObject' is not null here.
        Console.WriteLine(myObject.ToString());
    }
}