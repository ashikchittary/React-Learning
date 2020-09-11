using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Edify.Data;
using Edify.Service;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Edify.Infra;

namespace Edify.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks();
            services.AddMvc();

            services.AddRazorPages();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Edify API",
                    Description = "An Api for Edify operations",
                    Contact = new OpenApiContact
                    {
                        Name = "Ashik C",
                        Email = "ashikc@gmail.com",
                        Url = new Uri("https://test.com")
                    }
                });

            });

            //services.AddTransient<ICustomerRepository, CustomerRepository>();
            //services.AddTransient<ICustomerService, CustomerService>();
            services.InjectServiceDependency();
            services.InjectRepositoryDependency();
            services.InjectDbContext(Configuration.GetConnectionString("DefaultConnection"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

           app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Edify API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
            loggerFactory.AddFile("Logs/myapp-{Date}.txt");
        }
    }
}