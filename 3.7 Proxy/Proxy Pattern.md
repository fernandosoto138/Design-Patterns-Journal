# Pattern Name

> Definition : Provide a surrogate or placeholder for another object to control access to it. [GoF]

## Problems to Solve

- How to control the access of an object?
- How to add functionality when accessing to the object?

The data of an object isn't inside the program, usually it's in remote place. But what's the problem here? the responsabilities. You need a way to bind this data layer with a business layer in different classes, else you are breaking with SRP. For example this :

```C#
//This is sample code, not real code, keep in mind the concept.
class Product
{
    public int Id { get; private set;}
    public double Price {get; private set;}
    public Product(int id)
    {
        var sql = $"SELECT price FROM products WHERE prodId={id}";
        this.Price = double.Parse(Database.Execute(sql));
        this.Id = id;
    }
}
```

This class products have two responsabilities: deal with the database and the processing of the model Product. That will be a serious problem in the maintainability of your code. The proxy pattern will help us with problems like this. 

## Solution

When you have identified the class which need some type special access (our `RealSubject`), create other class called `ProxySubject` which will call the operations of `RealSubject` but adding the logic for access it.

<img src="https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/resources/images/ProxyUML.jpg?raw=true" style="display:block;margin:auto;" height="250" > <br/>

## Applications

There's various types of proxy applications:

- Virtual Proxy: it's a placeholder for big objects which are instantiated when you use it for the first time. In the .NET Framework there's a `Lazy<T>` class which provides this virtual proxy also called Lazy Loading.
- Remote Proxy: encapsulates the communication for accessing objects in remote places. Such as in remote databases.
- Protection Proxy: should be used when you have a sensitive object and you need to know if the client have the required access rights.

## Relations with other patterns

Decorator Design Pattern - You should not mix the proxy with the decorator, because you are not adding more functionalities to an object.

## Example

In this example we will implement a proxy example in a _very simple way_. We don't take care of exceptions and verifications to make the pattern easy to see.

Suppose what you need to load the price of a product in a database. Like the example of the "Problems to solve" section. And you decide to implement a proxy to do that, because the price it's variable in the time and you need to access the database every time that you need the object, you can't have it cached in some place.

The database it's very poor but it's for keep the code simple: 
```C#
public class Db
{
    private static Dictionary<string,double> Products = 
                    new Dictionary<string,double>();
    public static void LoadData()
    {
        Products.Add("Milk",1.0D);
        Products.Add("Eggs",2.0D);
        Products.Add("Apples",0.5D);
        Products.Add("Paint",10D);
        Products.Add("Notebook", 350.5D);
    }
    public static Product GetProduct(string Name) => new Product(Name,Products[Name]);
}
```

What you need to reach it's the Product:

```C#
interface IProduct
{
    string Name { get; }
    double Price { get; }
}
public class Product : IProduct
{
    public string Name { get; private set;}
    public double Price { get; private set;}
    public Product(string Name, double Price)
    {
        this.Name = Name;
        this.Price = Price;
    }
}
```

Then you need to access the price every time you need the product, so your proxy class will be:

```C#
class ProductProxy : IProduct
{
    public string Name { get; private set;}
    public ProductProxy(string Name) => this.Name = Name;
    public double Price { get => Db.GetProduct(Name).Price; }
}
```

The magic happens in the `Db.GetProduct(Name).Price;` command. If you see the UML diagram you have noticed that the Proxy calls some operation of the `RealSubject`, in this case `Db.GetProduct` returns a `Product` object, and you are accessing their `Price` property.