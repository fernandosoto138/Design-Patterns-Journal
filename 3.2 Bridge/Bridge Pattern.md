# Bridge

> Definition : Decouple an abstraction from its implementation so that the two can vary independently.

## Problems to Solve

- How can an abstraction and a implementation change separately?
- How can I avoid the binding of implementation and abstraction?
- How can an implementation change at runtime?

## Application

The bridge pattern can be very confusing when you know the strategy pattern, because the way to apply both patterns is quite the same. But when you choose one over the another is that makes the difference. That's why bridge is a structural pattern and the stategy is a behavioral pattern.

In the strategy pattern you have an strategy interface, and you have a client which requires it, thus you can have multiple strategies or algorithms for the same task.

But in Bridge pattern, that you are doing is decoupling the implementation of one functionality. Seems to be the same thing in comparison with strategy, but when you choose one of them is the key point. See this examples:

- Strategies:
  - Change the way you log in, like user-password login, or google auth.
  - Change the resource that you are querying. 
- [Bridge](#bridge)
    - [Problems to Solve](#problems-to-solve)
    - [Application](#application)
    - [Solution](#solution)

## Solution

- ConcreteAbstraction : The class which needs an implementation
- Interface implementation : a common interface for all implementations
- ConcreteImplementation : one of the implementations. 

<img src="https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/resources/images/BridgeUML.jpg?raw=true" style="display:block;margin:auto;" height="250" > <br/>

