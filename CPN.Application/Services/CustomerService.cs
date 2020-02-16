using CPN.Application.Interfaces;
using CPN.Application.ViewModels;
using CPN.Domain.Interfaces.Repository;

namespace CPN.Application.Services
{
    public class CustomerService : ICustomerService
    {

        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerViewModel GetAllCustomersAsync()
        {
            return new CustomerViewModel()
            {
                Customers = _customerRepository.GetCustomers()
            };
        }
    }
}
