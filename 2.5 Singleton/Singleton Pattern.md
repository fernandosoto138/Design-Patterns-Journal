# Singleton

> Definition : Ensure a class only has one instance, and provide a global point of access to it.

## Problems to Solve

- How can I get a class with only one instance? You can create a class with an `static` instance of the same class inside which is created only one time. You can prevent the instantiation of that object by making the constructor private. Although you have little differences between the languages, because you need to ensure what your singleton is unique in all threads, this is called 'thread-safety' singleton. 
- How can this instance be accessed globally? making a member `public` and `static` that gives you the singleton instance. 

## Applications

- [Singleton](#singleton)
    - [Problems to Solve](#problems-to-solve)
    - [Applications](#applications)
    - [Problems with Singleton Pattern](#problems-with-singleton-pattern)
    - [Solution by example](#solution-by-example)

## Problems with Singleton Pattern

Singleton Pattern is practically the most hated pattern in all of the GoF patterns. We will not enter into that discussion in this case, but we will leave some links about the problems of the singleton so that you can draw your own conclusions.

- [Why is so bad about singletons?](https://stackoverflow.com/questions/137975/what-is-so-bad-about-singletons?page=1&tab=votes#tab-top)
- [Singleton I love you, but you're bringing me down](http://geekswithblogs.net/AngelEyes/archive/2013/09/08/singleton-i-love-you-but-youre-bringing-me-down-re-uploaded.aspx)
- [Patterns I Hate #1 : Singleton](http://web.archive.org/web/20120603233658/http://tech.puredanger.com/2007/07/03/pattern-hate-singleton)
- [Root cause of Singletons](http://misko.hevery.com/2008/08/25/root-cause-of-singletons/)

## Solution by example

In this case we will not include an UML diagram because it's very simple, it's just only one class.

Suppose what you are creating a super log with multiple features but for this example we we'll create only one method called `AddLine`.

The code for this case is the following:

```C#
class SuperLogSingleton
{
    private static readonly SuperLogSingleton _instance = new SuperLogSingleton();
    public static SuperLogSingleton Instance{ get => _instance;}
    private string _output = "";
    public string Output{ get => _output;}
    private SuperLogSingleton() => _output += "Starting Super Log...\n";
    public void AddLine(string text) => _output += $"{text}\n";
}
```

Check out what our `_instance` of the singleton is `private static readonly` this makes the instance thread-safe instead of using the `lock` keyword for determine if the instance is in another thread.

Sometimes singleton classes can load a lot of resources and suppose what do yo don't want to load that singleton until you need it. For doing this the .NET frameworks offers a Lazy Load pattern in a `Lazy<T>` class which is very simple to use. See that in this example:

```C#
class LazySuperLogSingleton
{
    private static readonly Lazy<LazySuperLogSingleton> _instance = new Lazy<LazySuperLogSingleton>(()=>new LazySuperLogSingleton());
    public static LazySuperLogSingleton Instance { get => _instance.Value;}
    private string _output = "Lazy Super Log is Sleeping...\n";
    public string Output{ get => _output;}
    private LazySuperLogSingleton() => _output += "Waking up Lazy Super Log...\n";
    public void AddLine(string text) => _output += $"{text}\n";
}
```

As you can see creating a Lazy Singleton in C# is very easy.