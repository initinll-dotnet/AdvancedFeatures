namespace PatternMatching;

public class Order
{
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public SubOrder SubOrderDetails { get; set; }

    public Order(int orderId, string productName, SubOrder subOrderDetails)
    {
        OrderId = orderId;
        ProductName = productName;
        SubOrderDetails = subOrderDetails;
    }

    public void Deconstruct(out int orderId, out string productName, out SubOrder subOrderDetails)
    {
        orderId = OrderId;
        productName = ProductName;
        subOrderDetails = SubOrderDetails;
    }
}

public class SubOrder
{
    public int SubOrderId { get; set; }
    public string SubProductName { get; set; }

    public SubOrder(int subOrderId, string subProductName)
    {
        SubOrderId = subOrderId;
        SubProductName = subProductName;
    }
}