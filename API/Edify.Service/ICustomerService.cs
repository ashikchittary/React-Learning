using Edify.Model;
using System.Collections.Generic;

namespace Edify.Service
{
    public interface ICustomerService
    {
        //List<string> GetAll();
        bool AddCustomer(CustomerModel customer);
    }
}