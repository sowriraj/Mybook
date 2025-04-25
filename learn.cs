 
---

### **Memory Management**
13. **Q: How is garbage collection managed in C#?**
    **A:** It automatically cleans up unused objects, but you can trigger it using `GC.Collect()`.

14. **Q: What is the difference between `Dispose()` and `Finalize()`?**
    **A:** `Dispose()` is explicit cleanup, `Finalize()` is automatic and used for unmanaged resources.

---

### **Delegates and Events**
15. **Q: How do you declare and use a delegate in C#?**
    **A:** Declare with `delegate`, invoke by assignment.
    ```csharp
     
using System;

class Program {
	delegate void ProgressCallback(int progress);

    // Method that matches the delegate signature
    public static void ShowProgress(int progress) {
        Console.WriteLine($"Download progress: {progress}%");
    }

    public static void Main() {
        // Create an instance of the delegate pointing to the ShowProgress method
        ProgressCallback progressCallback = ShowProgress;

        // Call the DownloadFile method, passing the delegate as a callback
        DownloadFile("http://example.com/file.zip", progressCallback);
    }

    // Method that performs the download
    public static void DownloadFile(string url, ProgressCallback callback) {
        Console.WriteLine($"Downloading from: {url}");
        for (int i = 0; i <= 100; i++) {
            System.Threading.Thread.Sleep(50); // Simulate work
            callback(i); // Notify progress
        }
        Console.WriteLine("Download complete!");
    }
}


## EVENTS

 using System;

public class Stock {
    // Declare the event using EventHandler
    public event EventHandler PriceChanged;

    private decimal _price;

    // Method to update the stock price
    public void UpdatePrice(decimal newPrice) {
        if (_price != newPrice) {
            _price = newPrice;

            // Raise the PriceChanged event
            PriceChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

public class Subscriber {
    private string _subscriberName;

    // Constructor to assign a name to the subscriber
    public Subscriber(string name) {
        _subscriberName = name;
    }

    // Event handler method for reacting to price changes
    public void OnPriceChanged(object sender, EventArgs e) {
        if (sender is Stock stock) {
            Console.WriteLine($"{_subscriberName} received notification: Price changed to {stock.GetPrice()}");
        }
    }
}

public class Program {
    public static void Main() {
        // Create the Stock publisher
        Stock stock = new Stock();

        // Create Subscribers and subscribe to the PriceChanged event
        Subscriber subscriber1 = new Subscriber("Trader A");
        Subscriber subscriber2 = new Subscriber("Trader B");

        stock.PriceChanged += subscriber1.OnPriceChanged; // Subscription
        stock.PriceChanged += subscriber2.OnPriceChanged; // Subscription

        // Update the stock price (this will trigger notifications)
        stock.UpdatePrice(100.50m);
        stock.UpdatePrice(101.75m);
    }
}

16. **Q: Explain event handling with an example.**
    **A:** Events use delegates.
    ```csharp
    public event EventHandler MyEvent;
    ```

---

### **LINQ**
17. **Q: What is the use of LINQ in C#?**
    **A:** Query collections like arrays, lists, and databases.

18. **Q: How does `Select` differ from `Where` in LINQ?**
    **A:** `Select` projects data, `Where` filters data.


 SingleOrDefault()
Returns:

The only element in a sequence that satisfies a condition.

If exactly one match is found: returns it.

If none: returns default (like null).

If more than one: throws an exception (InvalidOperationException).

 FirstOrDefault()
Returns:

The first element in a sequence that satisfies a condition.

If no elements match, it returns default value (null for reference types).

✅ Example:



### **Threads and Asynchronous Programming**
19. **Q: What are the benefits of `async` and `await` in C#?**
    **A:** Simplifies asynchronous code with better readability.

20. **Q: How does the `Task` class differ from `Thread` in C#?**
    **A:** `Task` is higher-level and supports async operations, while `Thread` is low-level.

---

### **Miscellaneous**
21. **Q: What is the purpose of the `dynamic` keyword in C#?**
    **A:** Enables runtime binding without compile-time type checking.
	
	
Early Binding (Static Binding)
Definition:
Binding occurs at compile-time — the compiler knows the exact method or property that will be called.

✅ Characteristics:
Type checked at compile time.

Better performance.

More IntelliSense support in IDEs.

Less flexible, but safer.

✅ Example in C#:
 
Dog dog = new Dog();
dog.Bark();  // Compiler knows at compile time that Bark() will be called.
Or using interfaces:
 
IAnimal animal = new Dog();
animal.Speak(); // T


Late Binding (Dynamic Binding)
Definition:
Binding happens at runtime — the actual method or property is determined when the program is running.

✅ Characteristics:
More flexible.

Uses reflection or the dynamic keyword.

Slight performance cost.

Higher risk: errors show up at runtime.

✅ Example using dynamic: 
dynamic obj = new Dog();
obj.Bark();  // No compile-time check, resolves at runtime.
✅ Example using Type.InvokeMember (Reflection): 
Type type = Type.GetType("Dog");
	
	

22. **Q: Explain the difference between `is` and `as` in C#.**
    **A:** `is` checks type, `as` performs type conversion.

---
 Here are concise answers to your questions with examples where relevant:

---

### **23. How does the `try`-`catch` block work in exception handling?**
**Answer:**  
The `try` block contains code that may throw an exception, while the `catch` block handles it.  
**Example:**
```csharp
try {
    int result = 10 / 0; // Division by zero exception
} catch (DivideByZeroException ex) {
    Console.WriteLine($"Error: {ex.Message}");
}
```

---

### **24. Explain boxing and unboxing in C#.**
**Answer:**  
- **Boxing:** Converts a value type to an object type (stored on the heap).  
  **Example:**
  ```csharp
  int num = 10;
  object box = num; // Boxing
  ```

- **Unboxing:** Converts an object type back to a value type.  
  **Example:**
  ```csharp
  int unboxed = (int)box;
  ```

---

### **25. What is the difference between a struct and a class?**
**Answer:**
- Structs are **value types**, allocated on the stack; classes are **reference types**, allocated on the heap.
- Structs **do not support inheritance**; classes do.
- Structs are suited for lightweight objects, e.g., `Point`.

**Example:**
```csharp
struct Point {
    public int X;
    public int Y;
}
class Shape {
    public int Width;
    public int Height;
}
```

---

### **26. Can you implement `IComparable` for sorting objects in a list?**
**Answer:**  
Yes, implement `CompareTo` for custom sorting.  
**Example:**
```csharp
class Employee : IComparable<Employee> {
    public string Name { get; set; }
    public int Age { get; set; }
    public int CompareTo(Employee other) {
        return this.Age.CompareTo(other.Age);
    }
}
List<Employee> employees = new List<Employee> {
    new Employee { Name = "Alice", Age = 30 },
    new Employee { Name = "Bob", Age = 25 }
};
employees.Sort();
```

---

### **27. What is the use of extension methods?**
**Answer:**  
Extension methods add functionality to existing types.  
**Example:**  
```csharp
public static class StringExtensions {
    public static bool IsNumeric(this string str) {
        return int.TryParse(str, out _);
    }
}
// Usage:
string input = "123";
bool result = input.IsNumeric(); // true
```

---

### **28. How does the `yield` keyword function in C#?**
**Answer:**  
The `yield` keyword enables stateful iteration in methods that return `IEnumerable`.  
**Example:**
```csharp
public static IEnumerable<int> GetNumbers() {
    yield return 1;
    yield return 2;
    yield return 3;
}
// Usage:
foreach (var num in GetNumbers()) { Console.WriteLine(num); }
```

---

### **29. What are anonymous types?**
**Answer:**  
Anonymous types are inline, read-only objects created without a formal class definition.  
**Example:**
```csharp
var person = new { Name = "John", Age = 30 };
Console.WriteLine(person.Name); // Output: John
```

---

### **30. Explain the difference between static and instance constructors.**
**Answer:**  
- **Static Constructor**: Initializes static members and is called once.  
- **Instance Constructor**: Initializes instance members and is called each time an object is created.  
**Example:**
```csharp
class MyClass {
    static MyClass() { Console.WriteLine("Static constructor"); }
    public MyClass() { Console.WriteLine("Instance constructor"); }
}
```

---

### **31. How do you implement dependency injection?**
**Answer:**  
Inject dependencies through the constructor.  
**Example:**
```csharp
public interface IService { void Execute(); }
public class MyService : IService {
    public void Execute() { Console.WriteLine("Service executed"); }
}
public class Client {
    private IService _service;
    public Client(IService service) { _service = service; }
    public void Start() { _service.Execute(); }
}
```

---

### **32. What are nullable types, and how are they useful?**
**Answer:**  
Nullable types represent value types that can also be `null`.  
**Example:**
```csharp
int? nullableInt = null;
if (nullableInt.HasValue) Console.WriteLine(nullableInt.Value);
```

---

### **33. How does the `lock` statement prevent race conditions?**
**Answer:**  
The `lock` statement ensures that only one thread accesses a critical section at a time.  
**Example:**
```csharp
private static object _lock = new object();
lock (_lock) {
    // Critical section
}
```

---

### **34. What is reflection and its use in C#?**
**Answer:**  
Reflection provides metadata about assemblies, types, and methods at runtime.  
**Example:**
```csharp
Type type = typeof(string);
Console.WriteLine(type.FullName); // System.String
```

---

### **35. Explain deferred execution in LINQ.**
**Answer:**  
Queries are executed when enumerated, not when defined.  
**Example:**
```csharp
var query = from num in numbers where num > 5 select num; // Deferred execution
numbers.Add(10); // Query reflects changes when executed
```

---

### **36. How does the `var` keyword differ from `dynamic`?**
**Answer:**  
- `var` is strongly typed (determined at compile time).  
- `dynamic` is weakly typed (resolved at runtime).  
**Example:**
```csharp
var x = 10; // int
dynamic y = 10; // Runtime resolution
```

---

### **37. What is the difference between `List<T>` and `ArrayList`?**
**Answer:**  
- `List<T>` is type-safe and generic.  
- `ArrayList` is not type-safe and stores `object`.  
**Example:**
```csharp
List<int> list = new List<int> { 1, 2, 3 }; // Type-safe
ArrayList arrayList = new ArrayList { 1, "string" }; // Mixed types
```

---

### **38. How does the `Predicate<T>` delegate work?**
**Answer:**  
Represents a method that defines a condition.  
**Example:**
```csharp
Predicate<int> isEven = x => x % 2 == 0;
Console.WriteLine(isEven(4)); // true
```

---

### **39. What is the difference between a shallow and deep copy?**
**Answer:**  
- Shallow Copy: Copies references of inner objects.  
- Deep Copy: Copies entire object graph.  
**Example:** `Clone()` creates a shallow copy.

---

### **40. How does `Task.Run` differ from `Thread.Start`?**
**Answer:**  
- `Task.Run` is higher-level, uses the thread pool, and supports async.  
- `Thread.Start` creates a dedicated thread.

---

### **41. Explain the purpose of `StringBuilder`.**
**Answer:**  
Efficiently handles mutable strings.  
**Example:**
```csharp
StringBuilder sb = new StringBuilder("Hello");
sb.Append(" World");
Console.WriteLine(sb); // Hello World
```

---

### **42. What is a WeakReference?**
**Answer:**  
A `WeakReference` allows an object to be garbage-collected while still being accessible.

---

### **43. How does `await Task.WhenAll()` work?**
**Answer:**  
Executes multiple asynchronous tasks concurrently.  
**Example:**
```csharp
await Task.WhenAll(task1, task2);
```

---

### **44. Can you explain method chaining?**
**Answer:**  
Call multiple methods on an object in a single statement.  
**Example:**
```csharp
sb.Append("Hello").Append(" World");
```

---

### **45. What is the difference between `Equals()` and `==` in C#?**
**Answer:**  
- `Equals()`: Compares object content.  
- `==`: Depends on operator overloading.

---

### **46. How does serialization and deserialization work?**
**Answer:**  
Serialization converts objects to a format for storage; deserialization reverses it.  
**Example:** Use `JsonSerializer`.

---

### **47. What are the advantages of generics?**
**Answer:**  
Type safety, reusability, and performance.  

---

### **48. How does the `foreach` loop work in C#?**
**Answer:**  
Iterates over an `IEnumerable`. Uses `GetEnumerator()` internally.

---

### **49. Explain the Observer pattern.**
**Answer:**  
Notifies subscribers of changes to a subject.  
**Example:** Implement using delegates/events.

---

### **50. How would you optimize code performance?**
**Answer:**  
- Use efficient algorithms, caching, and `StringBuilder`.  
- Avoid boxing/unboxing.  
- Minimize memory allocations.

Let me know if you want deeper examples for any of these! 🚀


Generics in C# provide **type safety**, **reusability**, and **performance** by allowing you to define type parameters in classes, methods, and interfaces. Here's how these advantages work, along with examples:

---

### **1. Type Safety**
Generics ensure that you work with strongly typed objects, reducing the risk of runtime errors.

**Example:**
```csharp
// Generic List
List<int> numbers = new List<int>();
numbers.Add(1);
numbers.Add(2);

