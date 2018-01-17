# Composite

> Definition : Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly. [GoF]

This pattern is quite simple to understand if you think that part like the leafs of a tree structure and the whole like a collection of leafs.

## Problems to Solve

- How can I create a tree structure that parts and wholes be treated uniformely?

How this pattern come about? The reason was very simple. Imagine that you have a class called `Part` and other called `BunchOfParts` (it's the whole of the definition) and this last class have a list of Parts inside. The responsability of `BunchOfParts` is made an operation with every `Part`.

It seems to work fine and you are happy. But in a time you realises that you need a collection of `BunchOfParts`. Then you create a class named `BunchOfBuchOfParts` which have inside a list of `BunchOfParts` and you realises what the this software is not very scalable.

## Applications

Basically any tree structure can be achieved with this pattern, but specially when you want to permform a common action across all of the leafs.

## Solution

Start defining a `Component` interface which will be your base interface for the other clases. It needs to have the common operations and fields what you need to do across all the objects.

Next you need a `Leaf` class which implements the `Component`. That class will be the "parts" of the composite GoF definition.

And finally define a `Composite` object which inherits `Component` but it needs to be capable of have a list of `Component` so, it can points to different leafs or more composites. In the GoF definiton this `Composite` class is the whole of the hierarchy.

<img src="https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/resources/images/CompositeUML.jpg?raw=true" style="display:block;margin:auto;" height="250" > <br/>

## Example

Suppose that you are creating some software for human resources are you need to print the performance of employee in the company. This company have a hierarchical tree structure where the `Employees` are in `Departments` which are represented by a `Supervisor` and the root department is the `Administration` which control all the company. Keep in mind that the `Supervisor` is also an `Employee`, so you should also calculate their performance. 

Because that is a tree hierarchy you decides to use a composite pattern. 

For measure the performance of an Employee you have three variables, `Punctuality`, `Assistance`, `QualityOfWork` which are numbers from 0 to 10. You need to show the average of this numbers and their standard deviation. 

Then you need `Component` Interface :
```C#
interface IEmployee
{
    string Name { get; set; }
    double Punctuality { get; set; }
    double Asistance { get; set; }
    double QualityOfWork { get; set; }
    void PrintPerformance();
}
```

And next you need a `Leaf` class:

```C#
class Employee : IEmployee
{
    public string Name { get; set; }
    public double Punctuality { get; set; }
    public double Asistance { get; set; }
    public double QualityOfWork { get; set; }
    public void PrintPerformance()
    {
        var (mean, std) = Statistics.MeandAndStd(new double[]{Punctuality, Asistance,QualityOfWork});
        Console.WriteLine($"The employee {Name} has an average performance of {mean.ToString("0.00")} with an {std.ToString("0.00")} deviation");
    }
}
```

And the `Composite` class which needs a list of `IEmployee` which can contain both `Supervisor` and `Employee`

```C#
class Supervisor : IEmployee
{
    public string Name { get; set; }
    public double Punctuality { get; set; }
    public double Asistance { get; set; }
    public double QualityOfWork { get; set; }
    public string Department { get; set; }
    public List<IEmployee> Employees { get; set; } = new List<IEmployee>();
    public void PrintPerformance()
    {
        var (mean,std) =Statistics.MeandAndStd(new double[]{Punctuality,Asistance,QualityOfWork});
        Console.WriteLine("------Department "+Department);
        Console.WriteLine($"The Supervisor {Name} has an average performance of {mean.ToString("0.00")} with an {std.ToString("0.00")} deviation");
        foreach(var Employee in Employees)
        {
            Employee.PrintPerformance();
        }
    }
```

Then in your client you can create a bunch of hardcoded employees and supervisors for test the pattern.

```C#
static void Main(string[] args)
{
    var IT1 = new Employee(){Name="JohnDoe",Punctuality=10d,Asistance=10d,QualityOfWork=10d};
    var IT2 = new Employee(){Name="Foobar",Punctuality=9d,Asistance=10d,QualityOfWork=10d};
    var IT3 = new Employee(){Name="Max Power",Punctuality=10d,Asistance=10d,QualityOfWork=0d};
    var Adm1 = new Employee(){Name="John Carter",Punctuality=2d,Asistance=10d,QualityOfWork=5d};
    var Adm2 = new Employee(){Name="Batman",Punctuality=7d,Asistance=10d,QualityOfWork=6d};
    var SupAdm = new Supervisor(){Name="Mecha-Trump",Punctuality=7d,Asistance=10d,QualityOfWork=6d, Department ="Administration"};
    var SupIT = new Supervisor(){Name="Angry Giraffe",Punctuality=7d,Asistance=10d,QualityOfWork=6d, Department ="IT"};
    SupIT.Employees.Add(IT1);
    SupIT.Employees.Add(IT2);
    SupIT.Employees.Add(IT3);
    SupAdm.Employees.Add(Adm1);
    SupAdm.Employees.Add(Adm2);
    SupAdm.Employees.Add(SupIT);
    SupAdm.PrintPerformance();
}
```

And the output is:

```bash
------Department Administration
The Supervisor Mecha-Trump has an average performance of 7.67 with an 1.70 deviation
The employee John Carter has an average performance of 5.67 with an 3.30 deviation
The employee Batman has an average performance of 7.67 with an 1.70 deviation
------Department IT
The Supervisor Angry Giraffe has an average performance of 7.67 with an 1.70 deviation
The employee JohnDoe has an average performance of 10.00 with an 0.00 deviation
The employee Foobar has an average performance of 9.67 with an 0.47 deviation
The employee Max Power has an average performance of 6.67 with an 4.71 deviation
```

Extra : If you want to know how implemented tuples for std and mean:

```C#
static class Statistics
{
    public static (double, double) MeandAndStd(IEnumerable<double> values)
    {
        double mean = values.Average();
        double sum = values.Sum( val => (val - mean)*(val - mean));
        double std = Math.Sqrt(sum/values.Count());
        return (mean,std);
    }
}
```