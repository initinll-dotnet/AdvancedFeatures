namespace Records;

// 1. Positional Record
public record Order(int OrderId, string ProductName, double Price);

// 2. Record with Property Initializers
public record Product(int ProductId, string Name)
{
    public double Price { get; init; } = 100.0;  // Default value
}

// 3. Record with Custom Methods
public record OrderWithMethod(int OrderId, string ProductName, double Price)
{
    public double DiscountedPrice(double discount) => Price - (Price * discount);
}

// 4. Record with `with` Expression
public record ProductWithDiscount(int ProductId, string Name, double Price);

public record Customer(string Name, string Email)
{
    public string Address { get; init; }
}

// 5. Record with Deconstruction
public record Person(string Name, int Age);

// 6. Read-Only Properties and `init` Keyword
public record Item(string Name)
{
    public string Category { get; init; }
}

// 7. Record with Inheritance
public record Animal(string Name);

public record Dog(string Breed, int Age) : Animal("Dog");

// 8. Record with Primary Constructor and Members
public record Employee(int EmployeeId, string Name)
{
    public string Department { get; init; }

    public void ShowDetails() => Console.WriteLine($"{Name} works in {Department}");
}

// 9. Record with `Record` and `Equality`
public record ProductEquality(int ProductId, string Name, double Price);

// 10. Record with `static` Members
public record ItemWithStatic
{
    public static int Count { get; set; }
    public string Name { get; init; }
}

public class RecordExamples
{
    // Method demonstrating all ways to define and use records
    public static void Execute()
    {
        // 1. Positional Record
        var order1 = new Order(1, "Laptop", 1500);
        Console.WriteLine(order1);  // Output: Order { OrderId = 1, ProductName = Laptop, Price = 1500 }

        // 2. Record with Property Initializers
        var product1 = new Product(101, "Smartphone");
        Console.WriteLine(product1);  // Output: Product { ProductId = 101, Name = Smartphone, Price = 100 }

        // 3. Record with Custom Methods
        var orderWithMethod = new OrderWithMethod(2, "Tablet", 800);
        Console.WriteLine(orderWithMethod.DiscountedPrice(0.1));  // Output: 720

        // 4. Record with `with` Expression
        var product2 = new ProductWithDiscount(102, "Headphones", 200);
        var discountedProduct = product2 with { Price = 150 };
        Console.WriteLine(discountedProduct);  // Output: ProductWithDiscount { ProductId = 102, Name = Headphones, Price = 150 }

        // 5. Record with Deconstruction
        var person1 = new Person("Alice", 30);
        var (name, age) = person1;
        Console.WriteLine($"Name: {name}, Age: {age}");  // Output: Name: Alice, Age: 30

        // 6. Read-Only Properties and `init` Keyword
        var item = new Item("Laptop") { Category = "Electronics" };
        Console.WriteLine(item);  // Output: Item { Name = Laptop, Category = Electronics }

        // 7. Record with Inheritance
        var dog = new Dog("Labrador", 5);
        Console.WriteLine(dog);  // Output: Dog { Breed = Labrador, Age = 5, Name = Dog }

        // 8. Record with Primary Constructor and Members
        var employee = new Employee(1, "John Doe")
        {
            Department = "HR"
        };

        employee.ShowDetails();  // Output: John Doe works in HR

        // 9. Record with `Record` and `Equality`
        var product1Equality = new ProductEquality(1, "Laptop", 1500);
        var product2Equality = new ProductEquality(1, "Laptop", 1500);
        Console.WriteLine(product1Equality == product2Equality);  // Output: True (value-based equality)

        // 10. Record with Static Members
        var itemWithStatic1 = new ItemWithStatic { Name = "Laptop" };
        ItemWithStatic.Count = 10;
        Console.WriteLine(ItemWithStatic.Count);  // Output: 10
    }
}
