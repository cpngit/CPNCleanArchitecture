using CPN.Domain.Interfaces.Repository;
using CPN.Domain.Entities;
using CPN.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace CPN.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private CPNDBContext _ctx;

        public CustomerRepository(CPNDBContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _ctx.Customers;
        }
    }
}
