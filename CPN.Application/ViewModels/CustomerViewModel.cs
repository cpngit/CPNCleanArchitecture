using CPN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPN.Application.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
