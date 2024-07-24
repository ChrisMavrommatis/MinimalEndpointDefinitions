using Microsoft.AspNetCore.Routing;

namespace ChrisMavrommatis.MinimalEndpointDefinitions;

public interface IEndpointDefinition
{
    void DefineEndpoint(IEndpointRouteBuilder endpoints);
}