// Compile-time safety - prevents invalid types
// numbers.Add("string"); // This will cause a compile-time error

foreach (int num in numbers) {
    Console.WriteLine(num);
}
```
**Advantage:** You don't need to cast objects, as the compiler ensures the correct type at compile time.

---

### **2. Reusability**
With generics, you can write reusable code that works with any data type.

**Example: Generic Class**
```csharp
public class GenericStorage<T> {
    private T _item;

    public void StoreItem(T item) {
        _item = item;
    }

    public T RetrieveItem() {
        return _item;
    }
}

// Usage
var intStorage = new GenericStorage<int>();
intStorage.StoreItem(100);
Console.WriteLine(intStorage.RetrieveItem()); // Output: 100

var stringStorage = new GenericStorage<string>();
stringStorage.StoreItem("Hello Generics!");
Console.WriteLine(stringStorage.RetrieveItem()); // Output: Hello Generics!
```
**Advantage:** The same class works with multiple data types without code duplication.

---

### **3. Performance**
Generics avoid boxing and unboxing, making them faster compared to non-generic collections like `ArrayList`.

**Example: Non-generic vs. Generic**
```csharp
// Using ArrayList (non-generic - requires boxing/unboxing)
ArrayList arrayList = new ArrayList();
arrayList.Add(10); // Boxing
int value = (int)arrayList[0]; // Unboxing

