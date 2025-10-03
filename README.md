# Модуль 02 – Основные принципы проектирования  
**Курс:** Application Design Patterns  
**Тема:** DRY, KISS, YAGNI  

---

## 1. Обзор
В этом задании показано, как улучшить код с помощью трёх принципов чистого проектирования:  

- **DRY (Не повторяйся)** – избегаем дублирования кода  
- **KISS (Делай проще)** – упрощаем логику и делаем код понятным  
- **YAGNI (Не делай лишнего)** – не добавляем ненужные функции  

---

## 2. Примеры DRY

### ❌ До (дублирование методов)
```csharp
public void CreateOrder(string productName, int quantity, double price) { ... }
public void UpdateOrder(string productName, int quantity, double price) { ... }
✅ После (используем общий метод)
csharp
Copy code
private void PrintOrder(string action, string productName, int quantity, double price)
{
    double totalPrice = quantity * price;
    Console.WriteLine($"Заказ {productName} {action}. Итого: {totalPrice}");
}
❌ До (Car и Truck дублируют Start/Stop)
csharp
Copy code
public class Car { public void Start() { } public void Stop() { } }
public class Truck { public void Start() { } public void Stop() { } }
✅ После (используем базовый класс Vehicle)
csharp
Copy code
public class Vehicle
{
    protected string Name;
    public Vehicle(string name) { Name = name; }
    public void Start() => Console.WriteLine($"{Name} запускается");
    public void Stop() => Console.WriteLine($"{Name} останавливается");
}
3. Примеры KISS
❌ До (слишком много абстракций)
csharp
Copy code
public interface IOperation { void Execute(); }
public class AdditionOperation : IOperation { ... }
public class Calculator { public void PerformOperation(IOperation op) { op.Execute(); } }
✅ После (простой калькулятор)
csharp
Copy code
public class Calculator
{
    public int Add(int a, int b) => a + b;
}
❌ До (сложный Singleton)
csharp
Copy code
public class Singleton { ... }
✅ После (простой класс)
csharp
Copy code
public class SimpleService
{
    public void DoSomething() => Console.WriteLine("Выполняется действие...");
}
4. Примеры YAGNI
❌ До (лишний интерфейс для фигур)
csharp
Copy code
public interface IShape { double CalculateArea(); }
public class Circle : IShape { ... }
public class Square : IShape { ... }
✅ После (просто классы)
csharp
Copy code
public class Circle { ... }
public class Square { ... }
❌ До (лишние параметры в Add)
csharp
Copy code
public int Add(int a, int b, bool shouldLog = false) { ... }
✅ После (простой Add)
csharp
Copy code
public int Add(int a, int b) => a + b;
