using CPN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPN.Domain.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
    }
}
