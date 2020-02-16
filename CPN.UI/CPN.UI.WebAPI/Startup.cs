using System.Collections.Generic;
using AutoMapper;
using CPN.UI.WebAPI.Configuration;
using CPN.UI.WebAPI.Configuration.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CPN.UI.WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var adminApiConfiguration = Configuration.GetSection(nameof(AdminApiConfiguration)).Get<AdminApiConfiguration>();
            services.AddSingleton(adminApiConfiguration);
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(ApiConfigurationConsts.ApiVersionV1, new Info { Title = ApiConfigurationConsts.ApiName, Version = ApiConfigurationConsts.ApiVersionV1 });

                options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Flow = "implicit",
                    AuthorizationUrl = $"{adminApiConfiguration.IdentityServerBaseUrl}/connect/authorize",
                    Scopes = new Dictionary<string, string> {
                        { adminApiConfiguration.OidcApiName, ApiConfigurationConsts.ApiName }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
                                  
            services.AddMvcCore().AddAuthorization().AddJsonFormatters();

            services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.ApiName = "api1";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationConsts.AdministrationPolicy,
                    policy => policy.RequireRole(AuthorizationConsts.AdministrationRole));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AdminApiConfiguration adminApiConfiguration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiConfigurationConsts.ApiName);

                c.OAuthClientId(adminApiConfiguration.OidcSwaggerUIClientId);
                c.OAuthAppName(ApiConfigurationConsts.ApiName);
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
