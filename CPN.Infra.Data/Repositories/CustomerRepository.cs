using CPN.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CPN.Infra.Data.Interfaces;

namespace CPN.Infra.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context)
            : base(context)
        {

        }

        public Customer GetById(long id)
        {
            return this.FindBy(c => c.Id == id).FirstOrDefault();
        }

        public Customer GetByName(string name)
        {
            return this.FindBy(c => c.Name == name).FirstOrDefault();
        }
    }
}