// Using List<T> (generic - no boxing/unboxing)
List<int> list = new List<int>();
list.Add(10);
int genericValue = list[0]; // No boxing/unboxing
```
**Advantage:** Generics improve performance by eliminating the overhead of type conversion.

---

### **4. Generic Methods**
You can create methods that work with different data types.

**Example:**
```csharp
public static void PrintArray<T>(T[] array) {
    foreach (T item in array) {
        Console.WriteLine(item);
    }
}

// Usage
int[] intArray = { 1, 2, 3 };
string[] strArray = { "A", "B", "C" };

PrintArray(intArray); // Output: 1 2 3
PrintArray(strArray); // Output: A B C
```
**Advantage:** Generic methods reduce code duplication by generalizing logic.

---

### **5. Generic Constraints**
Generics can include constraints, making them more flexible and precise.

**Example:**
```csharp
public class Repository<T> where T : class {
    public void Save(T entity) {
        Console.WriteLine($"Saving {entity.GetType().Name}");
    }
}

// Usage
var repo = new Repository<string>();
repo.Save("Example"); // Output: Saving String
```
**Advantage:** Constraints ensure that generics work with specific types or interfaces.

---

Generics simplify code, enhance maintainability, and optimize performance, making them a fundamental feature in modern C# programming. Let me know if you'd like examples for a specific scenario! 🚀




Absolutely! The **SOLID principles** are five key design principles in object-oriented programming that help make software:

- More **maintainable**
- Easier to **extend**
- **Robust** and **flexible**

Let's break them down with simple C# examples:

---

## 🔹 S — **Single Responsibility Principle (SRP)**

> A class should have **only one reason to change**.

### ❌ Bad:
```csharp
class Report {
    public string Generate() { return "Report data"; }
    public void SaveToFile(string data) { File.WriteAllText("report.txt", data); }
}
```

- Mixing **report generation** and **file saving** = 2 responsibilities.

### ✅ Good:
```csharp
class Report {
    public string Generate() => "Report data";
}

class FileSaver {
    public void SaveToFile(string data) => File.WriteAllText("report.txt", data);
}
```

---

## 🔹 O — **Open/Closed Principle (OCP)**

> Software entities should be **open for extension**, but **closed for modification**.

### ❌ Bad:
```csharp
class DiscountCalculator {
    public double GetDiscount(string type) {
        if (type == "Silver") return 0.1;
        if (type == "Gold") return 0.2;
        return 0;
    }
}
```

- Every time a new type is added, we **modify** the method.

### ✅ Good (Using Polymorphism):
```csharp
abstract class Customer {
    public abstract double GetDiscount();
}

class SilverCustomer : Customer {
    public override double GetDiscount() => 0.1;
}

class GoldCustomer : Customer {
    public override double GetDiscount() => 0.2;
}
```

---

## 🔹 L — **Liskov Substitution Principle (LSP)**

> Subtypes must be **substitutable** for their base types without breaking functionality.

### ❌ Bad:
```csharp
class Bird {
    public virtual void Fly() => Console.WriteLine("Flying");
}

class Ostrich : Bird {
    public override void Fly() => throw new Exception("I can't fly");
}
```

- You **can’t substitute** `Ostrich` for `Bird` safely.

### ✅ Good:
```csharp
abstract class Bird { }

class FlyingBird : Bird {
    public void Fly() => Console.WriteLine("Flying");
}

class Ostrich : Bird { }  // Doesn't try to fly
```

---

## 🔹 I — **Interface Segregation Principle (ISP)**

> Clients shouldn't be forced to depend on **methods they don't use**.

### ❌ Bad:
```csharp
interface IWorker {
    void Work();
    void Eat();
}

class Robot : IWorker {
    public void Work() { }
    public void Eat() { throw new NotImplementedException(); }  // Robots don't eat
}
```

### ✅ Good:
```csharp
interface IWorkable {
    void Work();
}

interface IFeedable {
    void Eat();
}

class Human : IWorkable, IFeedable {
    public void Work() { }
    public void Eat() { }
}

class Robot : IWorkable {
    public void Work() { }
}
```

---

## 🔹 D — **Dependency Inversion Principle (DIP)**

> High-level modules should not depend on low-level modules. Both should depend on **abstractions**.

### ❌ Bad:
```csharp
class LightBulb {
    public void TurnOn() => Console.WriteLine("Bulb On");
}

