using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class AppDbContext : DbContext,IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
