namespace MethodOverriding;

public class Animal
{
    // Virtual method to be overridden
    public virtual void Speak()
    {
        Console.WriteLine("The animal makes a sound");
    }
}

public class Dog : Animal
{
    // Overriding the Speak method
    public override void Speak()
    {
        Console.WriteLine("The dog barks");
    }
}

public class Cat : Animal
{
    // Overriding the Speak method
    public override void Speak()
    {
        Console.WriteLine("The cat meows");
    }
}


public class MethodOverridingDemo
{
    public static void Execute()
    {
        Animal myAnimal = new Animal();
        myAnimal.Speak();  // Output: The animal makes a sound

        Animal myDog = new Dog();
        myDog.Speak();     // Output: The dog barks

        Animal myCat = new Cat();
        myCat.Speak();     // Output: The cat meows
    }
}