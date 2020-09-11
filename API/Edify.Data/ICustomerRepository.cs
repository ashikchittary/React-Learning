using Edify.Data.Model;
using System.Collections.Generic;

namespace Edify.Data
{
    public interface ICustomerRepository
    {
        // List<string> GetAll();
        bool AddCustomer(Customer customer);
    }
}