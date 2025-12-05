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

---

## C# Math

1. Math.Max(x,y)
   This method can be used to find the highest value of x and y.
2. Math.Min(x,y)
   This method can be used to find the lowest value between x and y.
3. Math.sqrt(x)
   This method returns the square root of x.
4. Math.Abs(x)
   This method returns the absolute value of x.
5. Math.Round()
   This method rounds a number to nearest whole number.
   Example:

```csharp
Math.Max(4,7);
Math.Min(3,9);
Math.sqrt(64);
Math.Abs(-9.8);
Math.Round(9.98);
```

---

## C# Strings

A string variable contains a collection of characters surrounded by double quotes.
Example:

```csharp
string greeting = "Hello good morning";
```

string length
The length of a string can be found with the Length property.

```csharp
string text = "hello hi greeting";
Console.WriteLine("The length of the string is: "+ text.Length);
```

ToUpper() and ToLower()
These returns a copy of the string converted to uppercase or lowercase.

```csharp
string text="Hello World";
Console.WriteLine(text.ToUpper());
Console.WriteLine(text.ToLower());
```

### String concatenation

The + operator can be used between strings to combine them which is called concatenation.

```csharp
string firstName = "Doe ";
string lastName = "Smith";
string name = firstName + lastName;
Console.WriteLine(name);
```

There is also string.Concat() method to concatenate two strings.

### String interpolation

it substitutes values of variables into placeholders in a string.
Example:

```csharp
string firstName = "Doe ";
string lastName = "Smith";
string name = $"My full name is: {firstName} {lastName}";
Console.WriteLine(name);

```

---

# OOPS

DRY Principle: The Don't Repeat Yourself(DRY) principle is about reducing the repetition of code. You should extract the common codes from the program and reuse it instead of repeating it.

### Class

- The class is a template for an object.
- When a variable is declared inside the class it is referred as field or attribute.
- When a function is declared inside the class it is referred as method.
  Example:

```csharp
class Car{
   string color = "red";
}
```

### Object

- An object is an instance of the class.
- Creating an object

```csharp
class Car{
   string color = "red";
   static void Main(string[] args){
      Car myObj = new Car();
      Console.WriteLine(myObj.color)
   }
}
```

- Multiple Objects

```csharp
class Car {
   string color = "red";
   static void Main(string[] args){
      Car myObj1 = new Car();
      Car myObj2 = new Car();
      Console.WriteLine(myObj1.color, myObj2.color)
   }
}
```

### Using multiple classes

- Accessing an object created in one class from another class.

```csharp
// Prg2.cs
class Car{
   public string color = "blue";
}
```

```csharp
// Prg3.cs
class Program{
   static void Main(string[] args){
      Car myObj = new Car();
      Console.WriteLine(myObj.color)
   }
}
```

### Class Members

- A class will have fields/attributes ad methods.

```csharp
class Car {
   string color = "red";
   public void fullThrottle(){
      Console.WriteLine("Vehicle going in full throttle!")
   }
}
```

- Using in multiple classes

```csharp
// prg.cs
class Car {
   public string model;
   public int maxSpeed;
}
```

```csharp
//prg1.cs
class Program{
   static void Main(string[] args){
      Car ford = new Car();
      ford.model = "a1";
      ford.maxSpeed = 123;
      Car maruti = new Car();
      maruti.model = "800";
      maruti.maxSpeed = 140;

      Console.WriteLine(maruti.model);
      Console.WriteLine(maruti.maxSpeed);
   }
}
```

### C# Constructors

- Constructor is a special method that is used to initialize objects.

```csharp
class Car {
   string color;
   public Car(string carColor){
      color = carColor;
   }
   static void Main(string[] args){
      Car ford = new Car("red");
      Console.WriteLine(ford.color);
   }
}
```

---

## Access Modifiers

- public : The code is accessible for all classes.
- private : The code is accessible only within the class.
- protected : The code is accessible within the same class or a class that has been inherited from that class.
- internal : The code is only accessible within it's own assembly, but not from another assembly.

---

## Encapsulation and get/set properties

- Encapsulation : It is to make sure that the sensitive data is hidden from the users.
- To achieve this,
  1. Declare the attributes as private.
  2. Provide public get and set methods through properties to get and set the value of the private attributes.
- A property is like a combination of variable and methods. It has 2 methods get and set.
  Example:

```csharp
class Person{
   private string name;
   public string Name{
      get {return name};
      set {name=value}
   }
}

class Program {
   static void Main(string[] args){
      Person myObj = new Person();
      myObj.Name = "devi";
      Console.WriteLine(myObj.Name);
   }
}
```

**Automatic Properties**

- We do not have to define the field for property, we only have to write the get and set.

```csharp
class Person{
   public string Name{
      get;set;
   }
}

class Program{
   static void Main(string[] args){
      Person myObj = new Person();
      myObj.Name = "devi";
      Console.WriteLine(myObj.Name);
   }
}
// Note that it will work same as the above example
```

---
