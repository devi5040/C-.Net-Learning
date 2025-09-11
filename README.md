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

```csharp
using System;
namespace HelloWorld
{
    class Program{
        static void Main(string[] args){
            Console.WriteLine("Hello World!");
        }
    }
}
```

- **Line 1:** using System means that we can use classes from the System namespace.
- **Line 2:** namespace is used to organize the code and it is a container for classes and other namespace.
- **Line 3:** The curly braces {} marks the beginning and the end of a block of code.
- **Line 4:** class is a container for data and methods, which brings functionality to your program.
- **Line 5:** Main method. Any code inside its curly braces {} will be executed.
- **Line 6:** Console is a class of the System namespace, which has a WriteLine() method that is used to output/print text.

---

### Outputting Values

To output values in c# we use WriteLine() method.
Example:

```csharp
Console.WriteLine("Hello World!");
```

We also have Write() method. WriteLine() will insert a new line at the end of output but Write() will not insert new line.

```csharp
Console.Write("Hello");
```

---

## Constant values

The values declared as constant cannot be changed after initializing.

```csharp
const int myNum=15;
myNum=50; // This will throw an error
```

---

# Displaying variables

Variables are often displayed using WriteLine() method.

1. Variables + text

```csharp
string name="John";
Console.WriteLine("Hello "+name);
```

2. Variables + Variables

```csharp
string firstName = "John";
string lastName = "Doe";
Console.WriteLine(firstName + lastName)
```

3. Numbers (+ will be an arithmetic operator here)

```csharp
int num1 = 11;
int num2 = 12;
Console.WriteLine(num1+num2)
```

---

# Assigning multiple variables at a time

```csharp
int x,y,z;
x = y= z = 50;
Console.WriteLine(x+y+z);
```

---

# identifiers

All c# variables should be identified with unique names. These unique names are called as identifiers.

---

# Data Types

1. Integer types
   The int data type can store whole numbers from -2147483648 to 2147483647.
   Example:

   ```csharp
   int myNum=10000;
   Console.WriteLine(myNum);
   ```

2. Long type
   The long data type can store whole numbers from -9223372036854775808 to 9223372036854775807.
   It is used to store values which is more than int range.
   Example:
   ```csharp
   long myNum = 150000L;
   Console.WriteLine(myNum);
   ```
3. Float type
   The float and double data types can store fractional numbers.
   Example:
   ```csharp
   float num = 5.75F;
   double num2 = 19.99D;
   Console.WriteLine(num, num2);
   ```
   Scientific Numbers
   ```csharp
   float f1 = 35e3f;
   double d1 = 12e4d;
   Console.WriteLine(f1,d1)
   ```
4. Boolean Data Types
   The boolean type is declared with keyword 'bool'.
   It can only have 2 values, true or false.
   example:
   ```csharp
   bool b1 = true;
   Console.WriteLine(b1)
   ```
5. Character Data Type
   The character type is declared with keyword 'char'.
   It should be enclosed within ' '.
   Example:
   ```csharp
   char c1 = 'A';
   Console.WriteLine(c1);
   ```
6. Strings
   The strings is used to store the sequence of characters.
   It should be enclosed within " ".
   Example:
   ```csharp
   string greeting = "Hello World";
   Console.WriteLine(greeting);
   ```

---

## C# Type Casting

1. Implicit type casting
   In this type casting the smaller type will be converted to larger type automatically.
   char -> int -> long -> float -> double
   Example:
   ```csharp
   int myInt = 9;
   double myDouble = myInt;
   Console.WriteLine(myInt)
   Console.WriteLine(myDouble)
   ```
2. Explicit type casting
   In this type casting the larger type will be converted to smaller type manually.
   double -> float -> long -> int -> char
   Example:
   ```csharp
   double myDouble = 9.87;
   int myInt = (int) myDouble;
   Console.WriteLine(myDouble);
   Console.WriteLine(myInt)
   ```

### Methods in converting

There are some methods in c# for type casting

- Convert.ToBoolean
- Convert.ToString
- Convert.ToDouble
- Convert.ToInt32(int)
- Convert.ToInt64 (long)
  Example

```csharp
int myInt = 10;
double myDouble = 5.25;
bool myBool = true;
Console.WriteLine(Convert.ToString(myInt))
Console.WriteLine(Convert.ToDouble(myInt))
Console.WriteLine(Convert.ToInt32(myDouble))
Console.WriteLine(Convert.ToString(myBool))
```

## User input

We use Console.WriteLine() to read the input from the user.
Example:

```csharp
Console.WriteLine("Enter your name?");
string username = Console.ReadLine();
Console.WriteLine("Username is:"+username);
```

Taking a number input

```csharp
Console.WriteLine("Enter your age");
int age = Convert.toInt32(Console.ReadLine());
Console.WriteLine("User's age is:"+age)
```

## Operators

Operators are used to perform operations on the variables or values.

### Arithmetic Operators

| Operator | Name           | Description                           |
| -------- | -------------- | ------------------------------------- |
| +        | Addition       | Adds two values                       |
| -        | Subtraction    | Subtracts one value from another      |
| \*       | Multiplication | Multiplies two values                 |
| /        | Division       | Divides one value by another          |
| %        | Modulus        | Returns the division remainder        |
| ++       | Increment      | Increase the value of a variable by 1 |
| --       | Decrement      | Decrease the value of a variable by 1 |

### Assignment Operators

| Operator | Example | Same As |
| -------- | ------- | ------- |
| =        | x=5     | x=5     |
| +=       | x+=5    | x=x+5   |
| -=       | x-=5    | x=x-5   |
| \*=      | x\*=5   | x=x\*5  |
| /=       | x/=5    | x=x/5   |
| %=       | x%=5    | x=x%5   |
| &=       | x&=3    | x= x&3  |
| \|=      | x\|=3   | x=x\|3  |
| ^=       | x^=3    | x=x^3   |
| >>=      | x>>=4   | x=x>>4  |
| <<=      | x<<=4   | x=x<<4  |

### Comparison Operators

| Operator | Name                     |
| -------- | ------------------------ |
| ==       | Equal to                 |
| !=       | Not equal                |
| >        | Greater than             |
| <        | Less than                |
| >=       | Greater than or equal to |
| <=       | Less than or equal to    |

### Logical Operators

| Operator | Name        | Description                                  |
| -------- | ----------- | -------------------------------------------- |
| &&       | Logical and | Returns true if both statements are true     |
| \|\|     | Logical or  | Returns true if one of the statement is true |
| !        | Logical not | Reverse the result                           |
