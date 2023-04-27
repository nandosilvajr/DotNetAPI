using DotNet001API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotNet001API.Data
{
    public interface IDataContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}