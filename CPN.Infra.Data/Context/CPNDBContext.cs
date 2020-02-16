
using CPN.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPN.Infra.Data.Context
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

