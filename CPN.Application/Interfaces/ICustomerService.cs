using CPN.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPN.Application.Interfaces
{
    public interface ICustomerService
    {
        CustomerViewModel GetAllCustomersAsync();

    }
}
