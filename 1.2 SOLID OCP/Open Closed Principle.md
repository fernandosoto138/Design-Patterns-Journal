# Open Closed Principle

> Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification

## ¿Why this is important? 

Because if we don't think in this principle, when we need to add some functionality, ¿What we will do? we will go to the class and add a bunch of new methods or change existing methods for add that new features. So, we'll need to test again the class and maybe write new tests before make changes. And in the future maybe we'll to add more features and repeat the whole process, in the future the class will be huge and complicated.

First, we will start with a simple example: 

Suppose you are developing a software for a farm, and you can get a list of the products to sell. 

For now, the farm only produces Apples, and the price depends on size and weight. 

So, you can implement a code like this: 

```C#
class PriceCalculator 
{
    public static double CalcPrice(List<Apple> ProductList)
    {
        double price = 0;
        foreach(var apple in ProductList)
        {
            price += apple.Price;
        }
        return price;
    }
}
```
What's the problem here? The solution works, but the requirementes could change. So image what the farm now produces Apples and Carrots. So, this class is programmed in a way what is too coupled to the class Apple. This breaks the OCP, because we cant extend the functionality of that class, we need to modify it for any change. 

¿How you can solve that? One way is implementing an IProduct Interface

```C#
interface IProduct
{
    Maturation Ripe {get ;}
    double Weight {get;}
    double PricePerKg{get;}
    double Price{get;}
    string Name{get; set;}
}
```
So, you can implement that interface in out Apple and Carrot clases and next, instead of using a `List<Apple>` now, we can use a `List<IProduct>` :

```C#
class PriceCalculator 
{
    public static double CalcPrice(List<IProduct> ProductList)
        {
            double price = 0;
            foreach(var product in ProductList)
            {
                price += product.Price;
                System.Console.WriteLine($"Product:{product.Name} \t Value:{product.Price} \t Subtotal:{price}");
            }
            return price;
        }
}
```
Now, the list can contain any object what have implemented IProduct interface. 


http://joelabrahamsson.com/a-simple-example-of-the-openclosed-principle/