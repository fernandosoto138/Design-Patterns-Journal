# Pattern Name

> Definition : Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.[GoF] 

## Problems to Solve

- How can a one-to-many dependency between objects be defined without making the objects tightly coupled?
- How can an object notify an open-ended-number of other objects?

The key point of this pattern is to stablish a notification-registration mecanism that notifies a list of suscribers objects when other object changes.

There's some problems with this. For example, you can have a class A with a simple list of suscribers, and when this A class updates, it uses that list of objects B and updates each one of them. Seems very cool But the class A needs to know how to update that objects and that implies what the objects are tightly coupled, and therefore, the class A isn't reusable because A only can use B objects.

## Solution

The Observer pattern proposes the following. 

Create an `Subject` interface, which will be the object where the `Observers` will registrate in. Then, create concrete subjects with that interface. 

By the other side, create an `Observer` interface, only with a method which receives a pointer to the `Subject` which is registrated. Then create concrete Observers.

The important thing to achieve loosely coupled classes here is that the `Subject` class does not know how to communicate with their observers. Each one of the observers have the responsability to read the subject state and then do something with that.

The `Subject` has the responsability to call the update method for each registrated observer. This is done in a notify method.

<img src="https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/resources/images/ObserverUML.jpg?raw=true" style="display:block;margin:auto;" height="250" > <br/>

## Applications

An obvious application is the follow/unfollow from the social networks where an user is an observer and a subject at same time. But there's other applications, for example in GUI development. If you are plotting data, and at the same time takingcare of SRP, you can't load the data in the same place where you are plotting it. And the data isn't used in only one place in the application, usually it's used among a lot of components. Then you can't load the data every time a component it's created. Here is useful the observer pattern, because you can have a simple class with the responsability of load the data, and other components will suscribe to that loader and taking only the data that is important for them.

## Example

You are developing some application for the stock market. And your objective is load some stock data from a file, and show a series of indicators or widgets which are using that data. But you need to keep in mind that only for now the data is loaded from a file, in a future, the data will be in real time. So you need to create a program thinking on low coupling, else you will need to change the program a lot in a future.

The task is very simple, you need to create two indicators:
1. Shows the Open, Close, High and low price. 
2. Calculates the Simple Moving Average: This is very simple, it's the calculation of the average, using the last _n_ close prices.

Here is an exaple of the .csv file with the stock prices:

```csv
ticker,date,open,high,low,close,volume,ex-dividend,split_ratio,adj_open,adj_high,adj_low,adj_close,adj_volume
A,2003-07-25,21.65,21.8,21.3,21.73,1446900.0,0.0,1.0,14.770510853745,14.872846956658,14.531726613615,14.825090108632,1446900.0
```

You decide to use a Obsever pattern because when the application will need real time data, the indicators will need to refresh in all new incoming of data, and all of this uses and requests the data in a different way.

Then you creates the `Subject` and the `Observer` in the way of abstract classes:

```C#
abstract class Subject
{
    List<Observer> observers = new List<Observer>();
    public void Attach(Observer obs) => observers.Add(obs);
    public void Deatch(Observer obs) => observers.Remove(obs);
    public void Notify()
    {
        foreach(var observer in observers)
            observer.Update(this);
    }
}
abstract class Observer
{
    public abstract void Update(Subject subject);
}
```

Then there will be a `StockReader` class which inherits `Subject`. That class will read the archive, and update their state and calling the `Observers` to update itselfs.

In this case I created that class for simulate "Real time data", that's why you will se a `Console.Clear();` and a `Thread.Sleep(10);`.

```C#
class StockReader : Subject
{
    public double Close;
    public double Open;
    public double High;
    public double Low;
    public void StartRead(string filename)
    {
        using(var reader = new StreamReader(filename))
        {
            //This is intented for skip the first line.
            string line = reader.ReadLine();
            string[] values;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                values = line.Split(',');
                //The set state:
                Open =double.Parse(values[2]);
                High = double.Parse(values[3]);
                Low = double.Parse(values[4]);
                Close = double.Parse(values[5]);
                Console.Clear();
                Notify();
                Thread.Sleep(10);
            }
        }
    }
}
```

Then you have the subject all ok, now you have to create the Observers. In this case I've named them `DisplayStockPrice` and `MovingAverage`. Keep in mind how works the pattern, don't worry about the logic of the moving averge. Use the first one to understand the logic.

```C#
class DisplayStockPrice : Observer
{
    public override void Update(Subject subject)
    {
        StockReader sr = subject as StockReader;
        Console.WriteLine("Open  Price:" + sr.Open.ToString());
        Console.WriteLine("High  Price:" + sr.High.ToString());
        Console.WriteLine("Low   Price:" + sr.Low.ToString());
        Console.WriteLine("Close Price:" + sr.Close.ToString());
    }
}

class MovingAverage : Observer
{
    public int Periods { get; set; }
    double[] values ;
    int count = 0;
    bool filled = false;
    public MovingAverage(int Periods)
    {
        this.Periods = Periods;
        values = new double[Periods];
    }
    public override void Update(Subject subject)
    {
        StockReader sr = subject as StockReader;
        if(count == Periods)
            count = 0;
        if(filled)
        {
            values[count] = sr.Close;
            Console.WriteLine($"Moving Average({Periods}) :{values.Average()}");
        }
        else
        {
            if(count == Periods - 1)
                filled = true;
            values[count] = sr.Close;
        }
        count++;
    }
}
```