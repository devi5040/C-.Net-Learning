# C# and .Net framework Learning

## c#, IL code and CLR
The c# language will be converted into IL code and intermediate language first.
The IL code then will be converted into native code using CLR(Common Language Runtime).
The process of converting IL code into native code is called as JIT(Just-in-time).

## Architecture of .Net framework
It consist of building blocks called as classes.
**Class** is a container which has some data(attributes) and also consists some functions(methods).
Example: Car is a class. Make, model and price can be the attributes. start() and move() can be the functions of the car.
**Namespace** is a container for related classes.
An **Assembly** is a container for related namespaces.

## Data types in c#
1. Value Types - These data types' variables directly contain values.
Bool, byte, char, decimal, double, Enum, float, int, long, short and struct.
2. Reference Types - A reference types contains a pointer to another memory location where the data is stored.
String, arrays, classes and delegate.
3. Pointer Types - It is intended to store the address of another pointer.
Example: int *p;

Declaring variables
syntax:
type variable_name = value

## Operators
Operators are used to manipulate variables and values.
1. Arithmetic Operators.
2. Assignment Operators.
3. Comparisons Operators.
4. Logical Operators.
