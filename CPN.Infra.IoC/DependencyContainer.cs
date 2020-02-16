using CPN.Application.Interfaces;
using CPN.Application.Services;
using CPN.Domain.Interfaces.Repository;
using CPN.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CPN.Infra.IoC
{
   public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<ICustomerService, CustomerService>();

            //Infra.Data Layer
            services.AddScoped<ICustomerRepository, CustomerRepository>();

        }
    }
}
