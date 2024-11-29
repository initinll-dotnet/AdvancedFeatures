namespace ExtensionMethod;

internal class Order
{
    public int OrderId { get; set; }
    public double TotalAmount { get; set; }
    public bool IsShipped { get; set; }
    public string CustomerName { get; set; }

    public Order(int orderId, double totalAmount, bool isShipped, string customerName)
    {
        OrderId = orderId;
        TotalAmount = totalAmount;
        IsShipped = isShipped;
        CustomerName = customerName;
    }

    public override string ToString() => $"Order ID: {OrderId}, Customer: {CustomerName}, Total: {TotalAmount:C}, Shipped: {IsShipped}";

    public void ApplyDiscount(double flatDiscount)
    {
        TotalAmount -= flatDiscount;
    }
}

internal static class OrderExtensions
{
    // Extension method to apply a discount
    public static void ApplyDiscount(this Order order, double discountPercentage)
    {
        order.TotalAmount -= order.TotalAmount * (discountPercentage / 100);
    }

    // Extension method to check if the order is high-value
    public static bool IsHighValue(this Order order, double threshold)
    {
        return order.TotalAmount > threshold;
    }

    // Extension method to mark an order as shipped
    public static void MarkAsShipped(this Order order)
    {
        order.IsShipped = true;
    }
}

public class OrderExtensionsDemo
{
    public static void Execute()
    {
        Order order = new(101, 1200.50, false, "Nitin");

        Console.WriteLine(order);  // Initial Order
        // Apply a flat discount of $100 (Order Instance Method)
        order.ApplyDiscount(flatDiscount: 100);
        // Apply a 10% discount (Order Extension Method)
        order.ApplyDiscount(discountPercentage: 10);
        Console.WriteLine("After Discount:");
        Console.WriteLine(order);  // Output: Total amount reduced by 10%

        // Check if the order is high-value with a threshold of $1000
        bool isHighValue = order.IsHighValue(1000);
        Console.WriteLine($"Is High Value: {isHighValue}");  // Output: True

        // Mark the order as shipped
        order.MarkAsShipped();
        Console.WriteLine("After Marking Shipped:");
        Console.WriteLine(order);  // Output: IsShipped = true
    }
}