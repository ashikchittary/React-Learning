using Edify.Data.Context;
using Edify.Data.Migrations;
using Edify.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Edify.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EfyContext _context;
        public CustomerRepository(EfyContext context)
        {
            _context = context;
        }

        public bool AddCustomer(Customer customer)
        { 
            //only needed in inital development
            _context.Database.Migrate();
            _context.Database.EnsureCreated();

            _context.Customer.Add(customer);
            _context.SaveChanges();
            return true;
        }
    }
}