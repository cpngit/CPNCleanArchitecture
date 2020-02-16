
using CPN.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPN.Model
{
    public class CPNDBContext : DbContext
    {
        public CPNDBContext(DbContextOptions<CPNDBContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

