using Edify.Api.Controllers;
using Edify.Api.ViewModel;
using Edify.Data;
using Edify.Data.Context;
using Edify.Infra;
using Edify.Model;
using Edify.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Efy.Test
{
    [TestClass]
    public class CustomerTest
    {
        private  ICustomerService _service;
        public ICustomerRepository CustomerRepository;

        [TestMethod]
        public void AddCustomer()
        {
            var services = new ServiceCollection();
            services.InjectServiceDependency();
            services.InjectRepositoryDependency();
            services.InjectDbContext("Server=192.168.0.108;Database=LOS_FR_DB;User Id=sa;Password=sql@2016");
            var serviceProvider = services.BuildServiceProvider();
             _service = serviceProvider.GetService<ICustomerService>();
            var customerData = new CustomerModel
            {
                Name = "Test",
                Email = "Test@kamil.com"
            };
           var result = _service.AddCustomer(customerData);
           // Assert.AreEqual(result, true);
        }
    }
}
