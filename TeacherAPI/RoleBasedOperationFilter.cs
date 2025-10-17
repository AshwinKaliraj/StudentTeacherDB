using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

public class RoleBasedOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var authorizeAttributes = context.MethodInfo
            .GetCustomAttributes(true)
            .OfType<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            var roles = authorizeAttributes
                .Where(a => !string.IsNullOrEmpty(a.Roles))
                .SelectMany(a => a.Roles.Split(','))
                .Distinct();

            if (roles.Any())
            {
                operation.Description += $"<br><b>Roles Allowed:</b> {string.Join(", ", roles)}";
            }
        }
    }
}