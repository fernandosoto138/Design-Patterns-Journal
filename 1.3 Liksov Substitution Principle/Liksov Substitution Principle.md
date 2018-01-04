# Liksov Substitution Principle

> Functions that use pointers or references to base classes must be able to use objects of derived classes without knowing it. 

## ¿Why this is important? 

Because there are two principal ways for violating it : 
1. If a function takes a base class, and the behavior of this function depends of the type of subclass, we are violating the LSP and OCP principle. Because we need to change the function in every subtype created in a future. 
2. In the other hand we can have a function X that takes a class A as argument and works well. In the future, we create a class B that inherits the A class. But the function X can take as argument objects created with the A and B clases, but it was not programmed to use that B class, and if we dont take care of this, the program can have an unwanted behavior or a runtime error.

Example:

Suppose that you are a new programmer and are your first steps in cloud databases. 
So, you have two databases, one in Azure and other in the Amazon Web Services, and you created two objects to handle common behaviour. Then you create an interface callled IDB witch have the common functions with your dbs. So you are an inexperienced programmer and for some reason you are creating a function for connect to an unknown DB, that takes an object that have IDB and user/password strings. And the result is the following : 
```C#
static bool ConnectToDatabase(IDB database, string user, string password)
{
    
    if(database is DbInAzure)
    {
        return database.Connect($"usr={user},pwd={password}");
    }
    else if(database is DbInAWS)
    {
        return database.Connect($"user={user}&pwd={password}");
    }
    return false; 
}
```

So, this is the case *1* what we decribed. 

[Previous Article](https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/1.2%20SOLID%20OCP/Open%20Closed%20Principle.md)
[Next Article](https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/1.4%20Interface%20Segregation%20Principle/Interface%20Segregation%20Principle.md)