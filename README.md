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

## Inheritance

- In c# it is possible to inherit fields and methods from one class to another class.
  1.  Derived class (child) : The class that inherits from another class.
  2.  Base Class (Parent) : The class which is inherited by a child/derived class.
- To inherit from a class we use ':'.
- Example : The Car class will inherit the fields and methods from parent class Vehicle.

```csharp
class Vehicle{
   public string brand = "Ford";
   public void honk(){
      Console.WriteLine("The vehicle honk")
   }
}

class Car:Vehicle{
   public string modelName="Mustang";
}

class Program{
   static void Main(string[] args){
      Car myCar = new Car();
      myCar.honk();
      Console.WriteLine(myCar.brand+" "+ myCar.modelName);
   }
}
```

**Sealed keyword**
If you don't want other classes to inherit the class you can use sealed keyword.

---

## Polymorphism

- Inheritance lets us to inherit the methods and fields from base class. Polymorphism uses those.
- Example

```csharp
class Animal{
   public void makeAnimalSound(){
      Console.WriteLine("Animal made sound");
   }
}

class Pig:Animal{
   public void makeAnimalSound(){
      Console.WriteLine("Pig makes sound: wee wee");
   }
}

class Dog:Animal{
   public void makeAnimalSound(){
      Console.WriteLine("Dog makes sound: bark bark");
   }
}

class Program {
   static void Main(string[] args){
      Pig myPig = new Pig();
      Dog myDog = new Dog();
      myPig.makeAnimalSound();
      myDog.makeAnimalSound();
   }
}
// Output will be
// Animal made sound
// Animal made sound
```

- The above behaviour due to the method in base class overrides the method in derived class.
- To overcome this in c# we need to use virtual keyword in base class method and override keyword in derived class method.

```csharp
class Animal{
   public virtual void makeAnimalSound(){
      Console.WriteLine("Animal made sound");
   }
}

class Pig:Animal {
   public override void makeAnimalSound(){
      Console.WriteLine("The pig make sound: wee wee");
   }
}

class Dog:Animal {
   public override void makeAnimalSound(){
      Console.WriteLine("The dog make sound: bark bark");
   }
}

class Program{
   static void Main(string[] args){
      Pig myPig = new Pig();
      Dog myDog = new Dog();
      myPig.makeAnimalSound();
      myDog.makeAnimalSound();
   }
}
// Output will be
// The pig make sound: wee wee
// The dog make sound: bark bark
```

---

## Abstraction

### Abstract classes and method

- abstract class: A restricted class that cannot be used to create an object. To access this it must be inherited from another class.
- abstract method: This can only be used in abstract classes and these doesn't have body. The body is provided by the derived class.

```csharp
abstract class Animal{
   public abstract void makeAnimalSound();
   public void sleep(){
      Console.WriteLine("zzz")
   }
}
// If we try to create an object like Animal myAnimal = new Animal(); it will give an error.
```

```csharp
abstract class Animal{
   public abstract void makeAnimalSound();
   public void sleep(){
      Console.WriteLine("zzz");
   }
}

class Pig:Animal {
   public override void makeAnimalSound(){
      Console.WriteLine("Pig makes sound: wee wee");
   }
}

class Program{
   static void Main(string[] args){
      Pig myPig = new Pig();
      myPig.makeAnimalSound();
      myPig.sleep();
   }
}
```

## Interface

- An interface is a completely abstract class, which can only contain abstract methods and properties(with empty bodies)

```csharp
interface Animal{
   void makeSound();
   void run();
}
```

- Best practice is to name interface starting with I.

```csharp
interface IAnimal{
   void makeSound();
}

class Dog:IAnimal{
   public void makeSound(){
      Console.WriteLine("Dog barks");
   }
}

class Program {
   static void Main(string[] args){
      Dog myObj = new Dog();
      myObj.makeSound();
   }
}
```

### Multiple interface

```csharp
interface IFirstInterface {
   void firstDemo();
}

interface ISecondInterface {
   void secondDemo();
}

class Demo:IFirstInterface, ISecondInterface {
   public void firstDemo(){
      Console.WriteLine("Hello world!");
   }
   public void secondDemo(){
      Console.WriteLine("Hello Hello World!");
   }
}

class Program {
   static void Main(string[] args){
      Demo demoObj = new Demo();
      demoObj.firstDemo();
      demoObj.secondDemo();
   }
}
```

---

## C# Enums

- An enum is a special class that represents a group of constants.
- To create an enum use the keyword 'enum'.
  Example:

```csharp
class Program{
   enum Level{
      Low,
      Medium,
      High
   }
   static void Main(string[] args){
      Level myVar = Level.Medium;
      Console.WriteLine(myVar);
   }
}
```

### Enum values

- By default the enum first item will have value 0, next item will have value 1 and so on.
- If we assign a value to any item the upcoming values will be updated accordingly.
- To get the integer value from an item, you must explicitly convert the item to an int.
  Example

```csharp
class Program{
   enum Months{
      January, // 0
      February, // 1
      March, // 2
      April, // 3
      May=6, // 6
      June, // 7
      July, //8
   }
   static void Main(string[] args){
      Level month = (int) Level.March;
      Console.WriteLine(month);
   }
}
// Output => 2
```

- enum in a switch statement

```csharp
class Program{
   enum Level{
      Low,
      Medium,
      High
   }

   static void Main(string[] args){
      Level myVar = Level.Medium;
      switch(myVar){
        case Level.Low:
            Console.WriteLine("The level is Low");
            break;
         case Level.Medium:
            Console.WriteLine("The level is medium");
            break;
         case Level.High:
            Console.WriteLine("The level is high");
            break;
      }
   }
}
// Output => The level is medium
```

---

## Working with Files

- The Files class from System.IO namespace allows us to work with files.
- File Methods in C#
  | Method | Description |
  |--------|-------------|
  |AppendText()|Appends Text at the end of the file |
  | Copy() | Copies a file |
  | Create() | Creates or overwrites a file|
  | Delete() | Deletes a file |
  | Exists() | Tests whether a file exists or not |
  | ReadAllText() | Reads the content of a file |
  | Replace() | Replaces the content of one file by content of another file|
  | WriteAllText() | Creates a new file and writes the content into it if the file already exists then overwrites them |

Example: Reading and writing a file.

```csharp
using System.IO;
string text = "Hello World!!!!";
File.WriteAllText("fileName.txt", text);
string myText = File.ReadAllText("fileName.txt");
Console.WriteLine(myText);
// Output=> Hello World!!!!
```

---

## C# Exceptions

- C# try and catch
- The try statement allows you to define a block of code to be tested for errors while it is being executed.
- The catch statement allows you to define a block of code to be executed, if an error occurs in the try block.

```csharp
try{

}catch(Exception e){

}
```

Example

```csharp
try{
   int[] myNums = {1,2,3};
   Console.WriteLine(myNums[10]);
}catch(Exception e){
   Console.WriteLine(e.message);
}
```

- The finally statement lets you execute code, after try...catch, regardless of the result.
  Example:

```csharp
try{
   int[] myNums = {1,2,3};
   Console.WriteLine(myNums[10]);
}catch(Exception e){
   Console.WriteLine(e.message);
}finally{
   Console.WriteLine("The try catch block has been executed successfully!")
}
```

- The throw statement allows you to create a custom error.

```csharp
static void checkAge(int age)
{
  if (age < 18)
  {
    throw new ArithmeticException("Access denied - You must be at least 18 years old.");
  }
  else
  {
    Console.WriteLine("Access granted - You are old enough!");
  }
}

static void Main(string[] args)
{
  checkAge(15);
}
```
