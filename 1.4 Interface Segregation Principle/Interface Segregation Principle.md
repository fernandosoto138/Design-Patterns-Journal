# Interface Segregation Principle 

> A class should not be forced to depend on methods it does not use. 

## Why this is important?
This is a quite simple principle to understand, you can think what is like a SRP principle but for interfaces. Because if you creates an interface with a lot of responsabilities, not all objects will require to use all the members in that interface. See the next example :

You are working on game which have some characters, one you control and multiple Non-Player characters. So you create the following interface : 

```C#
interface ICharacter 
{
    //This may be not SRP compliant, but think on ISP. 
    void Render();
    void Eat();
    void Walk();
    void Run();
    void Fight();
}
```

But you are developing some kind of RPG game, so you have a lot of types of characters, for example sellers inside the game and you try to do this : 

```C#
class SellerNPC : ICharacter
{
    // This NPC doesn't walk, run, eat nor fight,
    // only stand in one place and sell things
    // So, ICharacter is a fat interface for that 
}
```
For fix that you need to create a bunch of new interfaces for solve this problem. For example 
```C#
interface IEat{ ... }
interface IMove{ ... }
interface IFight { ... }
interface IRenderizable { ... }
interface ISeller { ... }
class MainPlayer : IEat, IMove, IFight, IRenderizable {...}
class SellerNPM : IRenderizable, ISeller { ... }
class Assistant : IMove, IFight, IRenderizable { ... }
```

But you can break the ISP not only with interfaces but also with class inheritance, for example : 

```C#
class Character 
{
    // a lot of properties... methods and constructor... and then : 
    void Move() { }
    void Fight() { }
}
class SellerNPC : Character
{
    SellerNPC(): base(){}
    void SellObjects(); 
}
```
In this case, a seller is a character of our game, but it will not fight nor move, they are very safe in a store of an old village in which there are no monsters. In consequence, the act of inherit Character class in the SellerNPC it's causing an ISP violation due to a fat interface. 

[Previous Article](https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/1.3%20Liksov%20Substitution%20Principle/Liksov%20Substitution%20Principle.md)
[Next Article](https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/1.5%20Dependency%20Inversion%20Principle/Dependecy%20Inversion%20principle.md)