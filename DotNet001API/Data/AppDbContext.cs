using Microsoft.EntityFrameworkCore;
using DotNet001API.Models;

namespace DotNet001API.Data
{
    public class AppDbContext : DbContext, IDataContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=secalhar.dynip.sapo.pt,1433;Initial Catalog=AppDataBase; Password=CodFix€#2@Z3; User Id=SA; Trusted_Connection=True; TrustServerCertificate=True; Integrated Security = False;");
        }

    }
}
