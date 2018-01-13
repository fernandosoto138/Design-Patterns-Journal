# Prototype

> Definition : Specify the kinds of objects to create using a prototypical instance, 
and create new objects by copying this prototype [ref1]

## Problems to Solve

- How can I make a deep copy an object?

## Applications

This pattern helps us in two very insteresting points:

- When you are copying an object you are not re-initializing it. This can be very useful because some objects needs a lot of configuration to work and the process of make a deep copy of them improves performance and code design instead of re-configure it. For exaple an object can load a large document of internet and for make some process to it it's need to be parsed and proccesed. This can be a time consuming task and if you need another object with the same information, it's better to copy it instead of a reload.
- You can avoid to break DIP multiple times. Because you are not creating an object with the `new` keyword.

## Solution

The classic solution proposes what you need to generate a `prototype interface` with a `clone` method, and every object can implement this pattern inheriting that interface and implementing the clone method. Some languages have this interface called `clonable` or `IClonable` interface for default.

In the C# case the `IClonable` interface is not a good option, because it does not indicates what type of copy it's doing, you can't know if you are swallow copying(copy the reference of the object) or deep copying( copy the entire instance of the object and make another identical). Then a good way to implement this pattern, which in my opinion it's more like an extra functionlity instead of a pattern, it's by extensions methods.

## Example

This example is a very simple extension method which serialize an object and deserializes it for make a deep copy. You can serialize it in two principal ways, one is with a `BinaryFormatter` class and other with a `XmlSerializer` class. But there's better performance in a binary way, also the `XmlSerializer` class needs what the class have the attribute `[Serializable]`. You might use Xml serializations if you needs to share the object with general environment, because the object information is easy-readable instead of a binary form, but it's not the point of the prototype pattern. 

So, this is the code of an extension method for make deep-copy in binary form. You can see an Xml way in the code.

```C#
public static class ExtensionMethods
{
    public static T DeepCopy<T>(this T self)
    {
        MemoryStream stream = new MemoryStream();
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, self);
        // sets the position within the current stream to the specified value.
        stream.Seek(0, SeekOrigin.Begin);
        object copy = formatter.Deserialize(stream);
        stream.Close();
        return (T)copy;
    }
}
```
