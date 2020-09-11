using Edify.Data;
using Edify.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Edify.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static void InjectServiceDependency(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
        }
        public static void InjectRepositoryDependency(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Data.Context.EfyContext>(options =>
            options.UseSqlServer(connectionString));
        }
    }
}
