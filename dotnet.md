# ASP.NET Core

- A cross platform high-performance framework to build web apps and apis.
- It is used for REST APIs, Web apps, microservices and SaaS Platforms.

## ASP.NET Core Request Pipeline

- When a request comes in it is processed as:
  Client -> Middleware -> Routing -> Controller -> Response

---

## 1. Middleware

- Software that handles HTTP requests before they reach the controller.
- Log requests, Authenticate users, Handle exceptions, and Modify responses.
- Flow

```sh
Incoming Request
        |
    Middleware 1
        |
    Middleware 2
        |
    Controller
        |
    Middleware 2
        |
    Middleware 1
```

- Built in middleware examples (order matters)
  - UseRouting() - Enables endpoint routing so incoming HTTP requests are matched to the correct route.
  - UseAuthentication() - Identifies and validates the user based on configured authentication schemes.
  - UseAuthorization() - Checks whether the authenticated user has permission to access a resource.
  - UseStaticFiles() - Serves static files like HTML, CSS, JS and images directly from the wwwroot folder.
  - UseExceptionHandler() - Catches unhandled exceptions and redirects to a global error handling pipeline.

---

## 2. Dependency Injection (DI)

- ASP.NET Core has built in DI.
- Dependency Injection - Instead of creating objects manually, the framework injects it automatically.
- Why DI?
  - Loose coupling
  - Easier testing
  - Clean architecture
  - Scalable apps
- Register services

```csharp
builder.Services.AddScoped<IUserService, UserService>();
```

- Types of lifetimes
  1. AddSingleton - One instance for entire app.
  2. AddScoped - One per request.
  3. AddTransient - New every time.

- Injecting in controller

```csharp
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }
}
```

> ASP.NET automatically injects it.

---

## 3. Controllers

- Controllers handle the incoming request.
- They receive request, execute logic, return response.
- Example

```csharp
[ApiController]
[Route('api/[controller]')]
public class UserController:ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers(){
        return Ok(new[] {'Devi','Rai'})
    }
}
```

- Attributes
  | Attribute | Description |
  |-----------|-------------|
  | [ApiController] | Enables API Features |
  | [Route] | Defines URL |
  | [HttpGet] | Get request |
  | [HttpPost] | Post request |
  | [HttpPut] | Put request |
  | [HttpDelete] | Delete request |
  | [FromBody] | Read JSON body |

---

## 4. Routing

- Routing maps URL to controller action

1. Conventional Routing

```csharp
app.MapControllerRoute(
name:'default',
pattern:"{controler=Home}/{action=Index}/{id?}"
);
```

2. Attribute Routing

```csharp
[Route('api/users')]
public class UserController:ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetUser(int id){
        return Ok($"User {id}")
    }
}
```

---

## Production Architecture

```scss
Controller
    |
Services(Business Logic)
    |
Repository (Database)
    |
DbContext
```

---

## Web APIs

- A web API is an HTTP service that exposes endpoints returning data.

#### Web API Example:

```csharp
[ApiController]
[Route('api/[controller]')]
public class UserController:ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers(){
        var users = new List<String>{'Devi','Rai'}
        return Ok(users);
    }
}
```

- Response

```json
["Devi", "Rai"]
```

---

### Swagger/OpenAPI

- It automatically generates API documentation
- Why Swagger?
  - Interactive testing UI
  - Auto Documentation
  - Client SDK generation
  - Shows request/response models

**Enabling Swagger in ASP.NET Core**

- In Program.cs

```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

app.UseSwagger();
app.UseSwaggerUI();
```

- Then visit - [Swagger API Docs]('http://localhost:5001/swagger')

---

### JSON Handling in ASP.NET Core

- ASP.NET Core uses System.Text.Json by default.
- **Serialization**

```csharp
    // Automatic conversion happens
  return Ok(user);
```

- **Custom Json Settings**

```csharp
builder.Services.AddControllers().
    AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
```

- **Ignore Properties**

```csharp
[JSONIgnore]
public string Password{get;set   }
```

---

### Validation and DTO's

- DTO - Data Transfer Object
- Used to
  - Control what data enters API.
  - Prevent exposing database models
  - Improves security
  - Control validation

```csharp
public class CreateUserDTO
{
    [Required]
    public string Name {get; set;}

    [EmailAddress]
    public string Email {get;set;}
}
```

**Built in Validation attributes**
|-----------|---------|
| Attribute | Purpose |
|-----------|---------|
| [Required] | Field must exist |
| [StringLength] | Max length |
| [EmailAddress] | Valid Email |
| [Range] | Numeric Range |
| [MinLength] | Minimum Length |

**Controller with Validation**

```csharp
[HttpPost]
public IActionResult CreateUser([FromBody] CreateUserDTO dto)
{
    if(!ModelState.IsValid)
        return BadRequest(ModelState);
    return Ok('User Created')
}
```

> Auto Validation
>
> We can use [ApiController] for auto validation

- It will do the following
  - Validates DTO
  - Returns 400 if invalid
  - We don't need ModelState check

**Production Flow**

```pgsql
Client
↓
Controller
↓
DTO Validation
↓
Service
↓
Repository
↓
Database
↓
Return DTO (safe version)
```

---

### SQL server vs PostgreSQL

#### 1. SQL Server

- Tight integration with .NET
- Strong tooling (SSMS)
- Enterprise friendly
- Great for Windows environment

#### 2. PostgreSQL

- Open source
- Highly extensible
- Very powerful indexing
- Great JSON support
- Popular in startups and cloud

---

### Entity Framework Core (ORM)

ORM = Object Relational Mapper

- Install EF Core
- For Mysql

```pgsql
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

- For PostgreSQL

```pgsql
dotnet add package Npgsql.EntityFrameworkCore.PostgreSqQL
```

---

#### Creating DbContext

```csharp
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

    public DbSet<User> Users{get;set;}
}
```

- Configure in Program.cs
  - For SQL server

  ```csharp
    builder.Services.AddDbContext<AppDbContext>(options=>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ))
  ```

  - For PostgreSQL

  ```csharp
    builder.Services.AddDbContext<AppDbContext>(options=>
    options.UseNpgsql(
        connectionString
    ))
  ```

---

## Working with EF Core

1. Entity Model

```csharp
public class User
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Email {get; set;}
}
```

2. Migrations

```csharp
// Add Migration
dotnet ef migrations add InitialCreate

// Update db
dotnet ef database update
```

3. Queries with EFCore

- Insert Data

```csharp
var user = new User{
    Name="Devi",
    Email="dpraidola@gmail.com"
};

_context.Users.Add(user);
await _context.SaveChangesAsync();
```

- Get All Users

```csharp
var users = await _context.Users.ToListAsync();
```

- Filter Data (LINQ)

```csharp
var adults = await _context.Users.where(u=>u.Age >= 18).ToListAsync();
```

- Get by ID

```csharp
var user = await _context.Users.FindAsync(id)
```

- Update

```csharp
user.Name = 'updated';
await _context.SaveChangesAsync()
```

- Delete

```csharp
_context.Users.remove(user);
await _context.SaveChangesAsync()
```

4. Advanced Queries

- Include Relationships

```csharp
var orders = await _context.Orders.Include(o=>o.User).ToListAsync();
```

- Raw SQL

```csharp
var users = _context.Users.FromSqlRaw("SELECT * FROM Users WHERE Age > 18").ToList();
```

**Best Practices**

- Always use async methods
- Use DTOs instead of returning entities
- Use Migrations
- Keep connection string in appsettings.json
- Use proper indexing DB
- Use transactions for critical operations
