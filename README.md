# C# and .Net framework Learning

## c#, IL code and CLR

The c# language will be converted into IL code and intermediate language first.
The IL code then will be converted into native code using CLR(Common Language Runtime).
The process of converting IL code into native code is called as JIT(Just-in-time).

---

## Architecture of .Net framework

It consist of building blocks called as classes.
**Class** is a container which has some data(attributes) and also consists some functions(methods).
Example: Car is a class. Make, model and price can be the attributes. start() and move() can be the functions of the car.
**Namespace** is a container for related classes.
An **Assembly** is a container for related namespaces.

---

## Data types in c#

1. Value Types - These data types' variables directly contain values.
   Bool, byte, char, decimal, double, Enum, float, int, long, short and struct.
2. Reference Types - A reference types contains a pointer to another memory location where the data is stored.
   String, arrays, classes and delegate.
3. Pointer Types - It is intended to store the address of another pointer.
   Example: int \*p;

Declaring variables
syntax:
type variable_name = value

---

## Operators

Operators are used to manipulate variables and values.

1. Arithmetic Operators.
2. Assignment Operators.
3. Comparisons Operators.
4. Logical Operators.

---

## Comments

1. Single line comment - //
   eg: // This is a comment
2. Multi line comment - /\* \*/
   eg: /\* Hello good morning
   this is a comment \*/

---

## Conditional statements

1. if statement
2. if-else statement
3. if-else-if ladder
4. nested if
5. switch

---

## Loops in C#

1. for loop
2. while loop
3. do while loop

---

## Arrays in C#

A fixed size sequential collection of elements of the same type is stored in an array.
syntax: datatype[]= arrayname;
Declaring Array
int[] numbers = new numbers[20];

---

## Strings in C#

A string is a string object with the value text.
syntax:
char[] nameofstring = {'a','b','c'};
string greeting = "Hello";
Function
| Function | Description |
|----------|-------------|
|Clone() | Returns the reference of string |
|Compare() | Compare two specific strings |
|Concat() | Joins two strings and store the result in first string |
|Contains()| Return the value of specified string |
|CopyTo() | Copies character from the specified position |
|Equals() | Determines the two string objects have the same value |
|Trim() | Trims the string |

---

## Example Program

<pre> ```using System;
namespace HelloWorld
{
    class Program{
        static void Main(string[] args){
            Console.WriteLine("Hello World!");
        }
    }
}</pre>

Line 1: using System means that we can use classes from the System namespace.
Line 2: namespace is used to organize the code and it is a container for classes and other namespace.
Line 3: The curly braces {} marks the beginning and the end of a block of code.
Line 4: class is a container for data and methods, which brings functionality to your program.
Line 5: Main method. Any code inside its curly braces {} will be executed.
Line 6: Console is a class of the System namespace, which has a WriteLine() method that is used to output/print text.
