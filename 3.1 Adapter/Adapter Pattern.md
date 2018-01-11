# Adapter

> Definition : Converts the interface of a class into another interface that clients expect.

## Problems to Solve

- Reuse a class or objects what does not have the interface that clients require.
- Make clases or objects work together that have incompatible interfaces.
- Provide alternative interfaces to clases and objects. 

## Solution 

The adapter pattern proposes the following :

- A `Client` what is the class or the object what depends the `Target` interface.
- A `Target` what is the interface what our class or object requires.
- An `Adapter` Implements the interface `Target` and uses the `Adaptee`.
- An `Adaptee` a code what have an incompatible interface for `Target`.

<img src="https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/3.1%20Adapter/Adapter-CS-1/AdapterUML.jpg?raw=true" style="display:block;margin:auto;" height="250" > <br/>

## Example

Suppose what you need to put some data on a database and you have a class called `EmployeeDatabase` that works with Lists of a person object, then your target will be a `List<Person>`, but you are working with a third-party API what gives you a string with JSON formatted data. Therefore you need to build an `Adapter`, and your adaptee will be that third party API.

```C#
interface ITarget
{
    List<Person> GetEmployeeList();
}
class EmployeeAdapter : ThirdPartyAPI, ITarget
{
    public List<Person> GetEmployeeList()
    {
        return JsonConvert.DeserializeObject<List<Person>>(getEmployesJSON());
    }
}
```

In this case we are using a tool called Json .NET to convert the json data in a very simple way. With this, you can use the `EmployeeDatabase` class :

```C#
static void Main(string[] args)
{
    var EmpAdapter = new EmployeeAdapter();
    EmployeeDatabase.UploadPersonnel(EmpAdapter.GetEmployeeList());
}
```

If all is ok you will be this "debug" output:

```SQL
INSERT INTO HR.EMPLOYEES (firstname, lastname) VALUES ('John','Travolta');
INSERT INTO HR.EMPLOYEES (firstname, lastname) VALUES ('Max','Power');
INSERT INTO HR.EMPLOYEES (firstname, lastname) VALUES ('Esteban','Quito');
```
