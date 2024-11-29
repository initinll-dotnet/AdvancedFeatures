namespace AnonymousType;

// Anonymous type is a class without a name and is reference type
// Anonymous type is readonly, so you cannot change the values of its properties
public class Order
{
    static dynamic GetOrderDetails1()
    {
        return new { OrderId = 101, CustomerName = "Nitin", TotalAmount = 1500.50 };
    }

    static object GetOrderDetails2()
    {
        return new { OrderId = 101, CustomerName = "Nitin", TotalAmount = 1500.50 };
    }

    public static void Execute()
    {
        // Runtime type checking (late binding).
        var result1 = GetOrderDetails1();
        Console.WriteLine($"Order ID: {result1.OrderId}, Customer: {result1.CustomerName}, Total: {result1.TotalAmount:C}");

        object result2 = GetOrderDetails2();

        // Access properties using reflection
        // Compile-time type checking (early binding).
        var orderId = result2.GetType().GetProperty("OrderId")?.GetValue(result2, null);
        var customerName = result2.GetType().GetProperty("CustomerName")?.GetValue(result2, null);
        var totalAmount = result2.GetType().GetProperty("TotalAmount")?.GetValue(result2, null);

        Console.WriteLine($"Order ID: {orderId}, Customer: {customerName}, Total: {totalAmount:C}");
    }
}