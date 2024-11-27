namespace TupleType;


// Tuple is value type that can store multiple values of different types
// Tuple can be used to return multiple values from a method
// Tupoles are not readonly, so you can change the values of tuple elements
public class Order
{
    static (int OrderId, string CustomerName, int TotalAmount) GetOrderDetails()
    {
        return (OrderId: 101, CustomerName: "Nitin", TotalAmount: 1500);
    }

    public static void Execute()
    {
        // Deconstructing tuple into variables
        var (orderId, customerName, totalAmount) = GetOrderDetails();

        Console.WriteLine($"OrderId: {orderId}");
        Console.WriteLine($"CustomerName: {customerName}");
        Console.WriteLine($"TotalAmount: {totalAmount}");

        // ## Creating and Deconstructing Tuples

        // 1.Tuple with Implicit Type Inference (Using var)
        var tuple = (name: "John", 25, true);
        Console.WriteLine($"Name: {tuple.name}, Age: {tuple.Item2}, IsEmployed: {tuple.Item3}");
        // Deconstructing tuple into variables
        var (name, age, isEmployed) = tuple;  // Deconstruction
        Console.WriteLine($"Name: {name}, Age: {age}, IsEmployed: {isEmployed}");

        // 2.Named Tuple
        (string Name, int Age, bool IsEmployed) person = ("John", 25, true);
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, IsEmployed: {person.IsEmployed}");
        // Deconstructing tuple into variables
        (string name1, int age1, bool isEmployed1) = ("John", 25, true);
        Console.WriteLine($"Name: {name1}, Age: {age1}, IsEmployed: {isEmployed1}");

        // 3.Tuple with Explicit ValueTuple
        ValueTuple<string, int, bool> employee = new ValueTuple<string, int, bool>("John", 25, true);
        Console.WriteLine($"Name: {employee.Item1}, Age: {employee.Item2}, IsEmployed: {employee.Item3}");
    }
}