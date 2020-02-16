using CPN.Model.Entities;

namespace CPN.Infra.Data.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer GetById(long id);
        Customer GetByName(string name);
    }
}
