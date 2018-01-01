# Builder

> Definition :  Separate the construction of a complex object from its representation so that the same construction process can create different representations.

## Problems to Solve

- Constructing objects with different representations : This means what a class can create an object which is configured in a different way but it conserves the same nature.
- Configure or create complex objects in an easy way : Some objects may need a lot of information to be created, and not all representations needs all the data, and if you don't use a pattern you can fall in twenty constructor or an optional parameter hell.

## Solution

The builder pattern propose the following:

- There's three main objects:
  - The object you want to create, called Product.
  - A Builder object what encapsulates the creation and assembly of the complex parts.
  - A Director object what delegates the Builder object creation.

![alt text](https://...."Logo Title Text 1")

Then the real power of this pattern is what you have simplified the creation and assembly of a complex object in a Director class.

## Example

Suppose what you are creating a software for generating SVG images. And you want to implement a builder pattern for achieve that. The output will be :

```xml
<svg height="400" width="400" xmlns="http://www.w3.org/2000/svg">
 <rect x="20" y="20" width="250" height="250" style="fill:blue">
  <animate attributeType="CSS" attributeName="opacity" from="1" to="0" dur="2s" repeatCount="indefinite">
  </animate>
 </rect>
</svg>
```

And when you decided to apply the builder pattern you need to think about : 

- What object I want to create? In this case we want to create an `SVGElement` object that have all the information of the SVG tags.

- How I Will build it? We will create an `SVGBuilder`object for build all the parts of a valid SVG image.

In this case our director class will be the `main` of the program, only for simplcity purposes. Remember what we are programming for interfaces and not for implementations, then we defined the next interfaces :


```C#
interface ISVGElement
{
    string TagName {get;}
    string Properties {get;}
    string Text {get;}
    List<ISVGElement> Elements {get; set;}
    ISVGElement AddProperty(string key, string value);
    ISVGElement AddElement(ISVGElement Element);
    string IndentedToString(int indent);
}
interface ISVGBuilder
{
    ISVGElement root {get ;}
    ISVGBuilder AddElement(ISVGElement elem);
    ISVGElement BuildAll();
    void Clear();
}
//Our Director: 
static void Main(string[] args)
{
    var filename = "Test.svg";
    var svgBuilder = new SVGBuilder(400,400);
    var svgRectangle = new SVGElement("rect");
    svgRectangle.AddProperty("x","20")
                .AddProperty("y","20")
                .AddProperty("width","250")
                .AddProperty("height","250")
                .AddProperty("style","fill:blue");
    var svgAnimation = new SVGElement("animate");
    svgAnimation.AddProperty("attributeType","CSS")
                .AddProperty("attributeName","opacity")
                .AddProperty("from","1")
                .AddProperty("to","0")
                .AddProperty("dur","2s")
                .AddProperty("repeatCount","indefinite");
    svgBuilder.AddElement(svgRectangle.AddElement(svgAnimation));
    var fullSvg = svgBuilder.BuildAll();
    File.WriteAllText(filename,fullSvg.ToString());
}
```

Note that this are `fluent` implementations, you can see it when a method returns the same type of the interface, that's why you will see a `return this;` at the end of the method.

This is a very easy implementation because the builder only builds one thing in the method `buildAll` and it's already constructed when you call that method. But suppose what you are creating a some kind of UI, you will have a lot of more variables and parts to build. For example you can have methods like `buildStatusBar` and `buildFileViewer`.
