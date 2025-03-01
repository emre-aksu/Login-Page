using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;

namespace DataAccessLayer.Context
{
    public class ECommerceDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=Monster;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
