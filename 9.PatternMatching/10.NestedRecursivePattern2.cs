namespace PatternMatching2;

public class Order
{
    public int OrderId { get; set; }
    public Customer Customer { get; set; }
}

public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }
}

public class Address
{
    public string City { get; set; }
    public string ZipCode { get; set; }
}

public class NestedRecursivePattern2
{
    public void NestedRecursivePatternExecute()
    {
        var order = new Order
        {
            OrderId = 101,
            Customer = new Customer
            {
                Name = "Alice",
                Address = new Address
                {
                    City = "New York",
                    ZipCode = "10001"
                }
            }
        };

        // **Using 'is' operator**
        if (order is { Customer: { Address: { City: "New York", ZipCode: "10001" } } })
        {
            Console.WriteLine("Order belongs to a customer from New York with Zip Code 10001.");
        }

        // **Using 'switch' statement**
        switch (order)
        {
            case { Customer: { Name: "Alice", Address: { City: "New York", ZipCode: var zipCode } } }:
                Console.WriteLine($"Switch: Order for Alice, New York, Zip Code: {zipCode}");
                break;
            case { Customer: { Address: { City: var city } } } when city != "New York":
                Console.WriteLine($"Switch: Customer from {city}, not New York.");
                break;
            default:
                Console.WriteLine("Switch: Order from an unknown location.");
                break;
        }

        // **Using 'switch' expression**
        var result = order switch
        {
            { Customer: { Address: { City: "New York", ZipCode: var zip } } } =>
                $"Switch Expression: New York customer with Zip Code: {zip}.",
            { Customer: { Address: { City: var city } } } =>
                $"Switch Expression: Customer from {city}.",
            _ => "Switch Expression: Unknown order."
        };

        Console.WriteLine(result);
    }
}
