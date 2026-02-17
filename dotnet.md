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
