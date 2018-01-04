# Single Responsability Principle

> A class should have only one reason to change.

## ¿Why this is important? 

Because every responsability is a reason for a future change, and in the real world the requeriments could change. 

For example you have a class called **User** which have: 

Public Properties: 
 - Name
 - Age

Methods:
 - Constructor
 - ToString()
 - ValidateName()
 - ValidateAge()
 - SaveIntoAFile()
 - LoadFile()

And the User Class only have Two Properties Name, Age and one Method ToString(). 

This not only violates SRP, but one thing at time. 

> ¿How we can know if the class **User** violates SRP? 

This things may happen if we don't define one single responsability for a class. So, The first thing we need to do is define ¿What will be the responsability of User Class? In this case, we want to make a class which function is store valid information about an a user. 

So the methods to save, load, and the validations are excluded from the responsability of the **User** class. We need to refactor it into more clases to achieve the SRP.

So we need to make 3 clases in total

User, Validations, ModelPersistance. 

With that 3 classes we can achieve the SRP, please see the examples. 

[Next Article](https://github.com/fernandosoto138/Design-Patterns-Journal/blob/master/1.2%20SOLID%20OCP/Open%20Closed%20Principle.md)

