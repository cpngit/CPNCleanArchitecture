using CPN.Application.Interfaces;
using CPN.Application.ViewModels;
using CPN.Infra.Data;
using CPN.Infra.Data.Interfaces;
using CPN.Model.Entities;

namespace CPN.Application.Services
{
    public class CustomerService : EntityService<Customer>, ICustomerService
    {

        IUnitOfWork _unitOfWork;
        ICustomerRepository _customerRepository;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
            : base(unitOfWork, customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public CustomerViewModel GetAllCustomersAsync()
        {
            return new CustomerViewModel()
            {
                Customers = _customerRepository.GetAll()
            };
        }
    }
}

