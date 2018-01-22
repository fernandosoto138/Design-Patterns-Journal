# Template Method

> Definition : Define the skeleton of an algorithm in an operation, deferring some steps to sub­classes. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure. [GoF]

This pattern is very simple to understand, so this explanation will be very short.

## Problems to Solve

- How can the Invariant parts of an algorithm be implemented once, so the subclasses can implement de varian parts?
- How can I create a subclass which define parts of a behavior without changing their structure?

Sometimes we create classes to solve one problem but with multiple variations, like reading an xml or a json file. And what we do is create two classes like `XMLReader` and `JSONReader` and the problem with this is that maybe that classes share a lot of code. Then this pattern will help us to code this things a little better.

## Solution

First identify which parts of the code can vary, then you can create an `AbstractClass` with a bunch of methods. One method, called for example `TemplateMethod()` will have the skeleton of the algorithm, and also the class needs to have at least one method `Primitive1()` which will be coded in every sublcass which implement the abstract class.

<img src="https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/resources/images/TemplateMethodUML.jpg?raw=true" style="display:block;margin:auto;" height="250" > <br/>

## Applications

As you can see this simple pattern basically can be applied in almost any algorithm but there's some key points what you should keep in mind :

- When you are reducing duplicated code : There's is a lot of algorithms which only change some lines of code. For example a sort algorithm can be the same for any type of data, the part which changes is the way do you compare the data.
- When you need to create an OCP class: Template method can be a good way to accomplish that, but always keep in mind that this pattern it's for specific operations.

## Relations with other patterns

Maybe you are thinking what this is simmilar to the Strategy Pattern, but actually are very different. In the first one all of the strategies share a common interface, the code of the concrete strategies code needs to have a common input and ouputs. But in the Template method you are extending an abstract class and writing some parts of the code. Think in the following

- Strategy provides a way to change the algorithm/behavior in run time.
- Template Method provides a way to change the algorithm/behavior in compile time.