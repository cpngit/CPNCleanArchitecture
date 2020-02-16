using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPN.UI.WebAPI.Configuration
{
    public class AuthorizationConsts
    {
        public const string IdentityServerBaseUrl = "http://localhost:5000";
        public const string OidcSwaggerUIClientId = "CPN_web_api_swaggerui";
        public const string OidcApiName = "CPN_web_api";

        public const string AdministrationPolicy = "RequireAdministratorRole";
        public const string AdministrationRole = "CPNAdministrator";
    }
}
