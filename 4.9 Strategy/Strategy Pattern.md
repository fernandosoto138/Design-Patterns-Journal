# Strategy

> Definition : Define a family of algorithms, encapsulate each one, and make them interchange­able. Strategy lets the algorithm vary independently from clients that use it.

## Problems to Solve

- Avoid Hard-Wired Algorithms by encapsulating them : Instead of code and algorithm directy in a class, create a new class what contains that code. This will help you to switch that algorithms.
- Avoid conditional parameters : if your method have multiples algorithms inside for one purpose, you need a way to switch them, and instead of put conditional or true/false parameters in that, you can delegate an strategy for apply an specific algorithm.
- Complicated classes with a lot of algorithms : Instead of have a class with a lot of algorithms for the same or related tasks, consider using one class for each one.

## Applications

- Change algorithms in run time : for example you are creating a Login for your application and there's multiple ways for that. Is not the same algorithm if you are taking an user and password instead of a facebook-login.
- Refactoring tasks :
  - Converting hard-wired algorithms into reusable classes.
  - Replacing conditional statements with strategies.

## Solution

The Strategy Pattern proposes the following :

- You have a `context` what is the place where the strategies are called.
- Then you need a `Strategy Interface` to implement in the specifict strategies.
- And in third place you will have `strategy 1`, `strategy2` and more... what implements the strategy interface.

<img src="https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/resources/images/StrategyUML.jpg?raw=true" style="display:block;margin:auto;" height="250" > <br/>

## Example

Suppose what you are building a kind of rustic paycheck generator and you want to be capable of export that in HTML or in markdown (for simplicity purposes of course). 

So, you need a strategy for generate HTML and other for markdown. Firstly we'll code an interface for achieve that:

```C#
interface IDocStrategy
{
    StringBuilder sb { get; }
    IDocStrategy AddText(string text);
    IDocStrategy AddList(IEnumerable items);
    string GenerateDoc();
}
```
With this very simple interface we created two strategies :

```C#
class HtmlGenerator : IDocStrategy
{
    public StringBuilder sb { get; private set; } = new StringBuilder();
    public IDocStrategy AddText(string text)
    {
        sb.AppendLine($"<p>{text}</p>");
        return this; 
    }
    public IDocStrategy AddList(IEnumerable items)
    {
        sb.AppendLine("<ul>");
        foreach(var item in items)
            sb.AppendLine($"  <li>{item}</li>");
        sb.AppendLine("</ul>");
        return this;
    }
    public string GenerateDoc() => sb.ToString();
}
class MarkdownGenerator : IDocStrategy
{
    public StringBuilder sb { get; private set; } = new StringBuilder();
    public IDocStrategy AddText(string text)
    {
        sb.AppendLine(text);
        return this; 
    }
    public IDocStrategy AddList(IEnumerable items)
    {
        sb.AppendLine("");
        foreach(var item in items)
            sb.AppendLine($"- {item}");
        sb.AppendLine("");
        return this;
    }
    public string GenerateDoc() => sb.ToString();
}
```

Very simple implementations, which are used by the `Paycheck` class : 

```C#
class PayCheck
{
    public static void GeneratePaycheck (IDocStrategy OutputFormat, string name, IEnumerable Payments)
    {
        string separator = "--------i-am-a-rustic-separator-bar--------";
        OutputFormat.AddText($"Name : {name}");
        OutputFormat.AddText(separator);
        OutputFormat.AddList(Payments);
        OutputFormat.AddText(separator);
        Console.WriteLine(OutputFormat.GenerateDoc());
    }
}
```

Note what we've used Dependency Injection for the `IDocStrategy` interface. I see this way a better approach instead of switching the strategies with a switch-case, because with that you are coupling the client with the strategies. But if you use dependency injection you can extend the output formats possible of the `Paycheck`class. 

In the main we've this code:

```C#
string person = "John Doe";
List<string> payments = new List<string>();
payments.Add("Salary : + 3.000");
payments.Add("Extra hours : + 500");
payments.Add("Income Tax : - 500");
payments.Add("Total : 3.000");
PayCheck.GeneratePaycheck(new MarkdownGenerator(), person, payments);
PayCheck.GeneratePaycheck(new HtmlGenerator(), person, payments);
```

There are hard-coded some chunks of data to test the different strategies and you can see the two outputs in the console, one in markdown and the other in HTML.
