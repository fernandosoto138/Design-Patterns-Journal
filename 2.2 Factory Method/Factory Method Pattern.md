# Introduction

In software development there's a keyword called `Factory` which is a term used for name objects which have the responsability and information for encapsule the creation of other objects. Although there is a pattern called "Single Factory" or only "Factory" which is a simple class with a bunch of methods for creating correlated objects, the motivation for that is hide or encapsulate the logic in the creation of the object. And the motivation for doing that is quite simple chech this line:

```C#
    var db = new Database(connString);
```

Every time you use the keyword `key` you are violating the DIP, because `Database` is a concrete class and the implications of doing that are obviuos, for example the connection strings may be different for each one. In this case the class Database is very vollatile which means that it's very susceptible to changes. But it's not all the cases, for example in C# the `string` keyword is an alias of `String` class, but it's no succeptible for changes, so you can use it without worry about it.

## Factory Method

> Definition : Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to sub­classes.

The key to understanding this pattern is the following :

> let subclasses decide which class to instantiate.

Pay attention to this fragment, or else you will be confused with a "Single Factory".

## Problems to Solve

- How to provide a flexible alternative of multiple constructors?
- How to encapulate the construction of objects?

## Applications

The Factory method can be used as a bridge between classes. For example you are building an application which works with Sql Server, but the requeriments change and now you need to take some data from an Oracle database. If you used Factory Method you don't need to change a lot of code, only you need to create a class or method what returns the database interace which is your product, but configured for the new environment.

You should use Factory Method when :

- A class can’t anticipate the class of objects it must create.[GoF]
- A class wants its subclasses to specify the objects it creates.[Gof]
  - You need to encapsulate the construction of that objects to simplify the code.

## Solution

This solution is very simple, you need to define a `Factory interface` with methods which has the responsabilities for create a general `Product` . Then every `Factory` has the obligation of create an specific products, but the retun type is in a general form, because the concrete objects may vary.

I see this UML diagram a little bit confusing specially because the key concept is not easy visible. Maybe in a future I will add it.

## Example

Suppose what you are programming a game and you need to generate random NPC(non playable characters). This can be `MonsterNPC` or `FriendNPC`. Their Health Points can be from 1HP to 9999HP, and they need to have a name.

What's the problem here? You need to create objects but you don't know what will be created!. Then you creates a common interface for all of this NPCs:

```C#
abstract class NPC
{
    public double HP{ get; set;}
    public double MaxHP { get; private set;}
    public string Name { get;  private set;}
    public bool isEnemy { get; set;}
    public NPC(string Name, double MaxHP, bool isEnemy)
    {
        this.Name = Name;
        this.MaxHP = MaxHP;
        this.HP = MaxHP;
        this.isEnemy = true;
    }
}
```

And Then you create two `Concrete Products` for this interface:

```C#
class MonsterNPC : NPC
{
    public MonsterNPC(string Name, double MaxHP)
        :base(Name,MaxHP,true)
    {
    }
    public override string ToString() => $"Rraarrw! I'm the temible {Name} and I have {HP}HP!";
}
class FriendNPC : NPC
{
    public FriendNPC(string Name, double MaxHP)
        :base(Name,MaxHP,false)
    {
    }
    public override string ToString() => $"Hello Friend, I'm {base.Name} and I have {base.HP}HP!";
}
```

Once you have the products, let's define the `Factory` and the `ConcreteFactory`

```C#
interface INPCFactory
{
    NPC GenerateRandomNPC();
}
class NPCFactory : INPCFactory
{
    string[] MonsterNames = new string[]{"Ronald McDonald","Destructor","Donald Trump"};
    string[] FriendNames = new string[]{"Legionary", "Harry Potter", "Snowman"};
    static Random rnd = new Random();
    public NPC GenerateRandomNPC()
    {
            var hp = rnd.Next(1,9999);
            var name = rnd.Next();
            if((rnd.Next(0,1000) % 2) == 1)
                return new FriendNPC(FriendNames[name % 3],hp);
            return new MonsterNPC(MonsterNames[name % 3],hp);
    }
}
```

Very simple implementations, and with a very small client code you can generate a bunch of 10 random NPCs:

```C#
var npcGenerator = new NPCFactory();
var buchOfNPCs = Enumerable.Range(1,10)
                        .Select(i => npcGenerator.GenerateRandomNPC())
                        .ToList();
buchOfNPCs.ForEach( npc => Console.WriteLine(npc));
```
