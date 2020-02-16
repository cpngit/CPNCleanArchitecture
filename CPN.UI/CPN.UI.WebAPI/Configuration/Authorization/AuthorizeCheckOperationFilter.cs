using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;

namespace CPN.UI.WebAPI.Configuration.Authorization
{
    public class AuthorizeCheckOperationFilter : Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter
    {
        private readonly AdminApiConfiguration _adminApiConfiguration;

        public AuthorizeCheckOperationFilter(AdminApiConfiguration adminApiConfiguration)
        {
            _adminApiConfiguration = adminApiConfiguration;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>().Any();

            //TODO update this part of the code to new framework version

            //if (hasAuthorize)
            //{
            //    operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            //    operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

            //    operation.Security = new List<IDictionary<string, IEnumerable<string>>> {
            //        new Dictionary<string, IEnumerable<string>> {{"oauth2", new[] { _adminApiConfiguration.OidcApiName } }}
            //    };
            //}
        }

    }
}
