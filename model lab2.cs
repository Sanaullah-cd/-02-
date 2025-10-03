🔹 DRY (Don’t Repeat Yourself)
❌ Problem Code (duplicate logic in OrderService)
public class OrderService
{
    public void CreateOrder(string productName, int quantity, double price)
    {
        double totalPrice = quantity * price;
        Console.WriteLine($"Order for {productName} created. Total: {totalPrice}");
    }

    public void UpdateOrder(string productName, int quantity, double price)
    {
        double totalPrice = quantity * price;
        Console.WriteLine($"Order for {productName} updated. New total: {totalPrice}");
    }
}

✅ Fixed with DRY
public class OrderService
{
    private void PrintOrder(string action, string productName, int quantity, double price)
    {
        double totalPrice = quantity * price;
        Console.WriteLine($"Order for {productName} {action}. Total: {totalPrice}");
    }

    public void CreateOrder(string productName, int quantity, double price)
    {
        PrintOrder("created", productName, quantity, price);
    }

    public void UpdateOrder(string productName, int quantity, double price)
    {
        PrintOrder("updated", productName, quantity, price);
    }
}


➡ Reused one helper method PrintOrder().

❌ Problem Code (duplicate Start/Stop in Car and Truck)
public class Car
{
    public void Start() => Console.WriteLine("Car is starting");
    public void Stop() => Console.WriteLine("Car is stopping");
}

public class Truck
{
    public void Start() => Console.WriteLine("Truck is starting");
    public void Stop() => Console.WriteLine("Truck is stopping");
}

✅ Fixed with DRY (Base Class)
public class Vehicle
{
    protected string Name;
    public Vehicle(string name) { Name = name; }

    public void Start() => Console.WriteLine($"{Name} is starting");
    public void Stop() => Console.WriteLine($"{Name} is stopping");
}

public class Car : Vehicle
{
    public Car() : base("Car") { }
}

public class Truck : Vehicle
{
    public Truck() : base("Truck") { }
}


➡ Shared behavior in base class Vehicle.

🔹 KISS (Keep It Simple, Stupid)
❌ Problem Code (too many abstractions for simple addition)
public interface IOperation { void Execute(); }

public class AdditionOperation : IOperation
{
    private int _a, _b;
    public AdditionOperation(int a, int b) { _a = a; _b = b; }
    public void Execute() { Console.WriteLine(_a + _b); }
}

public class Calculator
{
    public void PerformOperation(IOperation operation) => operation.Execute();
}

✅ Fixed with KISS
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}


➡ No need for extra classes/interfaces.

❌ Problem Code (overuse of Singleton)
public class Singleton
{
    private static Singleton _instance;
    private Singleton() { }
    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
    }

    public void DoSomething() => Console.WriteLine("Doing something...");
}

✅ Fixed with KISS
public class SimpleService
{
    public void DoSomething()
    {
        Console.WriteLine("Doing something...");
    }
}


➡ A simple class is enough, no Singleton needed here.

🔹 YAGNI (You Ain’t Gonna Need It)
❌ Problem Code (too many abstractions for shapes)
public interface IShape
{
    double CalculateArea();
}

public class Circle : IShape
{
    private double _radius;
    public Circle(double radius) { _radius = radius; }
    public double CalculateArea() => Math.PI * _radius * _radius;
}

public class Square : IShape
{
    private double _side;
    public Square(double side) { _side = side; }
    public double CalculateArea() => _side * _side;
}

✅ Fixed with YAGNI
public class Circle
{
    private double _radius;
    public Circle(double radius) { _radius = radius; }
    public double CalculateArea() => Math.PI * _radius * _radius;
}

public class Square
{
    private double _side;
    public Square(double side) { _side = side; }
    public double CalculateArea() => _side * _side;
}


➡ No need for an interface when we only need 2 shapes.

❌ Problem Code (too many parameters in Add)
public class MathOperations
{
    public int Add(int a, int b, bool shouldLog = false)
    {
        int result = a + b;
        if (shouldLog)
        {
            Console.WriteLine($"Result: {result}");
        }
        return result;
    }
}

✅ Fixed with YAGNI
public class MathOperations
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}