class Switch {
    private LightBulb bulb = new LightBulb();
    public void Operate() => bulb.TurnOn();
}
```

- `Switch` is tightly coupled to `LightBulb`.

### ✅ Good (with Abstraction):
```csharp
interface IDevice {
    void TurnOn();
}

class LightBulb : IDevice {
    public void TurnOn() => Console.WriteLine("Bulb On");
}

class Switch {
    private IDevice device;
    public Switch(IDevice device) => this.device = device;
    public void Operate() => device.TurnOn();
}
```

---

## 💡 TL;DR: SOLID Summary

| Principle | Purpose |
|----------|---------|
| **S** | One class = one job |
| **O** | Extend without modifying |
| **L** | Subclasses should work like the base |
| **I** | Keep interfaces small & focused |
| **D** | Depend on abstractions, not concretes |

---
 
 
 Perfect! Let's talk about two important design patterns in C#:

---

## 🏭 Factory Pattern

> The **Factory Pattern** is used to create objects **without exposing the creation logic** to the client. The client uses a factory method instead of calling `new`.

### 🧠 Use Case:
When you want to **encapsulate object creation**, especially when creating objects is complex or varies by type.

---

### ✅ Factory Pattern Example

#### Step 1: Product Interface
```csharp
public interface IAnimal {
    void Speak();
}
```

#### Step 2: Concrete Products
```csharp
public class Dog : IAnimal {
    public void Speak() => Console.WriteLine("Woof!");
}

public class Cat : IAnimal {
    public void Speak() => Console.WriteLine("Meow!");
}
```

#### Step 3: Factory
```csharp
public class AnimalFactory {
    public static IAnimal GetAnimal(string type) {
        return type switch {
            "Dog" => new Dog(),
            "Cat" => new Cat(),
            _ => throw new ArgumentException("Invalid type")
        };
    }
}
```

#### Step 4: Client Code
```csharp
IAnimal animal = AnimalFactory.GetAnimal("Dog");
animal.Speak();  // Output: Woof!
```

---

## 📦 Repository Pattern

> The **Repository Pattern** is used to **abstract data access logic**. It acts like an in-memory collection and hides the details of the data store.

 
---

### ✅ Repository Pattern Example

#### Step 1: Entity
```csharp
public class Product {
    public int Id { get; set; }
    public string Name { get; set; }
}
```

#### Step 2: Repository Interface
```csharp
public interface IProductRepository {
    void Add(Product product);
    Product GetById(int id);
    List<Product> GetAll();
}
```

#### Step 3: Concrete Repository
```csharp
public class ProductRepository : IProductRepository {
    private List<Product> _products = new();

    public void Add(Product product) => _products.Add(product);
    public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    public List<Product> GetAll() => _products;
}
```

#### Step 4: Using the Repository
```csharp
var repo = new ProductRepository();
repo.Add(new Product { Id = 1, Name = "Laptop" });

