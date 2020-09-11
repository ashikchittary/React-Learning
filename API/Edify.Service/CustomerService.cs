using Edify.Data;
using Edify.Model;
using System.Collections.Generic;

namespace Edify.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _custRepository;

        public CustomerService(ICustomerRepository repository)
        {
            _custRepository = repository;
        }

        public bool AddCustomer(CustomerModel customer)
        {
           
            var customerData = new Data.Model.Customer
            {
                Name = customer.Name,
                Email = customer.Email
            };
           return _custRepository.AddCustomer(customerData);
        }
    }
}