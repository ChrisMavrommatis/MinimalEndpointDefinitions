# MinimalEndpointDefinitions

`ChrisMavrommatis.MinimalEndpointDefinitions` is a .NET Package aimed to provide the Endpoint pattern in your projects by using Definitions and Minimal Endpoints behind the scenes.

The project aims to provide with utilities that will make your API structure look like this
```yml
Endpoints
 - Users
    - Get.cs
    - List.cs
    - Create.cs
    - Delete.cs
  - UsersGroup.cs
  - Products
    - Get.cs
    - List.cs
    - Create.cs
    - Delete.cs
  - ProductsGroup.cs
```

## Installation

Install the package via NuGet Package Manager
```bash
Install-Package ChrisMavrommatis.MinimalEndpointDefinitions
```

Or via .NET CLI:
```bash
dotnet add package ChrisMavrommatis.MinimalEndpointDefinitions
```

## Usage
The library provides a `IEndpointDefinition` interface that you can use to define an endpoint.
You can then use the `DefineEndpoint` method to register the endpoint.


```csharp
namespace MyProject.Endpoints.Users;

public class List : IEndpointDefinition
{
  
  public void DefineEndpoint(IEndpointRouteBuilder endpoints)
  {
    endpoints.MapGet("/api/users", HandleAsync);
  }

  internal async Task<IResult> HandleAsync(CancellationToken cancellationToken = default)
  {
    // Your logic here
  }
}
```

It also provides a `IEndpointGroupDefinition` interface that you can use to define an endpoint group.
Here is an example of how the `UsersGroup` file would look like:

```csharp
namespace MyProject.Endpoints;

internal class UsersGroup : IEndpointGroupDefinition
{
  public RouteGroupBuilder DefineEndpointGroup(IEndpointRouteBuilder endpoints)
  {
    return endpoints.MapGroup("/api/users")
        .WithTags("Users")
        .WithGroupName("Users");
  }
}
```

And this is how `List` would look like if it was part of a group
```csharp
namespace MyProject.Endpoints.Users;
public class List : IEndpointDefinition<UsersGroup>
{
  public void DefineEndpoint(RouteGroupBuilder group)
  {
    endpoints.MapGet("/", HandleAsync);
  }

  internal async Task<IResult> HandleAsync(CancellationToken cancellationToken = default)
  {
    // Your logic here
  }
}
```



## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