var product = repo.GetById(1);
Console.WriteLine(product.Name);  // Output: Laptop
```

---

## 🔁 Bonus: Combine Both

In real apps (like with Entity Framework), the **Factory** can create repositories, and repositories handle data access — keeping logic clean and testable.

---

Would you like me to show how these patterns fit into a layered architecture (like with a Service Layer and Controller)?


Here are some **important questions and answers** related to **.NET Core/Framework differences**, **ASP.NET MVC**, **Entity Framework**, and **Web API concepts**. These will help you prepare for interviews or brush up on key concepts.

---

### **.NET Core vs .NET Framework**
1. **Q: What are the differences between .NET Core and .NET Framework?**  
   **A:**
   - **Platform Support**:  
     - .NET Framework: Works only on Windows.  
     - .NET Core: Cross-platform (Windows, macOS, Linux).  
   - **Performance**:  
     - .NET Core provides better performance due to improvements in JIT and runtime.  
   - **Deployment**:  
     - .NET Framework: Requires installation on the host machine.  
     - .NET Core: Allows self-contained deployment (no runtime installation required).  
   - **Open Source**:  
     - .NET Framework is partially open-source.  
     - .NET Core is fully open-source and backed by Microsoft and the community.  
   - **Use Cases**:  
     - .NET Framework: Ideal for legacy Windows-based applications.  
     - .NET Core: Ideal for modern, scalable, cross-platform applications and cloud services.  

2. **Q: Can you run .NET Framework applications on .NET Core?**  
   **A:** No, you cannot directly run .NET Framework applications on .NET Core, as they target different runtimes. However, you can port them by ensuring compatibility with .NET Standard.

---

### **ASP.NET MVC**
3. **Q: What is ASP.NET MVC?**  
   **A:** ASP.NET MVC is a framework for building web applications using the **Model-View-Controller** (MVC) design pattern. It provides a separation of concerns by dividing the application into:
   - **Model**: Represents the data or business logic.
   - **View**: Handles the UI or presentation layer.
   - **Controller**: Processes user requests and coordinates between the model and view.

4. **Q: What are the benefits of ASP.NET MVC over Web Forms?**  
   **A:**
   - No ViewState: Lighter and more performant.
   - Full control over HTML.
   - Easier integration with modern client-side frameworks like Angular, React, etc.
   - Built-in support for unit testing.

5. **Q: How does routing work in ASP.NET MVC?**  
   **A:** Routing is handled by the `RouteConfig` file, where URL patterns map to specific controllers and actions.
   **Example:**
   ```csharp
   routes.MapRoute(
       name: "Default",
       url: "{controller}/{action}/{id}",
       defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
   );
   ```

6. **Q: What are Action Filters in ASP.NET MVC?**  
   **A:** Action Filters are attributes used to execute custom logic before or after an action method runs.  
   **Example:** `[Authorize]`, `[HandleError]`, `[OutputCache]`.

---

### **Entity Framework**
7. **Q: What is Entity Framework (EF)?**  
   **A:** EF is an Object-Relational Mapper (ORM) for .NET applications, allowing developers to interact with databases using .NET objects instead of SQL queries.

8. **Q: What are the approaches in Entity Framework?**  
   **A:**
   - **Code-First**: Define the model in code and EF generates the database schema.
   - **Database-First**: Reverse-engineer an existing database to generate models.
   - **Model-First**: Create an EDMX diagram to define the model, and EF generates the database.

9. **Q: How does Lazy Loading work in EF?**  
   **A:** Lazy Loading loads related data on demand. When accessing a navigation property for the first time, EF sends a query to the database to load the data.
   **Example:**
   ```csharp
   var order = context.Orders.Find(1);
   var items = order.OrderItems; // Lazy loading triggers here
   ```

10. **Q: What is the difference between Lazy Loading, Eager Loading, and Explicit Loading in EF?**  
    **A:**
    - **Lazy Loading**: Related data is loaded only when accessed.
    - **Eager Loading**: Related data is loaded upfront using the `Include()` method.
    - **Explicit Loading**: Load related data explicitly using the `Load()` method.

11. **Q: What is Migration in Entity Framework?**  
    **A:** Migration is a feature that manages schema changes in a database in sync with the data model.
    **Example Commands:**
    ```bash
    Add-Migration InitialCreate
    Update-Database
    ```

---

### **Web API Concepts**
12. **Q: What is ASP.NET Web API?**  
    **A:** ASP.NET Web API is a framework for building RESTful services that support HTTP verbs like GET, POST, PUT, DELETE. It is used to expose data to web applications or clients.

13. **Q: How do you create a Web API controller?**  
    **A:** Inherit the `ApiController` class and define HTTP action methods.
    **Example:**
    ```csharp
    public class ProductsController : ApiController {
        public IEnumerable<Product> Get() {
            return products;
        }
        public Product Get(int id) {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
    ```

14. **Q: What is the difference between ASP.NET MVC and Web API?**  
    **A:**
    - **Purpose**:
      - MVC: Focuses on delivering HTML for user interfaces.
      - Web API: Focuses on exposing services as REST APIs for consumption.
    - **Base Class**:
      - MVC: Inherits from `Controller`.
      - Web API: Inherits from `ApiController`.
    - **Return Types**:
      - MVC: Typically returns `ViewResult` or `JsonResult`.
      - Web API: Returns data objects like `IHttpActionResult` or serialized JSON/XML.

15. **Q: How do you secure a Web API?**  
    **A:**
    - Use **JWT (JSON Web Tokens)** for authentication and authorization.
    - Implement **OAuth 2.0**.
    - Apply HTTPS for secure communication.
    - Use custom authorization filters for role-based access control.

16. **Q: What is Dependency Injection in Web API?**  
    **A:** Dependency Injection ensures loosely coupled code by injecting services into controllers.
    **Example:**
    ```csharp
    public ProductsController(IProductService productService) {
        _productService = productService;
    }
    ```

17. **Q: How do you version Web APIs?**  
    **A:**
    - Use **URL Path**: `/api/v1/products`
    - Use **Query String**: `/api/products?version=1`
    - Use **HTTP Headers**: `Version: 1.0`

---

This set of questions provides a solid foundation for interviews or practical understanding of key concepts. Let me know if you need more explanations or examples for any of these! 🚀


Here’s a list of important Angular-related questions and answers to help you understand **components**, **services**, **modules**, and **RxJS** concepts:

---

### **Angular Components**
1. **Q: What is an Angular component? How do you create one?**  
   **A:**  
   An Angular component is the building block of the UI. It controls a portion of the screen, defines the data, and binds it to the HTML template.  
   **Example:**
   ```typescript
   import { Component } from '@angular/core';

   @Component({
       selector: 'app-example',
       template: `<h1>Hello, Angular!</h1>`,
       styleUrls: ['./example.component.css']
   })
   export class ExampleComponent { }
   ```

2. **Q: What is the role of the `@Component` decorator?**  
   **A:**  
   The `@Component` decorator marks a class as an Angular component and provides metadata such as:
   - `selector`: Defines the custom HTML tag for the component.
   - `template`: HTML content for the view.
   - `styleUrls`: CSS files for styling.

3. **Q: What is data binding in Angular components?**  
   **A:**  
   Data binding connects component properties with the DOM. Types include:
   - **Interpolation (`{{ }}`)**: Bind property values.
   - **Property Binding (`[property]`)**: Update DOM properties.
   - **Event Binding (`(event)`)**: Handle user events.
   - **Two-way Binding (`[(ngModel)]`)**: Synchronize data between UI and component.

---

### **Angular Services**
4. **Q: What is an Angular service and why is it used?**  
   **A:**  
   A service is a reusable class that encapsulates logic not directly related to the view (e.g., data fetching, business logic). It promotes **dependency injection** and code reusability.  
   **Example:**
   ```typescript
   import { Injectable } from '@angular/core';

   @Injectable({
       providedIn: 'root'
   })
   export class DataService {
       getData() {
           return ['Item1', 'Item2', 'Item3'];
       }
   }
   ```

5. **Q: How do you inject a service into a component?**  
   **A:**  
   Use the **constructor** of the component to inject the service.  
   **Example:**
   ```typescript
   import { Component } from '@angular/core';
   import { DataService } from './data.service';

   @Component({
       selector: 'app-example',
       template: `<ul><li *ngFor="let item of items">{{ item }}</li></ul>`
   })
   export class ExampleComponent {
       items: string[];

       constructor(private dataService: DataService) {
           this.items = dataService.getData();
       }
   }
   ```

---

### **Angular Modules**
6. **Q: What is an Angular module? How do you define one?**  
   **A:**  
   A module is a container for related components, services, directives, and pipes. It uses the `@NgModule` decorator.  
   **Example:**
   ```typescript
   import { NgModule } from '@angular/core';
   import { BrowserModule } from '@angular/platform-browser';
   import { AppComponent } from './app.component';

   @NgModule({
       declarations: [AppComponent],
       imports: [BrowserModule],
       bootstrap: [AppComponent]
   })
   export class AppModule { }
   ```

7. **Q: What are the key properties of `@NgModule`?**  
   **A:**  
   - `declarations`: Components, directives, and pipes defined in the module.
   - `imports`: Other modules required.
   - `providers`: Services made available.
   - `bootstrap`: The root component to initialize the app.

8. **Q: What is lazy loading in Angular modules?**  
   **A:**  
   Lazy loading defers loading of feature modules until they're needed, improving performance. It is implemented using the `RouterModule`.  
   **Example:**
   ```typescript
   const routes = [
       { path: 'feature', loadChildren: () => import('./feature/feature.module').then(m => m.FeatureModule) }
   ];
   ```

---

### **RxJS**
9. **Q: What is RxJS and how is it used in Angular?**  
   **A:**  
   RxJS (Reactive Extensions for JavaScript) is a library for reactive programming using **Observables**. Angular leverages RxJS for asynchronous operations like HTTP requests and event handling.

10. **Q: What is an Observable? How is it different from a Promise?**  
    **A:**  
    - **Observable**: A stream of values emitted over time. It supports multiple values and is cancellable.
    - **Promise**: Represents a single value that resolves or rejects.

    **Example (Observable):**
    ```typescript
    import { Observable } from 'rxjs';

    const observable = new Observable(observer => {
        observer.next('Hello');
        observer.next('World');
        observer.complete();
    });

    observable.subscribe(value => console.log(value));
    ```

11. **Q: What are operators in RxJS? Give examples.**  
    **A:**  
    Operators transform, filter, or combine Observable streams.
    - **Map**: Transform emitted values.
    - **Filter**: Emit values based on a condition.
    - **MergeMap**: Flatten nested Observables.

    **Example:**
    ```typescript
    import { of } from 'rxjs';
    import { map } from 'rxjs/operators';

    of(1, 2, 3).pipe(
        map(value => value * 2)
    ).subscribe(console.log); // Output: 2, 4, 6
    ```

12. **Q: How do you handle HTTP requests using RxJS in Angular?**  
    **A:**  
    Use Angular's `HttpClient` with RxJS Observables.
    **Example:**
    ```typescript
    import { HttpClient } from '@angular/common/http';
    import { Component } from '@angular/core';

    @Component({
        selector: 'app-example',
        template: `<ul><li *ngFor="let user of users">{{ user.name }}</li></ul>`
    })
    export class ExampleComponent {
        users: any[];

        constructor(private http: HttpClient) {
            this.http.get('https://jsonplaceholder.typicode.com/users')
                .subscribe(data => this.users = data);
        }
    }
    ```

---

These questions and examples cover key Angular basics that are essential for building scalable applications. Let me know if you need further explanations or more advanced topics! 🚀


The of operator in RxJS is a creation operator that creates an Observable from a sequence of values. It emits the values one by one and then completes. This operator is commonly used to create Observables from static data.

import { of } from 'rxjs';

const observable = of(1, 2, 3, 4, 5);

observable.subscribe({
    next: value => console.log(value), // Logs each value
    complete: () => console.log('Completed') // Logs when the Observable completes
});


State management in Angular refers to handling and maintaining the application's state (data) across components and services. As applications grow in complexity, managing state effectively becomes crucial for ensuring consistency, scalability, and maintainability.

---

### **Key Concepts of State Management in Angular**
1. **State**: Represents the data of your application (e.g., user information, API responses, UI states).
2. **Actions**: Define how the state changes (e.g., user login, data fetch).
3. **Reducers**: Specify how actions transform the state.
4. **Selectors**: Extract specific parts of the state for use in components.

---

### **Approaches to State Management in Angular**

#### **1. Service-Based State Management**
- The simplest approach using Angular services and observables.
- Suitable for small to medium-sized applications.

**Example:**
```typescript
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class StateService {
    private stateSubject = new BehaviorSubject<string>('Initial State');
    state$ = this.stateSubject.asObservable();

    updateState(newState: string) {
        this.stateSubject.next(newState);
    }
}
```

**Usage in Component:**
```typescript
import { Component } from '@angular/core';
import { StateService } from './state.service';

@Component({
    selector: 'app-example',
    template: `<div>{{ state$ | async }}</div>`
})
export class ExampleComponent {
    state$ = this.stateService.state$;

    constructor(private stateService: StateService) {
        this.stateService.updateState('Updated State');
    }
}
```

---

#### **2. NgRx (Redux-Inspired State Management)**
- A powerful library for managing state in Angular applications.
- Implements a unidirectional data flow using **Store**, **Actions**, **Reducers**, and **Effects**.

**Example:**
```typescript
// Action
import { createAction } from '@ngrx/store';
export const updateState = createAction('[State] Update');

// Reducer
import { createReducer, on } from '@ngrx/store';
export const stateReducer = createReducer(
    'Initial State',
    on(updateState, (state, { newState }) => newState)
);

// Selector
import { createSelector } from '@ngrx/store';
export const selectState = createSelector(
    (state: any) => state,
    (state) => state.state
);

// Component
import { Store } from '@ngrx/store';
@Component({
    selector: 'app-example',
    template: `<div>{{ state$ | async }}</div>`
})
export class ExampleComponent {
    state$ = this.store.select(selectState);

    constructor(private store: Store) {
        this.store.dispatch(updateState({ newState: 'Updated State' }));
    }
}
```

---

#### **3. Angular Signals (Introduced in Angular 16+)**
- A new reactive state management approach using **signals** and **computed signals**.

**Example:**
```typescript
import { Injectable, signal, computed } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class SignalService {
    count = signal(0);
    doubleCount = computed(() => this.count() * 2);

    increment() {
        this.count.update(value => value + 1);
    }
}
```

**Usage in Component:**
```typescript
import { Component } from '@angular/core';
import { SignalService } from './signal.service';

@Component({
    selector: 'app-counter',
    template: `
        <div>Count: {{ signalService.count() }}</div>
        <div>Double Count: {{ signalService.doubleCount() }}</div>
        <button (click)="signalService.increment()">Increment</button>
    `
})
export class CounterComponent {
    constructor(public signalService: SignalService) {}
}
```

---

### **When to Use State Management Libraries**
- **Simple Applications**: Use service-based state management.
- **Complex Applications**: Use libraries like **NgRx** or **NGXS** for better scalability and maintainability.
- **Reactive Applications**: Use **Angular Signals** for modern reactive state handling.

Let me know if you'd like to dive deeper into any of these approaches! 🚀


Absolutely! Here’s a curated list of **SQL Interview Questions with Answers** tailored for someone with **10+ years of experience** — covering **performance**, **architecture**, **querying**, and **best practices**.

---

## 🔍 1. **How do you identify and resolve a slow-running SQL query?**

**Answer:**
- Start with **execution plan** (`EXPLAIN` or `SHOWPLAN`).
- Look for: table scans, missing indexes, high I/O cost.
- Use tools like **SQL Profiler**, **Query Store**, or **DMVs** (in SQL Server).
- Optimize: rewrite query, add indexes, avoid functions on indexed columns.

---

## 🧱 2. **What’s the difference between clustered and non-clustered indexes?**

**Answer:**
- **Clustered Index**:
  - Sorts and stores data rows **physically**.
  - One per table.
- **Non-Clustered Index**:
  - Separate structure with pointers to the data.
  - Can have **many** per table.

✅ Tip: Clustered index is best for **range queries** and **frequent sorting**.

---

## 🧠 3. **What are isolation levels? What are the trade-offs?**

**Answer:**
| Level              | Issues Prevented          | Concurrency | Notes                        |
|-------------------|---------------------------|-------------|------------------------------|
| Read Uncommitted  | ❌ None                    | ✅ High     | Allows dirty reads           |
| Read Committed    | ✅ Dirty reads             | ⚖️ Medium   | Default in most DBs          |
| Repeatable Read   | ✅ Dirty, non-repeatable   | 🚧 Slower   | Phantom reads still possible |
| Serializable      | ✅ All                     | ❌ Slow     | Highest isolation            |
| Snapshot          | ✅ All except write skew   | ⚡ High     | Uses versioning (MVCC)       |

---

## 🛠️ 4. **When should you use a stored procedure vs function vs view?**

**Answer:**
- **Stored Procedure**: for business logic, transactions, batch operations.
- **Function**: reusable logic returning a value; can't change DB state (scalar or table-valued).
- **View**: for reusable query logic; can be indexed (materialized).

---

## 🔄 5. **Write a query to get the second highest salary from an employee table.**

```sql
SELECT MAX(Salary) 
FROM Employees 
WHERE Salary < (SELECT MAX(Salary) FROM Employees);
```

**Alternate (using ROW_NUMBER):**
```sql
WITH Ranked AS (
  SELECT Name, Salary, ROW_NUMBER() OVER (ORDER BY Salary DESC) AS rn
  FROM Employees
)
SELECT * FROM Ranked WHERE rn = 2;
```

---

## ⚡ 6. **How do you avoid or resolve a deadlock in SQL Server?**

**Answer:**
- **Avoid** locking hierarchy conflicts.
- Use `SET DEADLOCK_PRIORITY LOW` to let non-critical queries give way.
- Keep transactions short.
- Use **sp_who2**, **SQL Profiler**, or `sys.dm_tran_locks` to detect.
- Index properly to avoid full table scans.

---

## 🗂️ 7. **What is a covering index?**

**Answer:**
- An index that contains **all the columns** needed by a query.
- Eliminates the need to access the table (no key lookup).
- Speeds up **SELECT** performance.

```sql
-- Example:
CREATE INDEX IX_Employee_Covering ON Employees (LastName, FirstName, Department);
```

---

## 📈 8. **How do you monitor database performance in production?**

**Answer:**
- Use tools like **SQL Profiler**, **Extended Events**, **Query Store**.
- Monitor:
  - Slow queries
  - Blocking/deadlocks
  - Index usage (sys.dm_db_index_usage_stats)
  - Wait stats (sys.dm_os_wait_stats)

---

## 📊 9. **What is partitioning? When would you use it?**

**Answer:**
- Partitioning splits a table into **smaller chunks** for performance/scalability.
- Types: **Range**, **List**, **Hash**.
- Use when:
  - Large data (millions+ rows)
  - Need fast deletes by date (e.g., logs)
  - Improve maintenance (rebuild partitions separately)

---

## 🧬 10. **Explain normalization vs denormalization.**

**Answer:**
- **Normalization**: remove redundancy, ensure data integrity.
  - 1NF: atomic columns
  - 2NF: no partial dependencies
  - 3NF: no transitive dependencies

- **Denormalization**: add redundancy for **read performance**, fewer joins.

✅ Use denormalization for reporting, OLAP, dashboards.

---

Want more scenario-based or system-design level questions? Or maybe a printable cheat sheet PDF version of this?



Definitely! Here are some of the **most frequently asked SQL query logic questions** that test your understanding of joins, subqueries, aggregations, and real-world data manipulation — commonly used in interviews at **all levels**, especially senior roles.

---

## 🔥 **Top SQL Query Logic Questions (Frequently Asked)**

---

### ✅ 1. **Find the second highest salary from the Employee table**

```sql
SELECT MAX(Salary)
FROM Employees
WHERE Salary < (SELECT MAX(Salary) FROM Employees);
```

---

### ✅ 2. **Get the list of employees who earn more than their manager**

```sql
SELECT e.Name
FROM Employees e
JOIN Employees m ON e.ManagerID = m.ID
WHERE e.Salary > m.Salary;
```

---

### ✅ 3. **Find duplicate records in a table**

```sql
SELECT Name, COUNT(*) AS count
FROM Employees
GROUP BY Name
HAVING COUNT(*) > 1;
```

---

### ✅ 4. **Retrieve employees with the Nth highest salary (e.g., 3rd highest)**

```sql
SELECT DISTINCT Salary
FROM Employees e1
WHERE 3 = (
  SELECT COUNT(DISTINCT Salary)
  FROM Employees e2
  WHERE e2.Salary >= e1.Salary
);
```

---

### ✅ 5. **Find departments with more than 5 employees**

```sql
SELECT DepartmentID, COUNT(*) AS EmpCount
FROM Employees
GROUP BY DepartmentID
HAVING COUNT(*) > 5;
```

---

### ✅ 6. **Get employees who don’t have a manager**

```sql
SELECT *
FROM Employees
WHERE ManagerID IS NULL;
```

---

### ✅ 7. **List employees who joined in the last 3 months**

```sql
SELECT *
FROM Employees
WHERE JoinDate >= DATEADD(MONTH, -3, GETDATE());
```

---

### ✅ 8. **Find the employee(s) with the highest salary in each department**

```sql
SELECT *
FROM Employees e
WHERE Salary = (
  SELECT MAX(Salary)
  FROM Employees
  WHERE DepartmentID = e.DepartmentID
);
```

---

### ✅ 9. **Write a query to transpose rows to columns (pivot)**

```sql
SELECT 
  DepartmentID,
  MAX(CASE WHEN Gender = 'Male' THEN 1 ELSE 0 END) AS Male,
  MAX(CASE WHEN Gender = 'Female' THEN 1 ELSE 0 END) AS Female
FROM Employees
GROUP BY DepartmentID;
```

---

### ✅ 10. **Show a running total of salaries**

```sql
SELECT 
  Name,
  Salary,
  SUM(Salary) OVER (ORDER BY JoinDate) AS RunningTotal
FROM Employees;
```

---

Want these in a downloadable PDF or cheat sheet format? Or shall I include some **recursive CTE/tree traversal** examples next





Two Sum

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> numMap = new Dictionary<int, int>();

        for(int i =0; i < nums.Length; i++)
        {
            var complement = target - nums[i];

            if(numMap.ContainsKey(complement))
            {
                return new int[] {numMap[complement], i};
            } 
            numMap[nums[i]] = i;
        }

        return new int[] {};
    }
}


add numbers

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var result = new ListNode();
        var tmp = result;
        var carry = 0;
        while (l1 != null || l2 != null || c != 0)
        {
            var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + c;
            c = sum / 10;
            
            if (sum > 9)
                sum %= 10;

            tmp.next = new ListNode(sum);
            tmp = tmp.next;
            
            l1 = l1?.next;
            l2 = l2?.next;
        }

        return result.next;
    }
}




Perfect! Here’s a solid set of **Data Structures and Algorithms (DSA)** questions that are frequently asked in technical interviews and coding assessments (like HackerRank, LeetCode, and system design rounds). Each problem includes the **type**, **difficulty**, and a **brief solution idea**.

---

## 🧠 **Top DSA & Algorithm Interview Questions (with Brief Answers)**

---

### 🔹 1. **Two Sum (Array, Hashing)**  
**Level:** Easy  
**Problem:** Find two numbers in an array that add up to a target.

```csharp
public int[] TwoSum(int[] nums, int target) {
    var map = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++) {
        int complement = target - nums[i];
        if (map.ContainsKey(complement))
            return new[] { map[complement], i };
        map[nums[i]] = i;
    }
    return new int[0];
}
```

---

### 🔹 2. **Reverse a Linked List**  
**Level:** Easy  
**Topic:** Linked List

```csharp
public ListNode ReverseList(ListNode head) {
    ListNode prev = null;
    while (head != null) {
        ListNode next = head.next;
        head.next = prev;
        prev = head;
        head = next;
    }
    return prev;
}
```

---

### 🔹 3. **Detect Cycle in Linked List**  
**Level:** Medium  
**Approach:** Floyd’s Tortoise and Hare Algorithm

```csharp
public bool HasCycle(ListNode head) {
    var slow = head;
    var fast = head;
    while (fast != null && fast.next != null) {
        slow = slow.next;
        fast = fast.next.next;
        if (slow == fast) return true;
    }
    return false;
}
```

---

### 🔹 4. **Valid Parentheses (Stack)**  
**Level:** Easy  

```csharp
public bool IsValid(string s) {
    var stack = new Stack<char>();
    foreach (var c in s) {
        if (c == '(') stack.Push(')');
        else if (c == '{') stack.Push('}');
        else if (c == '[') stack.Push(']');
        else if (stack.Count == 0 || stack.Pop() != c) return false;
    }
    return stack.Count == 0;
}
```

---

### 🔹 5. **Merge Intervals**  
**Level:** Medium  
**Type:** Sorting + Greedy

```csharp
public int[][] Merge(int[][] intervals) {
    Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
    var merged = new List<int[]>();
    foreach (var interval in intervals) {
        if (merged.Count == 0 || merged.Last()[1] < interval[0])
            merged.Add(interval);
        else
            merged.Last()[1] = Math.Max(merged.Last()[1], interval[1]);
    }
    return merged.ToArray();
}
```

---

### 🔹 6. **Binary Search**  
**Level:** Easy

```csharp
public int BinarySearch(int[] arr, int target) {
    int low = 0, high = arr.Length - 1;
    while (low <= high) {
        int mid = (low + high) / 2;
        if (arr[mid] == target) return mid;
        else if (arr[mid] < target) low = mid + 1;
        else high = mid - 1;
    }
    return -1;
}
```

---

### 🔹 7. **Find First Non-Repeating Character**  
**Level:** Easy

```csharp
public int FirstUniqChar(string s) {
    var dict = new Dictionary<char, int>();
    foreach (char c in s) dict[c] = dict.GetValueOrDefault(c, 0) + 1;
    for (int i = 0; i < s.Length; i++)
        if (dict[s[i]] == 1) return i;
    return -1;
}
```

---

### 🔹 8. **Longest Substring Without Repeating Characters**  
**Level:** Medium  
**Type:** Sliding Window

```csharp
public int LengthOfLongestSubstring(string s) {
    var set = new HashSet<char>();
    int left = 0, maxLen = 0;
    for (int right = 0; right < s.Length; right++) {
        while (set.Contains(s[right])) set.Remove(s[left++]);
        set.Add(s[right]);
        maxLen = Math.Max(maxLen, right - left + 1);
    }
    return maxLen;
}
```

---

### 🔹 9. **DFS/BFS Traversal (Graph)**  
**Level:** Medium  
**Type:** Recursion / Queue

```csharp
// DFS
void DFS(Dictionary<int, List<int>> graph, int node, HashSet<int> visited) {
    if (visited.Contains(node)) return;
    visited.Add(node);
    foreach (var neighbor in graph[node])
        DFS(graph, neighbor, visited);
}
```

---

### 🔹 10. **Top K Frequent Elements**  
**Level:** Medium  
**Type:** Heap / Dictionary

```csharp
public int[] TopKFrequent(int[] nums, int k) {
    var freq = nums.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
    return freq.OrderByDescending(x => x.Value).Take(k).Select(x => x.Key).ToArray();
}
```

---

## ➕ BONUS: Want More Topics?

I can provide challenges and explanations for:
- Dynamic Programming (DP)
- Recursion & Backtracking
- Binary Trees & BST
- Tries, Heaps, Hashmaps
- Sliding Window, Two Pointer
- Greedy algorithms
- System Design with DSA elements

Let me know what you'd like next: PDF notes, topic-wise breakdown, or mock test sets?
